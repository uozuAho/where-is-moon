using UnityEngine;

public class MoonController : MonoBehaviour
{
    public float orbitSpeed = 1f;

    private float _distanceFromEarth;
    private GameObject _earth;

    void Start()
    {
        _earth = GameObject.Find("Earth").gameObject;
        _distanceFromEarth = Vector3.Distance(transform.position, _earth.transform.position);
    }

    void Update()
    {
        transform.position = _earth.transform.position + new Vector3(
            -Mathf.Sin(Time.time * orbitSpeed) * _distanceFromEarth,
            0f,
            Mathf.Cos(Time.time * orbitSpeed) * _distanceFromEarth
        );
    }
}
