using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileRegistry {
	public static Tile[] Tiles { get; set; }
	static bool initialized = false;

	public static void Initialize()
	{
		if (initialized)
			throw new System.Exception("TileRegistry has been initialized already.");
		else
			initialized = true;
		Tiles = new Tile[1];
		Tiles[0] = new TestTile();
	}
}
