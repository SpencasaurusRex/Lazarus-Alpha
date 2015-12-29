using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light))]
public class Sun : MonoBehaviour
{
	public float m_TimeScale = 20;
	public float m_Time; // [0,1)
	public float m_StartTime = .1f;
	public int m_Day;

	private const float SECONDS_IN_DAY_INVERT = 1.0f / (60 * 60 * 24);
	private const float FULL_ROTATION = 2 * Mathf.PI;
	// Putting the sun at the position will cause the sunlight to be less direct 
	// and not wash out the colors as much. Causes 30 degree tilt
	private const float Y_OFFSET = 0.57735026919f; // Sqrt(3) / 3
	// A small Z Offset is required since a perpindicular light source 
	// wouldn't provide any lighting despite it representing sunrise/sunset
	private const float Z_OFFSET = -0.2f;

	void Start ()
	{
		m_Time = m_StartTime;
		m_Day = 0;
	}

	void Update ()
	{
		// Calculate the new time value by multiplying by the timescale and
		// Dividing by the number of seconds in a day
		float additive = Time.deltaTime * m_TimeScale * SECONDS_IN_DAY_INVERT;
		m_Time += additive;

		// Normalize time to [0,1)
		if (m_Time >= 1) {
			// Truncated addition will work here
			m_Day += (int)m_Time;
			m_Time %= 1;
		}
		// Calculate the X rotation from the time
		float theta = FULL_ROTATION * m_Time;
		transform.position = new Vector3 (Mathf.Cos(theta), Y_OFFSET, -Mathf.Sin(theta) + Z_OFFSET);

		// Look at the origin to point the light in the right direction
		transform.LookAt (new Vector3 ());
	}
}