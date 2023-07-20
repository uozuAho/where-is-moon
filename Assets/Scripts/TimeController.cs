using System;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public const float MaxRate = OneDayPerSecond;
    public const float OneDayPerSecond = 100 * InternalRate;
    public const float OneDayPerMinute = OneDayPerSecond / 60;

    // Number of sim seconds per 1 real second. This allows
    // setting fast enough time rates to see the Earth & Moon
    // move.
    private const float InternalRate = 864;

    private DateTime _referenceTime;
    private float _prePauseTimeScale;

    void Start()
    {
        SetTimeRate(OneDayPerMinute);
        SetCurrentTime(DateTime.UtcNow);
    }

    public void SetCurrentTime(DateTime time)
    {
        if (time.Kind != DateTimeKind.Utc)
            throw new ArgumentException("Time must be UTC", nameof(time));

        _referenceTime = time.AddSeconds(-SimSecondsPassed());
    }

    public DateTime CurrentTime()
    {
        return _referenceTime.AddSeconds(SimSecondsPassed());
    }

    public void Pause()
    {
        _prePauseTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = _prePauseTimeScale;
    }

    public float SimSecondsPassed()
    {
        return Time.time * InternalRate;
    }

    /// <summary>
    /// Set the rate that time passes, compared to real time.
    /// </summary>
    private void SetTimeRate(float rate)
    {
        Time.timeScale = rate / InternalRate;
    }
}
