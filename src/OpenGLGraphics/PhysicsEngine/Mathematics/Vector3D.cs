/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: tallninja
 */

namespace PhysicsEngine.Mathematics;

public class Vector3D
{
	public Vector3D() : this(0, 0, 0)
	{
	}

	public Vector3D(float value) : this(value, value, value)
	{
	}

	public Vector3D(float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public float X { get; set; }
	public float Y { get; set; }
	public float Z { get; set; }

	public float this[float index]
	{
		get
		{
			return index switch
			{
				0 => X,
				1 => Y,
				2 => Z,
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
				case 2:
					Z = value;
					break;
				default:
					throw new IndexOutOfRangeException();
			}
		}
	}

	public double NormSquared => X * X + Y * Y + Z * Z;

	public double Norm => Math.Sqrt(X * X + Y * Y + Z * Z);

	public double Dot(Vector3D other) => (X * other.X) + (Y * other.Y) + (Z * other.Z);

	public Vector3D Cross(Vector3D other)
	{
		var rx = Y * other.Z - Z * other.Y;
		var ry = Z * other.X - X * other.Z;
		var rz = X * other.Y - Y * other.X;
		return new Vector3D(rx, ry, rz);
	}

	public static Vector3D operator +(Vector3D left, Vector3D right)
	{
		return new Vector3D
		{
			X = left.X + right.X,
			Y = left.Y + right.Y,
			Z = left.Z + right.Z
		};
	}

	public static Vector3D operator -(Vector3D left, Vector3D right)
	{
		return new Vector3D
		{
			X = left.X - right.X,
			Y = left.Y - right.Y,
			Z = left.Z - right.Z
		};
	}

	public static Vector3D operator +(Vector3D left, float right)
	{
		return new Vector3D
		{
			X = left.X + right,
			Y = left.Y + right,
			Z = left.Z + right
		};
	}

	public static Vector3D operator -(Vector3D left, float right)
	{
		return new Vector3D
		{
			X = left.X - right,
			Y = left.Y - right,
			Z = left.Z - right
		};
	}

	public static Vector3D operator *(Vector3D left, float right)
	{
		return new Vector3D
		{
			X = left.X * right,
			Y = left.Y * right,
			Z = left.Z * right
		};
	}

	public static Vector3D operator /(Vector3D left, float right)
	{
		return new Vector3D
		{
			X = left.X / right,
			Y = left.Y / right,
			Z = left.Z / right
		};
	}

	public static bool operator ==(Vector3D left, Vector3D right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Vector3D left, Vector3D right)
	{
		return !left.Equals(right);
	}

	public static bool operator >(Vector3D left, Vector3D right)
	{
		return left.Norm > right.Norm;
	}

	public static bool operator <(Vector3D left, Vector3D right)
	{
		return left.Norm < right.Norm;
	}

	public static bool operator >=(Vector3D left, Vector3D right)
	{
		return left.Norm >= right.Norm;
	}

	public static bool operator <=(Vector3D left, Vector3D right)
	{
		return left.Norm <= right.Norm;
	}

	public void Deconstruct(out float x, out float y, out float z)
	{
		x = X;
		y = Y;
		z = Z;
	}

	public override string ToString()
	{
		return $"Vector3D {{ X = {X}, Y = {Y}, Z = {Z} }}";
	}

	public override bool Equals(object? obj)
	{
		return obj is Vector3D other && Equals(other);
	}

	public bool Equals(Vector3D other)
	{
		const double precision = 0.00005;
		return Math.Abs(X - other.X) <= precision
		       && Math.Abs(Y - other.Y) <= precision
		       && Math.Abs(Z - other.Z) <= precision;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y, Z);
	}
}