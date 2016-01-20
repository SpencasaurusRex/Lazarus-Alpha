using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour
{
	private bool m_Selected = false;

	[SerializeField]
	private string m_Title;

	public string title
	{
		get{ return m_Title; }	
	}

	void LateUpdate ()
	{
		m_Selected = false;
	}

	public void Select ()
	{
		m_Selected = true;
	}
}