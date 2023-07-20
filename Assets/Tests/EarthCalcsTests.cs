using NUnit.Framework;
using UnityEngine;
using Is = Tests.Utils.Is;

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
        public void Position_after_quarter_year_is_quarter_orbit()
        {
            var position = new Vector3(0, 0, 10);
            var rotation = Quaternion.Euler(10, 20, 30);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);

            var quarterYearLater = time.AddDays(365 / 4);
            var expectedPosition = new Vector3(-10, 0, 0);

            _earthCalcs.SetReference(position, rotation, time);

            Assert.That(_earthCalcs.Position(quarterYearLater), Is.CloseTo(expectedPosition));
        }

        [Test]
        public void Position_after_one_year_is_full_orbit()
        {
            var startingPosition = new Vector3(0, 0, 10);
            var rotation = Quaternion.Euler(10, 20, 30);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);
            var oneYearLater = time.AddDays(365);

            _earthCalcs.SetReference(startingPosition, rotation, time);

            Assert.That(_earthCalcs.Position(oneYearLater), Is.CloseTo(startingPosition));
        }

        [Test]
        public void Rotation_after_one_sidereal_day_is_starting_rotation()
        {
            var position = new Vector3(0, 0, 10);
            var startingRotation = Quaternion.Euler(0, 0, 0);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);
            var oneDayLater = time.AddHours(23.9344696);

            _earthCalcs.SetReference(position, startingRotation, time);

            Assert.That(_earthCalcs.Rotation(oneDayLater), Is.CloseTo(startingRotation));
        }

        [Test]
        public void Rotation_after_quarter_sidereal_day_is_90_degrees()
        {
            var position = new Vector3(0, 0, 10);
            var startingRotation = Quaternion.Euler(0, 0, 0);
            var time = new System.DateTime(2020, 1, 1, 12, 0, 0);
            var oneDayLater = time.AddHours(23.9344696 / 4);
            _earthCalcs.SetReference(position, startingRotation, time);
            var expectedRotation = startingRotation * Quaternion.AngleAxis(-90, Vector3.up);

            Assert.That(_earthCalcs.Rotation(oneDayLater), Is.CloseTo(expectedRotation));
        }
    }
}
