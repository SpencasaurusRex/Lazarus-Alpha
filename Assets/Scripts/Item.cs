using UnityEngine;
using System.Collections;

public class Item
{
	public string m_Title = "unnamed item";

	// Default constructor names items "unnamed item"
	public Item ()
	{
		m_Title = "unnamed item";
	}

	public Item (string title)
	{
		m_Title = title;
	}
}