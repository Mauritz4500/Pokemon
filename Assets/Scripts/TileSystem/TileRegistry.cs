using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileRegistry {
	public static Tile[] Tiles { get; set; }
	static bool initialized = false;

	public static void Initialize()
	{
		if (initialized)
			Debug.Log("TileRegistry has been initialized already.");
		else
			initialized = true;
		Tiles = new Tile[2];
		Tiles[0] = new TextureTile(0, 0);
		Tiles[1] = new TextureTile(3, 3);
	}
}
