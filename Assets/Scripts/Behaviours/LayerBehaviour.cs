using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerBehaviour : MonoBehaviour
{
	public Layer Layer { get; set; }

	void Start()
	{

	}

	void Update()
	{

	}

	void Render()
	{
		int sizeX = Layer.Size.x, sizeY = Layer.Size.y;
		Vector3[,] vertices = new Vector3[sizeX * 2, sizeY * 2];

		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
			{

			}
		}
		Mesh mesh = new Mesh();
		//mesh.vertices;
	}
}
