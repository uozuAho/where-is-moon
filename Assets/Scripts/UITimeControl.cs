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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _timeController.SetCurrentTime(_timeController.CurrentTime().AddHours(-1));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _timeController.SetCurrentTime(_timeController.CurrentTime().AddHours(1));
        }
    }
}
