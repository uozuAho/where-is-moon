using UnityEngine;

public class UITimeControl : MonoBehaviour
{
    private TimeController _timeController;

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timeController.TogglePlayPause();
        }
    }
}
