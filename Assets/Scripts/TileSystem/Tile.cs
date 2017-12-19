using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//One tile instance is responsible for all tiles of a certain type
public interface Tile
{
	void Start(Vector2i position, Layer layer, World world);
	void Step(Vector2i position, Layer layer, World world);
}
