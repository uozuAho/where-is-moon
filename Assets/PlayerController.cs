using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float lookSpeed = 3f;

    private float mouseXLast = 0f;
    private float mouseYLast = 0f;
    private Vector3 _playerUp;

    void Start()
    {
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        var deltaMouseX = mouseX - mouseXLast;
        var deltaMouseY = mouseY - mouseYLast;

        transform.Rotate(Vector3.up, deltaMouseX * lookSpeed);
        transform.Rotate(Vector3.right, -deltaMouseY * lookSpeed);
    }
}
