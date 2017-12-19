using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
	Tile[,] tiles;
	Vector2i size;
	public Vector2i Size { get { return size; } }

	public Layer(Vector2i size)
	{
		tiles = new Tile[size.x, size.y];
	}

	public Tile GetTile(Vector2i position)
	{
		if (position < size == 0 && position >= Vector2i.zero == 0)
			return tiles[position.x, position.y];
		else
			throw new System.Exception("Tile does not exist: " + position);
	}

	public bool SetTile(Vector2i position, Tile tile)
	{
		if (position < size == 0 && position >= Vector2i.zero == 0)
		{
			tiles[position.x, position.y] = tile;
			return true;
		}
		else
			return false;
	}
}
