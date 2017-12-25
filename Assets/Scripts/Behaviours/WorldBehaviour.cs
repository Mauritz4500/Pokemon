using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldBehaviour : MonoBehaviour
{
	public static WorldBehaviour worldBehaviour;
	public Material material;
	public World World { get; set; }
	public LayerBehaviour[] layerBehaviours;
	private int currentLayer;
	public int CurrentLayer
	{
		get { return currentLayer; }
		set
		{
			currentLayer = value;
			for (int i = 0; i < layerBehaviours.Length; i++)
			{
				layerBehaviours[i].boxCollider.enabled = false;
				layerBehaviours[i].meshRenderer.enabled = false;
			}
			layerBehaviours[value].boxCollider.enabled = true;
			layerBehaviours[value].meshRenderer.enabled = true;
		}
	}

	GameObject[] layerObjects;

	void OnEnable()
	{
		if (!(worldBehaviour == this || worldBehaviour == null))
			Debug.LogError("'worldBehaviour' assigned to different WorldBehaviour, reassigning...");
		worldBehaviour = this;

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
				World.Layers[i] = new Layer(new Vector2i(100, 100)); //Test code
				layerObjects[i] = new GameObject("Layer " + i, typeof(LayerBehaviour), typeof(MeshFilter), typeof(MeshRenderer));
				layerObjects[i].transform.SetParent(transform);
				layerBehaviours[i] = layerObjects[i].GetComponent<LayerBehaviour>();
				layerBehaviours[i].World = World;
				layerBehaviours[i].WorldBehaviour = this;
				layerBehaviours[i].Layer = World.Layers[i];
				layerObjects[i].GetComponent<MeshRenderer>().material = material;
			}
		}
	}
}
