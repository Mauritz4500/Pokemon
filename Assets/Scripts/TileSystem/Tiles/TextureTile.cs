using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTile : Tile
{
	int tX, tY;
	ushort id;

	public TextureTile(ushort id, int tX, int tY)
	{
		this.id = id;
		this.tX = tX;
		this.tY = tY;
	}

	public void Start(Vector2i position, Layer layer, World world)
	{

	}

	public void Step(Vector2i position, Layer layer, World world)
	{

	}

	public Vector2i TextureCoordinates(Vector2i position, World world, Layer layer)
	{
		return new Vector2i(tX, tY);
	}

	public ushort ID { get { return id; } }
}
