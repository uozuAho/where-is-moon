using UnityEngine;

public class MoonController : MonoBehaviour
{
    public float orbitSpeed = 1f;

    private float _distanceFromEarth;

    void Start()
    {
        _distanceFromEarth = Vector3.Distance(transform.position, Vector3.zero);
    }

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Sin(Time.time * orbitSpeed) * _distanceFromEarth,
            0f,
            Mathf.Cos(Time.time * orbitSpeed) * _distanceFromEarth
        );
    }
}
