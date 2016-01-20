using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	private Attribute m_Awareness = new Attribute();
	private Attribute m_Strength = new Attribute();
	private Attribute m_Intelligence = new Attribute();
	private Attribute m_Constitution = new Attribute();

	private Skill m_Mining;
	private Skill m_Building;
	private Skill m_Inventing;
	private Skill m_Blade;
	private Skill m_Defense;
	private Skill m_Archery;
	private Skill m_Magic;
	private Skill m_Crafting;
	private Skill m_Woodcutting;
	private Skill m_Barter;
	private Skill m_Sneak;
	private Skill m_Cooking;
	private Skill m_Agility;
	private Skill m_Farming;

	void Awake()
	{
		m_Mining = new Skill(m_Strength);
		m_Building = new Skill(m_Strength, m_Intelligence);
		m_Inventing = new Skill(m_Intelligence);
		m_Blade = new Skill(m_Strength, m_Awareness);
		m_Defense = new Skill(m_Strength, m_Constitution, m_Awareness);
		m_Archery = new Skill(m_Awareness, m_Strength);
		m_Magic = new Skill(m_Awareness, m_Intelligence);
		m_Crafting = new Skill(m_Intelligence);
		m_Woodcutting = new Skill(m_Strength);
		m_Barter = new Skill(m_Awareness);
		m_Sneak = new Skill (m_Awareness);
		m_Cooking = new Skill();
		m_Agility = new Skill();
		m_Farming = new Skill();
	}

	void Update()
	{
		
	}
}