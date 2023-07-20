using System;
using UnityEngine;

public class EarthCalcs
{
    private Vector3 _referencePosition;
    private Quaternion _referenceRotation;
    private DateTime _referenceTime;

    /// <summary>
    /// Set a known position and rotation of the Earth at a point in time,
    /// to base calculations on.
    /// </summary>
    public void SetReference(Vector3 position, Quaternion rotation, DateTime time)
    {
        _referencePosition = position;
        _referenceRotation = rotation;
        _referenceTime = time;
    }

    public Vector3 Position(DateTime time)
    {
        // note: assumes sun is at (0,0,0)

        var deltaTime = time - _referenceTime;
        // note that Unity's coordinates are left handed
        var degrees = -360 * deltaTime.TotalDays / 365;
        var rotation = Quaternion.Euler(0, (float)degrees, 0);

        return rotation * _referencePosition;
    }

    public Quaternion Rotation(DateTime time)
    {
        const double hoursPerSiderealDay = 23.9344696;

        var deltaTime = time - _referenceTime;
        var siderealDays = deltaTime.TotalHours / hoursPerSiderealDay;
        var degrees = -360 * siderealDays % 360;
        var rotation = Quaternion.Euler(0, (float)degrees, 0).normalized;

        return _referenceRotation * rotation;
    }
}
