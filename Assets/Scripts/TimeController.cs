using UnityEngine;

public class TimeController : MonoBehaviour
{
    public const float MaxRate = 100 * InternalRate;

    // Number of sim seconds pass per 1 real second. This allows
    // settings fast enough time rates to see the Earth & Moon
    // move.
    private const float InternalRate = 864;

    void Start()
    {
        SetTimeRate(MaxRate);
    }

    void Update()
    {

    }

    public float SecondsSinceStart()
    {
        return Time.time * InternalRate;
    }

    public float DaysSinceStart()
    {
        return SecondsSinceStart() / 86400;
    }

    public float YearsSinceStart()
    {
        return SecondsSinceStart() / (86400 * 365);
    }

    /// <summary>
    /// Set the rate that time passes, compared to real time.
    /// </summary>
    public void SetTimeRate(float rate)
    {
        Time.timeScale = rate / InternalRate;
    }
}
