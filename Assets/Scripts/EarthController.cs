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
        var radians = Math.PI * 2 * _timeController.YearsSinceStart();

        transform.position = _sun.transform.position + new Vector3(
            -Mathf.Sin((float)radians) * _distanceFromSun,
            0f,
            Mathf.Cos((float)radians) * _distanceFromSun
        );
    }

    private void Rotate()
    {
        transform.rotation = _initialRotation * Quaternion.AngleAxis(
            -360 * _timeController.DaysSinceStart(),
            Vector3.up);
    }
}
