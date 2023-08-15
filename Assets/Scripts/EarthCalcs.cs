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

    /// <summary>
    /// Returns a point on the Earth's surface (relative to its center)
    /// at the given latitude and longitude.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="latitude">Latitude. North is positive.</param>
    /// <param name="longitude">Longitude. East is positive.</param>
    /// <returns></returns>
    public static Vector3 LatitudeLongitude(Transform transform, double latitude, double longitude)
    {
        // is this right?
        // compare with euler
        // also see https://en.wikipedia.org/wiki/Geographic_coordinate_system#Expressing_latitude_and_longitude_as_linear_units
        // and https://stackoverflow.com/questions/5437865/longitude-latitude-to-quaternion
        var northSouth = Quaternion.AngleAxis((float)latitude, transform.forward);
        var eastWest = Quaternion.AngleAxis(-(float)longitude, transform.up);

        return eastWest * northSouth * transform.right * transform.localScale.z / 2;
    }
}
