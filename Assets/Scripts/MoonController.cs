using System;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    private float _distanceFromEarth;
    private GameObject _earth;
    private TimeController _timeController;

    void Start()
    {
        _earth = GameObject.Find("Earth").gameObject;
        _distanceFromEarth = Vector3.Distance(transform.position, _earth.transform.position);
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
    }

    void Update()
    {
        OrbitEarth();
    }

    private void OrbitEarth()
    {
        const double moonOrbitPeriodDays = 27.32;
        var radians = 2 * Math.PI * _timeController.DaysSinceStart() / moonOrbitPeriodDays;

        transform.position = _earth.transform.position + new Vector3(
            -Mathf.Sin((float)radians) * _distanceFromEarth,
            0f,
            Mathf.Cos((float)radians) * _distanceFromEarth
        );
    }
}
