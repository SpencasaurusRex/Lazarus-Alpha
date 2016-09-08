using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteChooser : MonoBehaviour
{
	[SerializeField]
	private Sprite[] sprites;

	private SpriteRenderer sr;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
		ChooseRandom ();
	}

	public void ChooseRandom ()
	{
		int index = Random.Range (0, sprites.Length);
		Sprite chosenSprite = sprites [index];
		sr.sprite = chosenSprite;
	}
}