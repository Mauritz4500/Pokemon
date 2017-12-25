using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public static class TileRegistry {
	public static Tile[] Tiles { get; set; }
	public static string[] TileNames { get; set; }
	static bool initialized = false;

	public static void Initialize()
	{
		if (initialized) {
			Debug.Log ("TileRegistry has been initialized already.");
			return;
		}
		else
			initialized = true;
		TileNames = new string[2];
		Tiles = new Tile[2];
		Tiles[0] = new TextureTile(0, 0, 0);
		TileNames[0] = "Test 1 [0, 0]";
		Tiles[1] = new TextureTile(1, 3, 3);
		TileNames[1] = "Test 2 [3, 3]";
	}

	public static void LoadFromFile(string fileName)
	{
		//Implement sometime in the future, some kinda xml stuff
	}
}
