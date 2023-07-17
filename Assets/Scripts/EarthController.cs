using UnityEngine;

public class EarthController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.up, -0.1f);
    }
}
