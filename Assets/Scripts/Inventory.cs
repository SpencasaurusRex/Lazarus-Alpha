using UnityEngine;
using System.Collections.Generic;

public class Inventory
{

	private List<Item> m_Items;

	public Inventory ()
	{
		m_Items = new List<Item> ();	
	}

	public void AddItem (Item i)
	{
		m_Items.Add (i);
	}

	public void RemoveItem (Item i)
	{
		if (m_Items.Contains (i))
		{
			m_Items.Remove (i);
		}
		else
		{
			Debug.Log ("The item to be removed is not contained by this inventory");
		}
	}

	public void PrintInventory ()
	{
		foreach (Item i in m_Items)
		{
			Debug.Log (i.m_Title);
		}
	}
}