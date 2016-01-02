using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

	public Inventory m_Inventory;

	void Start ()
	{
		m_Inventory = new Inventory ();
	}

	void Update ()
	{
		
	}

	public void AddItem (Item i)
	{
		m_Inventory.AddItem (i);
	}

	public void RemoveItem (Item i)
	{
		m_Inventory.RemoveItem (i);
	}
}
