using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
	public Tile[,] Tiles { get; set; }
	Vector2i size;
	public Vector2i Size { get { return size; } }

	public Layer(Vector2i size)
	{
		Tiles = new Tile[size.x, size.y];
		this.size = size;
		//<Test code>
		for (int x = 0; x < size.x; x += 2)
		{
			for (int y = x & 1; y < size.y; y += 2)
			{
				Tiles[x, y] = TileRegistry.Tiles[0];
			}
		}
		// </Test code>
	}

	public Tile GetTile(Vector2i position)
	{
		if (position < size == 0 && position >= Vector2i.zero == 0)
			return Tiles[position.x, position.y];
		else
			throw new System.Exception("Tile does not exist: " + position);
	}

	public bool SetTile(Vector2i position, Tile tile)
	{
		if (position < size == 3 && position >= Vector2i.zero == 3)
		{
			Tiles[position.x, position.y] = tile;
			return true;
		}
		else
			return false;
	}
}
