using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LayerBehaviour : MonoBehaviour
{
	public Layer Layer { get; set; } //Maybe do get{World.Layers[index of this layer]} for consistency
	public World World { get; set; }
	public WorldBehaviour WorldBehaviour { get; set; }
	public bool Refresh { get; set; }
	public BoxCollider boxCollider;
	public MeshRenderer meshRenderer;
	MeshFilter meshFilter;

	void Start()
	{
		bool exists = false;
		if(WorldBehaviour == null)
		{
			Destroy();
			return;
		}
		for (int i = 0; i < WorldBehaviour.layerBehaviours.Length; i++)
		{
			exists |= WorldBehaviour.layerBehaviours[i] == this;
		}
		if (!exists)
		{
			Destroy();
			return;
		}
		meshFilter = GetComponent<MeshFilter>();
		meshRenderer = GetComponent<MeshRenderer>();
		boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.center = new Vector3(Layer.Size.x >> 1, Layer.Size.y >> 1, 1); //Half size
		boxCollider.size = new Vector3(Layer.Size.x, Layer.Size.y, 1);
		InitalizeMesh();
		Render();
	}
	
	void Update()
	{
		if (Refresh)
		{
			Render();
			Refresh = false;
		}
	}

	void Destroy()
	{
		if (/*Application.isEditor && */!Application.isPlaying)
			DestroyImmediate(gameObject);
		else
			Destroy(gameObject);
	}

	void InitalizeMesh()
	{
		int sizeX = Layer.Size.x, sizeY = Layer.Size.y;
		Vector3[] vertices = new Vector3[sizeX * sizeY * 4];
		int[] indices = new int[sizeX * sizeY * 4];
		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
			{
				vertices[(x + sizeX * y) * 4] = new Vector3(x, y, 0);
				vertices[(x + sizeX * y) * 4 + 1] = new Vector3(x + 1, y, 0);
				vertices[(x + sizeX * y) * 4 + 2] = new Vector3(x, y + 1, 0);
				vertices[(x + sizeX * y) * 4 + 3] = new Vector3(x + 1, y + 1, 0);
				indices[(x + sizeX * y) * 4] = (x + sizeX * y) * 4;
				indices[(x + sizeX * y) * 4 + 1] = (x + sizeX * y) * 4 + 2;
				indices[(x + sizeX * y) * 4 + 2] = (x + sizeX * y) * 4 + 3;
				indices[(x + sizeX * y) * 4 + 3] = (x + sizeX * y) * 4 + 1;
			}
		}
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.SetIndices(indices, MeshTopology.Quads, 0);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		if (/*Application.isEditor && */!Application.isPlaying)
			meshFilter.sharedMesh = mesh;
		else
			meshFilter.mesh = mesh;
	}

	public void Render()
	{
		int sizeX = Layer.Size.x, sizeY = Layer.Size.y;
		Vector2[] textureCoordinates = new Vector2[sizeX * sizeY * 4];
		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
			{
				if (Layer.Tiles[x, y] != null)
				{
					Vector2i position = new Vector2i(x, y);
					Vector2 tileTextureCoordinates = (Vector2)Layer.Tiles[x, y].TextureCoordinates(position, World, Layer) * Static.TextureScale;
					textureCoordinates[(x + sizeX * y) * 4] = tileTextureCoordinates;
					textureCoordinates[(x + sizeX * y) * 4 + 1] = tileTextureCoordinates + Vector2.right * Static.TextureScale;
					textureCoordinates[(x + sizeX * y) * 4 + 2] = tileTextureCoordinates + Vector2.up * Static.TextureScale;
					textureCoordinates[(x + sizeX * y) * 4 + 3] = tileTextureCoordinates + Vector2.one * Static.TextureScale;
				}
			}
		}
		if (/*Application.isEditor && */!Application.isPlaying)
			meshFilter.sharedMesh.uv = textureCoordinates;
		else
			meshFilter.mesh.uv = textureCoordinates;
	}
}
