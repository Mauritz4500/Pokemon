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

	/// <summary>
	/// Component-wise multiplication
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
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

	/// <summary>
	/// Returns a byte, bit 0 for x, bit 1 for y
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static byte operator >(Vector2i a, Vector2i b)
	{
		return (byte)((a.x > b.x ? 1 : 0) | (a.y > b.y ? 2 : 0));
	}

	/// <summary>
	/// Returns a byte, bit 0 for x, bit 1 for y
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static byte operator <(Vector2i a, Vector2i b)
	{
		return (byte)((a.x < b.x ? 1 : 0) | (a.y < b.y ? 2 : 0));
	}

	/// <summary>
	/// Returns a byte, bit 0 for x, bit 1 for y
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static byte operator >=(Vector2i a, Vector2i b)
	{
		return (byte)((a.x >= b.x ? 1 : 0) | (a.y >= b.y ? 2 : 0));
	}

	/// <summary>
	/// Returns a byte, bit 0 for x, bit 1 for y
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns></returns>
	public static byte operator <=(Vector2i a, Vector2i b)
	{
		return (byte)((a.x <= b.x ? 1 : 0) | (a.y <= b.y ? 2 : 0));
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

	/// <summary>
	/// Returns the size of a square with the corners [0,0] and [x,y]
	/// </summary>
	public int Square { get { return x * y; } }

	/// <summary>
	/// Returns the length of the vector
	/// </summary>
	public float Length { get { return Mathf.Sqrt(x * x + y * y); } }

	/// <summary>
	/// Returns the square of the length of the vector. Much faster than Length because it doesn't take the square root. Useful for length comparisons.
	/// </summary>
	public float LengthSquared { get { return x * x + y * y; } }

	public override string ToString()
	{
		return string.Format("{0} {1}", x, y);
	}
}
