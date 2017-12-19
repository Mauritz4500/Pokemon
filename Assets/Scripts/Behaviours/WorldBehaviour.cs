using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehaviour : MonoBehaviour
{
	public World World { get; set; }
	GameObject[] layerObjects;
	LayerBehaviour[] layerBehaviours;

	void Start()
	{
		layerObjects = new GameObject[World.Layers.Length];
		for (int i = 0; i < World.Layers.Length; i++)
		{
			layerObjects[i] = new GameObject("Layer " + i, typeof(LayerBehaviour));
			layerBehaviours[i] = layerObjects[i].GetComponent<LayerBehaviour>();
		}
	}

	void Update()
	{

	}
}
