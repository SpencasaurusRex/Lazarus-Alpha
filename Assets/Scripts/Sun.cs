using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class Sun : MonoBehaviour
{
    public float m_TimeScale = 20;
    public float m_Time; // [0,1)
    public float m_StartTime = .1f;
    public int m_Day;

    private const float SECONDS_IN_DAY_INVERT = 1.0f / (60 * 60 * 24);
    private const float FULL_ROTATION = 2 * Mathf.PI;

    void Start()
    {
        m_Time = m_StartTime;
        m_Day = 0;
    }

    void Update()
    {
        // Calculate the new time value by multiplying by the timescale and
        // Dividing by the number of seconds in a day
        float additive = Time.deltaTime * m_TimeScale * SECONDS_IN_DAY_INVERT;
        m_Time += additive;

        // Normalize time to [0,1)
        if (m_Time >= 1)
        {
            // Truncated addition will work here
            m_Day += (int)m_Time;
            m_Time %= 1;
        }
        // Calculate the X rotation from the time
        float theta = FULL_ROTATION * m_Time;
        transform.position = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0.0f);

        // Look at the origin to point the light in the right direction
        transform.LookAt(new Vector3());
    }
}