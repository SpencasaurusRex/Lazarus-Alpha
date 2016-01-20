using UnityEngine;
using System.Collections;

public class Attribute : Skill 
{
	private static AnimationCurve m_ExperienceCurve = AnimationCurve.Linear (1, 1, 100, 100);

	public Attribute() : base(m_ExperienceCurve)
	{
		
	}
}