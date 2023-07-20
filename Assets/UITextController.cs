using TMPro;
using UnityEngine;

public class UITextController : MonoBehaviour
{
    public TMP_Text _currentTimeText;

    private TimeController _timeController;

    void Start()
    {
        _timeController = GameObject.Find("TimeControl").GetComponent<TimeController>();
    }

    void Update()
    {
        _currentTimeText.text = _timeController
            .CurrentTime()
            .ToLocalTime()
            .ToString("yyyy-MM-dd HH:mm:ss");
    }
}
