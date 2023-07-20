using NUnit.Framework.Constraints;
using UnityEngine;

namespace Tests.Utils
{
    internal class QuaternionConstraint : Constraint
    {
        private readonly Quaternion _expected;
        private readonly float _tolerance;
        private float _expectedAngle;
        private Vector3 _expectedAxis;

        public QuaternionConstraint(Quaternion expected, float tolerance)
        {
            _expected = expected;
            _expected.ToAngleAxis(out _expectedAngle, out _expectedAxis);
            _tolerance = tolerance;
        }

        public override string Description => $"Expected {_expectedAngle} around {_expectedAxis}";

        public override ConstraintResult ApplyTo(object actual)
        {
            return ApplyTo((Quaternion)actual);
        }

        public ConstraintResult ApplyTo(Quaternion actual)
        {
            actual.ToAngleAxis(out var actualAngle, out var actualAxis);

            var angleDifference = Mathf.Abs(_expectedAngle - actualAngle);
            var axisDifference = Vector3.Distance(_expectedAxis, actualAxis);

            if (angleDifference <= _tolerance && axisDifference <= _tolerance)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            }
            else
            {
                return new ConstraintResult(this,
                    $"{actualAngle} around {actualAxis}. {angleDifference} degrees difference, {axisDifference} axis difference",
                    ConstraintStatus.Failure);
            }
        }
    }
}
