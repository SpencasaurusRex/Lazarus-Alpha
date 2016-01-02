using UnityEngine;
using System.Collections;

public class PhysicalItem : MonoBehaviour
{
	public Item m_Item;
	public string m_Title;

	void Start ()
	{
		if (m_Title != "")
		{
			m_Item = new Item (m_Title);
		}
		else
		{
			m_Item = new Item ();
		}
	}

	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.GetComponent<Unit> () != null)
		{
			Unit u = col.gameObject.GetComponent<Unit> ();
			u.AddItem (m_Item);
			Destroy (gameObject);
		}
	}
}
