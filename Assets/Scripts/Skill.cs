using UnityEngine;
using System.Collections;

public class Skill
{
	public int level
	{
		get{ return m_Level; }
	}

	public float xp
	{
		get { return m_Experience; }
	}

	private const int MAX_LEVEL = 100;
	private static AnimationCurve m_StandardExperienceCurve;
	private AnimationCurve m_ExperienceCurve;
	private int m_Level = 1;
	private float m_Experience;
	private Attribute[] m_Attributes;

	static Skill ()
	{
		m_StandardExperienceCurve = new AnimationCurve ();

		// Combine linear and exponential equations to get a special curve
		// f(x) = 100(x-2) + 100 * 1.05^(x-2)
		float cost = 100;
		for (int i = 1; i <= MAX_LEVEL; i++)
		{
			Debug.Log ("Level " + i + ": " + Mathf.Floor (cost + (i - 2) * 100));
			m_StandardExperienceCurve.AddKey (new Keyframe (i, Mathf.Floor (cost + (i - 2) * 100)));
			cost *= 1.05f;
		}
	}

	public Skill (params Attribute[] attributes)
	{
		m_Attributes = attributes;
		m_ExperienceCurve = m_StandardExperienceCurve;
	}

	public Skill (AnimationCurve experienceCurve)
	{
		m_ExperienceCurve = experienceCurve;
	}

	public void gainXP (float xp)
	{
		m_Experience += xp;
		while (m_Experience >= m_ExperienceCurve.Evaluate (m_Level + 1) && m_Level < MAX_LEVEL)
		{
			m_Level++;
		}
	}

	public void levelUp ()
	{
		float xpToAdd = m_ExperienceCurve.Evaluate (m_Level + 1) - m_Experience;
		gainXP (xpToAdd);
	}
}