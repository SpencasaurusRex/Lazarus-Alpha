using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class Digit : MonoBehaviour {

	[SerializeField]
	private Sprite[] numbers;
	private SpriteRenderer sr;
	private int value;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	public void SetDigit(int i)
	{
		value = i;
		if (sr == null)
		{
			sr = GetComponent<SpriteRenderer> ();
		}
		if (i < 0 || i > 9)
		{
			Debug.LogError ("Cannot set digit: " + i);
			return;
		}
		sr.sprite = numbers [i];
	}

	public void SetColor(Color c)
	{
		sr.color = c;
	}

	public override string ToString ()
	{
		return string.Format ("[Digit]: {0}", value);
	}
}