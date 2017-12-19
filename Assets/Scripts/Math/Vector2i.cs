using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct Vector2i
{
	public static readonly Vector2i zero = new Vector2i(0, 0), right = new Vector2i(1, 0), left = new Vector2i(-1, 0), up = new Vector2i(0, 1), down = new Vector2i(0, -1);
	public int x, y;

	public Vector2i(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	
	public Vector2i(float x, float y)
	{
		this.x = (int)x;
		this.y = (int)y;
	}

	public Vector2i(Vector2 vector)
	{
		this.x = (int)vector.x;
		this.y = (int)vector.y;
	}
	
	public static Vector2i operator +(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x + b.x, a.y + b.y);
	}

	public static Vector2i operator -(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x - b.x, a.y - b.y);
	}

	public static Vector2i operator *(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x * b.x, a.y * b.y);
	}

	public static Vector2i operator *(Vector2i a, int b)
	{
		return new Vector2i(a.x * b, a.y * b);
	}

	public static Vector2i operator *(Vector2i a, float b)
	{
		return new Vector2i((int)(a.x * b), (int)(a.y * b));
	}

	public static Vector2i operator /(Vector2i a, Vector2i b)
	{
		return new Vector2i(a.x / b.x, a.y / b.y);
	}

	public static Vector2i operator &(Vector2i a, int b)
	{
		return new Vector2i(a.x & b, a.y & b);
	}

	public static Vector2i operator |(Vector2i a, int b)
	{
		return new Vector2i(a.x | b, a.y | b);
	}

	public static Vector2i operator >>(Vector2i a, int b)
	{
		return new Vector2i(a.x >> b, a.y >> b);
	}

	public static Vector2i operator <<(Vector2i a, int b)
	{
		return new Vector2i(a.x << b, a.y << b);
	}

	public static bool operator ==(Vector2i a, Vector2i b)
	{
		return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=(Vector2i a, Vector2i b)
	{
		return !(a.x == b.x && a.y == b.y);
	}

	public static implicit operator Vector2(Vector2i value)
	{
		return new Vector2(value.x, value.y);
	}

	public static explicit operator Vector2i(Vector2 value)
	{
		return new Vector2i((int)value.x, (int)value.y);
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", x, y);
	}
}
