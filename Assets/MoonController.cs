using UnityEngine;

public class MoonController : MonoBehaviour
{
    public float orbitSpeed = 1f;
    
    private float distanceFromEarth = 385f;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Sin(Time.time * orbitSpeed) * distanceFromEarth,
            0f,
            Mathf.Cos(Time.time * orbitSpeed) * distanceFromEarth
        );    
    }
}
