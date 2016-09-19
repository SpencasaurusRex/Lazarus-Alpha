using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Number : MonoBehaviour
{
	[SerializeField]
	private int startingValue;

	[SerializeField]
	private Digit digitPrefab;

	[SerializeField]
	float digitOffset = 0.25f;

	private int value;
	private List<Digit> digits;

	[SerializeField]
	private Color color;

	public Color Color 
	{
		set
		{
			color = value;
			if (digits != null)
			{
				foreach (Digit d in digits)
				{
					d.SetColor (color);			
				}
			}
		}
		get
		{
			return color;
		}
	}

	public int Value {
		set 
		{ 
			this.value = value;
			string s = value.ToString ();
			for (int i = 0; i < s.Length; i++)
			{
				int digit;
				int.TryParse (s.Substring (i, 1), out digit);
				Vector3 position = transform.position + new Vector3 (digitOffset, 0) * i;
				Digit d = (Digit) Instantiate (digitPrefab, position, transform.rotation);
				d.SetDigit (digit);
				d.transform.parent = transform;
				digits.Add (d);
			}
			Color = Color;
		}
		get 
		{
			return value;
		}
	}

	void Start ()
	{
		digits = new List<Digit> ();
		Value = startingValue;
	}
}