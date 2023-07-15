using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private Vector2 rotation = Vector2.zero;
    private float lookSpeed = 3f;

    void Start()
    {
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        rotation.x -= mouseY;
        rotation.y += mouseX;
        transform.eulerAngles = rotation * lookSpeed;
    }
}
