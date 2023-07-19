using System;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private GameObject _sun;
    private float _distanceFromSun;
    private TimeController _timeController;
    private Quaternion _initialRotation;

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
        _sun = GameObject.Find("Sun").gameObject;
        _distanceFromSun = Vector3.Distance(transform.position, _sun.transform.position);
        _initialRotation = transform.rotation;
    }

    void Update()
    {
        Rotate();
        OrbitSun();
    }

    private void OrbitSun()
    {
        // 'zero' earth pos in Unity = (0, 0, 60), December solstice
        // zero time according to time controller = 12am Jan 1
        // 2022 Dec solstice = Dec 21, 21:48UTC

        var zeroTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var solsticeTime = new DateTime(2022, 12, 21, 21, 48, 0, DateTimeKind.Utc);
        var offset = solsticeTime - zeroTime;
        var offsetRadians = offset.TotalDays / 365 * 2 * Math.PI;

        var radians = offsetRadians + Math.PI * 2 * _timeController.YearsSinceYearStart();

        transform.position = _sun.transform.position + new Vector3(
            -Mathf.Sin((float)radians) * _distanceFromSun,
            0f,
            Mathf.Cos((float)radians) * _distanceFromSun
        );
    }

    private void Rotate()
    {
        // 'zero' rotation is ~-90 longitude. Need to add 90 degrees to start at UTC midnight.
        const int offset = 90;
        const int secondsPerSiderealDay = 23 * 3600 + 56 * 60;
        var siderealDays = _timeController.SecondsSinceYearStart() / secondsPerSiderealDay;
        var degreesRotated = siderealDays * 360;

        transform.rotation = _initialRotation * Quaternion.AngleAxis(
            offset - degreesRotated,
            Vector3.up);
    }
}
