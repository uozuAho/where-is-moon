using UnityEngine;

public class EarthController : MonoBehaviour
{
    public float orbitSpeed;

    private GameObject _sun;
    private float _distanceFromSun;

    void Start()
    {
        _sun = GameObject.Find("Sun").gameObject;
        _distanceFromSun = Vector3.Distance(transform.position, _sun.transform.position);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, -0.1f);

        transform.position = _sun.transform.position + new Vector3(
            -Mathf.Sin(Time.time * orbitSpeed) * _distanceFromSun,
            0f,
            Mathf.Cos(Time.time * orbitSpeed) * _distanceFromSun
        );
    }
}
