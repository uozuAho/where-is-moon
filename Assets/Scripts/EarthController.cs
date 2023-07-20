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
    }
}
