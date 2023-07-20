using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace Tests
{
    public class EarthCalcsTests
    {
        private EarthCalcs _earthCalcs = new EarthCalcs();

        [Test]
        public void Position_at_reference_time()
        {
            var position = new Vector3(1, 2, 3);
            var rotation = Quaternion.Euler(10, 20, 30);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);

            _earthCalcs.SetReference(position, rotation, time);

            Assert.AreEqual(position, _earthCalcs.Position(time));
        }

        [Test]
        public void Position_after_reference_time()
        {
            var position = new Vector3(0, 0, 10);
            var rotation = Quaternion.Euler(10, 20, 30);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);

            var quarterYearLater = time.AddDays(365 / 4);
            var expectedPosition = new Vector3(-10, 0, 0);

            _earthCalcs.SetReference(position, rotation, time);

            Assert.That(_earthCalcs.Position(quarterYearLater), Is.CloseTo(expectedPosition));
        }
    }

    internal class Is : NUnit.Framework.Is
    {
        public static VectorConstraint CloseTo(Vector3 expected)
        {
            return new VectorConstraint(expected, 0.05f);
        }
    }

    class VectorConstraint : Constraint
    {
        private Vector3 _expected;
        private float _tolerance;

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
