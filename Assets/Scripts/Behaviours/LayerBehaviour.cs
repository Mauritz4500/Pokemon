using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LayerBehaviour : MonoBehaviour
{
	public Layer Layer { get; set; }
	public World World { get; set; }
	public float TextureScale { get; set; }
	MeshFilter meshFilter;

	void Start()
	{
		meshFilter = GetComponent<MeshFilter>();
		Layer = new Layer(new Vector2i(100, 100)); //Test code
		TextureScale = 0.25F; //Test code
		InitalizeMesh();
		Render();
	}

	int i = 0;
	void Update()
	{
		i++; //Test code
		if (i == 60)
		{
			Render();
			i = 0;
		} // /Test code
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
				vertices[(x + sizeX * y) * 4] = new Vector3(x, 0, y);
				vertices[(x + sizeX * y) * 4 + 1] = new Vector3(x + 1, 0, y);
				vertices[(x + sizeX * y) * 4 + 2] = new Vector3(x, 0, y + 1);
				vertices[(x + sizeX * y) * 4 + 3] = new Vector3(x + 1, 0, y + 1);
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

	void Render()
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
					Vector2 tileTextureCoordinates = (Vector2)Layer.Tiles[x, y].TextureCoordinates(position, Layer, World) * TextureScale;
					textureCoordinates[(x + sizeX * y) * 4] = tileTextureCoordinates;
					textureCoordinates[(x + sizeX * y) * 4 + 1] = tileTextureCoordinates + Vector2.right * TextureScale;
					textureCoordinates[(x + sizeX * y) * 4 + 2] = tileTextureCoordinates + Vector2.up * TextureScale;
					textureCoordinates[(x + sizeX * y) * 4 + 3] = tileTextureCoordinates + Vector2.one * TextureScale;
				}
			}
		}
		if (/*Application.isEditor && */!Application.isPlaying)
			meshFilter.sharedMesh.uv = textureCoordinates;
		else
			meshFilter.mesh.uv = textureCoordinates;
	}
}
