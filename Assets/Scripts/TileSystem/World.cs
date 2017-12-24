using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
	public static World world;
	public Layer[] Layers { get; set; }

	public World(int layers)
	{
		world = this;
		Layers = new Layer[layers];
	}
}
