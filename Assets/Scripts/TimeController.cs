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

    private float _secondsSinceYearStart;
    private float _prePauseTimeScale;

    // 'zero time' earth rotation is midday over Santa Cruz, Equador, -0.7869498837733746, -90.33499760536569

    void Start()
    {
        SetTimeRate(OneDayPerMinute);
        var timeSinceStartOfYear = DateTime.UtcNow - new DateTime(DateTime.Now.Year, 1, 1);
        _secondsSinceYearStart = (float)timeSinceStartOfYear.TotalSeconds;
    }

    public float SecondsSinceYearStart()
    {
        return Time.time * InternalRate + _secondsSinceYearStart;
    }

    public float DaysSinceYearStart()
    {
        return SecondsSinceYearStart() / 86400;
    }

    public float YearsSinceYearStart()
    {
        return SecondsSinceYearStart() / (86400 * 365);
    }

    /// <summary>
    /// Set the rate that time passes, compared to real time.
    /// </summary>
    public void SetTimeRate(float rate)
    {
        Time.timeScale = rate / InternalRate;
    }

    public DateTime CurrentUtcTime()
    {
        return new DateTime(DateTime.UtcNow.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(SecondsSinceYearStart());
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
}
