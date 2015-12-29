using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public GameObject m_Target;

	private float m_ZOffset;

	void Start ()
	{
		m_ZOffset = transform.position.z;
	}

	void Update ()
	{
		if (m_Target != null)
		{
			transform.position = m_Target.transform.position;
			transform.position += new Vector3 (0.0f, 0.0f, m_ZOffset);
		}
	}
}