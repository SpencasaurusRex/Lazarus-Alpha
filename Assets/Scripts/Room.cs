using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Room : MonoBehaviour
{
	protected Dictionary<CellPosition, List<Cell>> cells = new Dictionary<CellPosition, List<Cell>> ();

	protected abstract void Load ();

	public void AddCell(int x, int y, Cell cell)
	{
		AddCell(new CellPosition(x, y), cell);
	}

	public void AddCell(CellPosition pos, Cell cell)
	{
		List<Cell> posCells;
		if (cells.TryGetValue (pos, out posCells))
		{
			posCells.Add (cell);
		}
		else
		{
			List<Cell> l = new List<Cell> ();
			l.Add (cell);
			cells.Add (pos, l);
		}
	}

	void Start ()
	{
		Load ();
	}
}
