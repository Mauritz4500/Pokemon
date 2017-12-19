using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehaviour : MonoBehaviour
{
	public Material material;
	public World World { get; set; }
	GameObject[] layerObjects;
	LayerBehaviour[] layerBehaviours;

	void Start()
	{
		TileRegistry.Initialize();

		World = new World(2);

		layerObjects = new GameObject[World.Layers.Length];
		layerBehaviours = new LayerBehaviour[World.Layers.Length];
		for (int i = 0; i < World.Layers.Length; i++)
		{
			layerObjects[i] = new GameObject("Layer " + i, typeof(LayerBehaviour), typeof(MeshFilter), typeof(MeshRenderer));
			layerBehaviours[i] = layerObjects[i].GetComponent<LayerBehaviour>();
			layerBehaviours[i].World = World;
			layerObjects[i].GetComponent<MeshRenderer>().material = material;
		}
	}

	void Update()
	{

	}
}
