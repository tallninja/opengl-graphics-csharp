/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: tallninja
 */

namespace PhysicsEngine.Mathematics;

public class Vector2D
{
	public Vector2D() : this(0, 0)
	{
	}

	public Vector2D(float value) : this(value, value)
	{
	}

	public Vector2D(float x, float y)
	{
		X = x;
		Y = y;
	}

	public float X { get; set; }
	public float Y { get; set; }

	public float this[float index]
	{
		get
		{
			return index switch
			{
				0 => X,
				1 => Y,
				_ => throw new IndexOutOfRangeException()
			};
		}
		set
		{
			switch (index)
			{
				case 0:
					X = value;
					break;
				case 1:
					Y = value;
					break;
				default:
					throw new IndexOutOfRangeException();
			}
		}
	}

	public double Norm => Math.Sqrt(X * X + Y * Y);

	public double NormSquared => X * X + Y * Y;

	public double Dot(Vector2D other) => X * other.X + Y * other.Y;

	public Vector2D Normalize()
	{
		return this / (float) Norm;
	}

	public static Vector2D operator + (Vector2D left, float right)
	{
		return new Vector2D
		{
			X = left.X + right,
			Y = left.Y + right
		};
	}

	public static Vector2D operator - (Vector2D left, float right)
	{
		return new Vector2D
		{
			X = left.X - right,
			Y = left.Y - right
		};
	}

	public static Vector2D operator *(Vector2D left, float right)
	{
		return new Vector2D
		{
			X = left.X * right,
			Y = left.Y * right
		};
	}

	public static Vector2D operator /(Vector2D left, float right)
	{
		return new Vector2D
		{
			X = left.X / right,
			Y = left.Y / right
		};
	}

	public static Vector2D operator + (Vector2D left, Vector2D right)
	{
		return new Vector2D
		{
			X = left.X + right.X,
			Y = left.Y + right.Y
		};
	}

	public static Vector2D operator - (Vector2D left, Vector2D right)
	{
		return new Vector2D
		{
			X = left.X - right.X,
			Y = left.Y - right.Y
		};
	}

	public static bool operator == (Vector2D left, Vector2D right)
	{
		return left.Equals(right);
	}

	public static bool operator != (Vector2D left, Vector2D right)
	{
		return !left.Equals(right);
	}

	public static bool operator > (Vector2D left, Vector2D right)
	{
		return left.Norm > right.Norm;
	}

	public static bool operator < (Vector2D left, Vector2D right)
	{
		return left.Norm < right.Norm;
	}

	public static bool operator >= (Vector2D left, Vector2D right)
	{
		return left.Norm >= right.Norm;
	}

	public static bool operator <= (Vector2D left, Vector2D right)
	{
		return left.Norm <= right.Norm;
	}

	public void Deconstruct(out float x, out float y)
	{
		x = X;
		y = Y;
	}

	public override string ToString()
	{
		return $"Vector2D {{ X = {X}, Y = {Y} }}";
	}

	public override bool Equals(object? obj)
	{
		return obj is Vector2D other && Equals(other);
	}

	public bool Equals(Vector2D other)
	{
		const double precision = 0.00005;
		return Math.Abs(X - other.X) <= precision && Math.Abs(Y - other.Y) <= precision;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}
}