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
        // 'zero' earth pos = (0, 0, 60), equinox, heading towards south pole summer
        // need to correct this to be 12am, 1st Jan, which is roughly pi/2 radians
        // from zero position

        var radians = Math.PI/2 + Math.PI * 2 * _timeController.YearsSinceYearStart();

        transform.position = _sun.transform.position + new Vector3(
            -Mathf.Sin((float)radians) * _distanceFromSun,
            0f,
            Mathf.Cos((float)radians) * _distanceFromSun
        );
    }

    private void Rotate()
    {
        // 'zero' rotation is ~-90 longitude. Need to add 90 degrees.

        transform.rotation = _initialRotation * Quaternion.AngleAxis(
            90 - 360 * _timeController.DaysSinceYearStart(),
            Vector3.up);
    }
}
