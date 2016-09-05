using UnityEngine;
using System.Collections;

public class Util
{
	public static Vector2 convert (Vector3 vec)
	{
		return new Vector2 (vec.x, vec.y);
	}

	public static bool isZero (Vector2 vec)
	{
		return Mathf.Approximately (vec.x, 0.0f) && Mathf.Approximately (vec.y, 0.0f);
	}
}