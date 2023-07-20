using System;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private TimeController _timeController;
    private Quaternion _initialRotation;
    private EarthCalcs _earthCalcs = new();

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
        _initialRotation = transform.rotation;

        _earthCalcs.SetReference(
            new Vector3(0, 0, 60),               // z is north in Unity coords
            Quaternion.Euler(-23.4f, 0, 0),      // north pole tilted towards sun (Dec solstice)
            new DateTime(2022, 12, 21, 21, 48, 0, DateTimeKind.Utc)); // Time of last Dec solstice from Wikipedia
    }

    void Update()
    {
        transform.position = _earthCalcs.Position(_timeController.CurrentUtcTime());
        Rotate();
    }

    private void Rotate()
    {
        // 'zero' rotation in Unity is Sun over ~-90 longitude
        // rotate by -90 sets Earth to 12am UTC
        var offset = -90;

        var lastDecSolstice = _timeController.LastDecSolstice();
        var rotationAtLastSolstice = (float)lastDecSolstice.TimeOfDay.TotalDays * 360;

        const int secondsPerSiderealDay = 23 * 3600 + 56 * 60;
        var siderealDays = _timeController.SecondsSinceDecSolstice() / secondsPerSiderealDay;
        var rotatedSinceSolstice = siderealDays * 360;

        var currentRotation = rotationAtLastSolstice + rotatedSinceSolstice + offset;

        transform.rotation = _initialRotation * Quaternion.AngleAxis(
            (float)currentRotation,
            Vector3.up);
    }
}
