using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
	private Selectable m_Selected;

	[SerializeField]
	private Text m_Text;

	void Update ()
	{
		Vector3 CameraCenter = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
		RaycastHit hitInfo;
		if (Physics.Raycast (CameraCenter, transform.forward, out hitInfo, 100)) {
			GameObject o = hitInfo.transform.gameObject;
			Selectable s = o.GetComponent<Selectable> ();
			if (s != null) {
				s.Select ();
				if (m_Text != null) {
					m_Text.text = s.name;
				}
			} else {
				if (m_Text != null) {
					m_Text.text = "";
				}
			}
		} 
		else 
		{
			if (m_Text != null ) 
			{
				m_Text.text = "";
			}
		}
	}
}