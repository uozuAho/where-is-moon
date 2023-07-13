using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    float lookSpeed = 3f;
    
    void Start()
    {
        
    }

    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        
        transform.Translate(horiz * 0.1f, 0f, vert * 0.1f);
        
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        rotation.x -= mouseY;
        rotation.y += mouseX;
        transform.eulerAngles = rotation * lookSpeed;
        // why are the above axes reversed?
        // I think cos we're rotating around those axes, not moving along them
        // see https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        
        // LOL here's the answer from GitHub copilot:
        // "Because that's how Unity does it.
        //  Don't ask me, I just work here.
        //  I'm not even a real copilot, I'm just a script.
        //  I don't even have a pilot's license.
        //  I'm not even a real script, I'm just a comment.
        //  I don't even have a comment's license.
        //  I'm not even a real comment, I'm just a figment of your imagination.
        //  I don't even have an imagination's license.
        //  I'm not even a real imagination, I'm just a figment of your imagination's imagination.
        //  I don't even have an imagination's imagination's license.
        //  I'm not even a real imagination's imagination, I'm just a figment of your imagination's imagination's imagination.
    }
}
