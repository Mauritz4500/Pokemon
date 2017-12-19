using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
	public Layer[] Layers { get; set; }

	public World(int layers)
	{
		Layers = new Layer[layers];
	}
}
