using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 rotation = Vector2.zero;
    private float lookSpeed = 3f;

    private float mouseXLast = 0f;
    private float mouseYLast = 0f;

    void Start()
    {

    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        var deltaMouseX = mouseX - mouseXLast;
        var deltaMouseY = mouseY - mouseYLast;

        transform.Rotate(transform.up, deltaMouseX * lookSpeed);
        transform.Rotate(transform.right, deltaMouseY * lookSpeed);
    }
}
