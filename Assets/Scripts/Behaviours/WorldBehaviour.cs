using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldBehaviour : MonoBehaviour
{
	public Material material;
	public World World { get; set; }
	public LayerBehaviour[] layerBehaviours;
	GameObject[] layerObjects;

	void OnEnable()
	{
		TileRegistry.Initialize();

		foreach (Transform child in transform)
		{
			if (!Application.isPlaying)
				DestroyImmediate(child.gameObject);
			else
				Destroy(child.gameObject);
		}

		World = new World(2);

		if(layerObjects == null)
		{
			layerObjects = new GameObject[World.Layers.Length];
			layerBehaviours = new LayerBehaviour[World.Layers.Length];
			for (int i = 0; i < World.Layers.Length; i++)
			{
				layerObjects[i] = new GameObject("Layer " + i, typeof(LayerBehaviour), typeof(MeshFilter), typeof(MeshRenderer));
				layerObjects[i].transform.SetParent(transform);
				layerBehaviours[i] = layerObjects[i].GetComponent<LayerBehaviour>();
				layerBehaviours[i].World = World;
				layerBehaviours[i].WorldBehaviour = this;
				layerObjects[i].GetComponent<MeshRenderer>().material = material;
			}
		}
	}
}
