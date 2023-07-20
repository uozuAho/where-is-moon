using NUnit.Framework.Constraints;
using UnityEngine;

namespace Tests.Utils
{
    internal class VectorConstraint : Constraint
    {
        private readonly Vector3 _expected;
        private readonly float _tolerance;

        public VectorConstraint(Vector3 expected, float tolerance)
        {
            _expected = expected;
            _tolerance = tolerance;
        }

        public override ConstraintResult ApplyTo(object actual)
        {
            return ApplyTo((Vector3)actual);
        }

        public override string Description => $"Expected {_expected} within {_tolerance} of actual";

        private ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (actual is Vector3 actualVector)
            {
                var distance = Vector3.Distance(_expected, actualVector);
                if (distance <= _tolerance)
                {
                    return new ConstraintResult(this, actual, ConstraintStatus.Success);
                }
                else
                {
                    return new ConstraintResult(this, $"{actual}, distance {distance}", ConstraintStatus.Failure);
                }
            }
            else
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
            }
        }
    }
}
