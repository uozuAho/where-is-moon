using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;

public class UIPlayPause : MonoBehaviour
{
    private Toggle _toggle;
    private TimeController _timeController;

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
        _toggle = GameObject.Find("PlayPause").GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnChanged);
    }

    void OnChanged(bool on)
    {
        if (on) _timeController.Play();
        else _timeController.Pause();
    }
}
