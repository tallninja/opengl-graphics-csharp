/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: tallninja
 */

using PhysicsEngine.Mathematics;
using Xunit.Abstractions;

namespace Test.PhysicsEngine.Mathematics;

public class TestVector3D
{
	private readonly ITestOutputHelper _testOutputHelper;

	public TestVector3D(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void Test_Initialization()
	{
		var vec0 = new Vector3D();
		Assert.Equal(0, vec0.X);
		Assert.Equal(0, vec0.Y);
		Assert.Equal(0, vec0.Z);

		var vec1 = new Vector3D(10);
		Assert.Equal(10, vec1.X);
		Assert.Equal(10, vec1.Y);
		Assert.Equal(10, vec1.Z);

		var vec2 = new Vector3D(5, 10, 15);
		Assert.Equal(5, vec2.X);
		Assert.Equal(10, vec2.Y);
		Assert.Equal(15, vec2.Z);
	}

	[Fact]
	public void Test_Initialization_Using_Indexer()
	{
		var vec = new Vector3D
		{
			[0] = 3,
			[1] = 4,
			[2] = 5
		};

		Assert.Throws<IndexOutOfRangeException>(() => vec[3] = 6);
		Assert.Throws<IndexOutOfRangeException>(() => vec[3]);
		Assert.Equal(3, vec[0]);
		Assert.Equal(4, vec[1]);
		Assert.Equal(5, vec[2]);
	}

	[Fact]
	public void Test_Deconstructor()
	{
		var vec = new Vector3D(3, 4, 5);
		var (x, y, z) = vec;
		Assert.Equal(3, x);
		Assert.Equal(4, y);
		Assert.Equal(5, z);
	}

	[Fact]
	public void Test_Norm()
	{
		var vec0 = new Vector3D(3, 4, 5);
		Assert.Equal(Math.Sqrt(9 + 16 + 25), vec0.Norm);

		var vec1 = new Vector3D(-3, -4, 5);
		Assert.Equal(Math.Sqrt(9 + 16 + 25), vec1.Norm);
	}

	[Fact]
	public void Test_NormSquared()
	{
		var vec = new Vector3D(3, 4, 5);
		Assert.Equal(50, vec.NormSquared);
	}

	[Fact]
	public void Test_Dot_Product()
	{
		var vec0 = new Vector3D(1, 2, 3);
		var vec1 = new Vector3D(4, 5, 6);
		var result = vec0.Dot(vec1);
		Assert.Equal(32, result);
	}

	[Fact]
	public void Test_Cross_Product()
	{
		var vec0 = new Vector3D(1, 2, 3);
		var vec1 = new Vector3D(4, 5, 6);
		var result = vec0.Cross(vec1);
		Assert.Equal(new Vector3D(-3, 6, -3), result);
	}

	[Fact]
	public void Test_Normalization()
	{
		var vec = new Vector3D(3, 4, 5);
		var result = vec.Normalize();
		Assert.Equal(new Vector3D(0.42426f, 0.56568f, 0.70710f), result);
	}

	[Fact]
	public void Test_Addition_Of_Scalar_To_Vector()
	{
		var vec = new Vector3D(3, 4, 5);
		var result = vec + 2;
		Assert.Equal(5, result.X);
		Assert.Equal(6, result.Y);
		Assert.Equal(7, result.Z);
	}

	[Fact]
	public void Test_Subtraction_Of_Scalar_To_Vector()
	{
		var vec = new Vector3D(3, 4, 5);
		var result = vec - 2;
		Assert.Equal(1, result.X);
		Assert.Equal(2, result.Y);
		Assert.Equal(3, result.Z);
	}

	[Fact]
	public void Test_Scaling_Of_Vector()
	{
		var vec = new Vector3D(4, 6, 8);
		var res1 = vec * 2;
		Assert.Equal(8, res1.X);
		Assert.Equal(12, res1.Y);
		Assert.Equal(16, res1.Z);

		var res2 = vec / 2;
		Assert.Equal(2, res2.X);
		Assert.Equal(3, res2.Y);
		Assert.Equal(4, res2.Z);
	}

	[Fact]
	public void Test_Addition_Of_Two_Vectors()
	{
		var vec0 = new Vector3D(1, 2, 3);
		var vec1 = new Vector3D(4, 5, 6);
		var result = vec0 + vec1;
		Assert.Equal(5, result.X);
		Assert.Equal(7, result.Y);
		Assert.Equal(9, result.Z);
	}

	[Fact]
	public void Test_Subtraction_Of_Two_Vectors()
	{
		var vec0 = new Vector3D(1, 2, 3);
		var vec1 = new Vector3D(2, 4, 6);
		var result = vec0 - vec1;
		Assert.Equal(-1, result.X);
		Assert.Equal(-2, result.Y);
		Assert.Equal(-3, result.Z);
	}

	[Fact]
	public void Test_Equality_Of_Two_Vectors()
	{
		var vec0 = new Vector3D(3, 4, 5);
		var vec1 = new Vector3D(3, 4, 5);
		Assert.True(vec0 == vec1);
		Assert.True(vec0 >= vec1);
		Assert.True(vec0 <= vec1);

		var vec2 = new Vector3D(1, 2, 3);
		var vec3 = new Vector3D(4, 5, 6);
		Assert.False(vec2 == vec3);

		var vec4 = new Vector3D(1, 2, 3);
		var vec5 = new Vector3D(4, 5, 6);
		Assert.True(vec5 > vec4);
		Assert.True(vec5 >= vec4);
		Assert.False(vec5 < vec4);
		Assert.False(vec5 <= vec4);
	}

	[Fact]
	public void TestToString()
	{
		var vec = new Vector3D(3, 4, 5);
		_testOutputHelper.WriteLine($"{vec}");
	}

	[Fact]
	public void Test_Equals()
	{
		var vec0 = new Vector3D(3, 4, 5);
		var vec1 = new Vector3D(3, 4, 5);
		Assert.True(vec0.Equals(vec1));
	}

	[Fact]
	public void Test_Equality_Precision()
	{
		var vec0 = new Vector3D(3.33332f, 4.44443f, 5.55554f);
		var vec1 = new Vector3D(3.33336f, 4.44447f, 5.55558f);
		Assert.True(vec0.Equals(vec1));

		var vec2 = new Vector3D(3.33332f, 4.44443f, 5.55554f);
		var vec3 = new Vector3D(3.33338f, 4.44449f, 5.55559f);
		Assert.False(vec2.Equals(vec3));
	}
}