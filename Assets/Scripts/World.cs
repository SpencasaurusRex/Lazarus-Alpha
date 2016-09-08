using UnityEngine;
using System.Collections;

public class World : Room
{
	[SerializeField]
	Cell[] seedCells;

	[SerializeField]
	protected int width;

	[SerializeField]
	protected int height;

	protected override void Load ()
	{
		Debug.Log ("Loading World");
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				CellPosition pos = new CellPosition (i, j);

				int index = Random.Range (0, seedCells.Length);
				Cell c = seedCells [index];
				c = Instantiate (c);
				c.transform.parent = this.transform;
				c.Pos = pos;
				AddCell (pos, seedCells [index]);
			}
		}
	}
}