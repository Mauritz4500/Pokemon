using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
	public Tile[,] Tiles { get; set; }
	Vector2i size;
	public Vector2i Size { get { return size; } }

	public Layer(Vector2i size)
	{
		Tiles = new Tile[size.x, size.y];
		this.size = size;
		//<Test code>
		for (int x = 0; x < size.x; x += 2)
		{
			for (int y = x & 1; y < size.y; y += 2)
			{
				Tiles[x, y] = TileRegistry.Tiles[0];
			}
		}
		// </Test code>
	}

	public Layer(string filename)
	{
		byte[] data = System.IO.File.ReadAllBytes(filename);
		size.x = data[0] | data[1] << 8 | data[2] << 16 | data[3] << 24;
		size.y = data[4] | data[5] << 8 | data[6] << 16 | data[7] << 24;
		Tiles = new Tile[size.x, size.y];
		for (int x = 0; x < size.x; x += 2)
			for (int y = x & 1; y < size.y; y += 2)
				Tiles[x, y] = TileRegistry.Tiles[data[((x + y * size.x) << 1) + 8] | data[((x + y * size.x) << 1) + 9] << 8];
	}

	public Tile GetTile(Vector2i position)
	{
		if (position < size == 0 && position >= Vector2i.zero == 0)
			return Tiles[position.x, position.y];
		else
			throw new System.Exception("Tile does not exist: " + position);
	}

	public bool SetTile(Vector2i position, Tile tile)
	{
		if (position < size == 3 && position >= Vector2i.zero == 3)
		{
			Tiles[position.x, position.y] = tile;
			return true;
		}
		else
			return false;
	}

	public void Save(string filename)
	{
		byte[] data = new byte[size.Square * 2 + 8];
		data[0] = (byte)(size.x & 0xFF);
		data[1] = (byte)(size.x >> 8 & 0xFF);
		data[2] = (byte)(size.x >> 16 & 0xFF);
		data[3] = (byte)(size.x >> 24 & 0xFF);
		data[4] = (byte)(size.y & 0xFF);
		data[5] = (byte)(size.y >> 8 & 0xFF);
		data[6] = (byte)(size.y >> 16 & 0xFF);
		data[7] = (byte)(size.y >> 24 & 0xFF);
		for (int x = 0; x < size.x; x += 2)
		{
			for (int y = x & 1; y < size.y; y += 2)
			{
				data[((x + y * size.x) << 1) + 8] = (byte) (Tiles[x, y].ID & 0xFF);
				data[((x + y * size.x) << 1) + 9] = (byte)(Tiles[x, y].ID >> 8 & 0xFF);
			}
		}
		System.IO.File.WriteAllBytes(filename, data);
	}
}
