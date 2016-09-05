using UnityEngine;
using System.Collections;

public class Util
{
	public static Vector2 Convert (Vector3 vec)
	{
		return new Vector2 (vec.x, vec.y);
	}

	public static Vector2 Convert(CellPosition pos)
	{
		return new Vector2 (pos.X, pos.Y);
	}

	public static Vector3 Convert (Vector2 vec)
	{
		return new Vector3 (vec.x, vec.y, 0.0f);
	}

	public static Vector3 MoveXY(Vector3 vec, Vector2 to)
	{
		vec.x = to.x;
		vec.y = to.y;
		return vec;
	}

	public static bool IsZero (Vector2 vec)
	{
		return Mathf.Approximately (vec.x, 0.0f) && Mathf.Approximately (vec.y, 0.0f);
	}
}