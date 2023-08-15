using System;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    private TimeController _timeController;
    private readonly EarthCalcs _earthCalcs = new();

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();

        _earthCalcs.SetReference(
            new Vector3(0, 0, 60),               // z is north in Unity coords
            Quaternion.Euler(-23.4f, 0, 0),      // north pole tilted towards sun (Jun solstice)
            new DateTime(2023, 6, 21, 15, 58, 0, DateTimeKind.Utc)); // Time of last Jun solstice from Wikipedia
    }

    void Update()
    {
        transform.position = _earthCalcs.Position(_timeController.CurrentTime());
        transform.rotation = _earthCalcs.Rotation(_timeController.CurrentTime());

        var places = new[]
        {
            EarthCalcs.LatitudeLongitude(transform, 51.5074, 0.1278), // london
            EarthCalcs.LatitudeLongitude(transform, -37.814, 144.96332), // melbourne
            EarthCalcs.LatitudeLongitude(transform, 35.6895, 139.69171), // tokyo
            EarthCalcs.LatitudeLongitude(transform, 90, 0), // north pole
            EarthCalcs.LatitudeLongitude(transform, -90, 0), // south pole
            EarthCalcs.LatitudeLongitude(transform, -51.817030, -58.799368), // falkland islands
            EarthCalcs.LatitudeLongitude(transform, -10.717154, 142.489021), // qld tip
            EarthCalcs.LatitudeLongitude(transform, -46.9601, 167.830088), // stewart island (NZ south)
        };

        foreach (var place in places)
        {
            Debug.DrawRay(transform.position, place * 1.1f, Color.red);
        }
    }
}
