using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTile : Tile
{
	public void Start(Vector2i position, Layer layer, World world)
	{
		
	}

	public void Step(Vector2i position, Layer layer, World world)
	{
		
	}

	public Vector2i TextureCoordinates(Vector2i position, Layer layer, World world)
	{
		return new Vector2i(position.x / 2 % 5, position.y / 2 % 4);
	}
}
