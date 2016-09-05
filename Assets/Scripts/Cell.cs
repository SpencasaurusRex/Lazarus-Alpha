using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
	public Room room {
		set;
		get;
	}

	private CellPosition pos;

	public CellPosition Pos {
		set
		{ 
			pos = value;
			// TODO update room object
			transform.position = Util.MoveXY(transform.position, Util.Convert(pos));
		}

		get
		{ 
			return pos;
		}

	}
}