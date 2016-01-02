using UnityEngine;
using System.Collections;

public class ItemAttractor : MonoBehaviour
{

	void Start ()
	{
	
	}

	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.GetComponent<Item> () != null)
		{
					
		}
	}
}
