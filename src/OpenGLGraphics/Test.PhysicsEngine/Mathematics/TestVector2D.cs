/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: tallninja
 */

using PhysicsEngine.Mathematics;
using Xunit.Abstractions;

namespace Test.PhysicsEngine.Mathematics;

public class TestVector2D
{
	private readonly ITestOutputHelper _testOutputHelper;

	public TestVector2D(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void Test_Initialization()
	{
		var vec0 = new Vector2D();
		Assert.Equal(0, vec0.X);
		Assert.Equal(0, vec0.Y);

		var vec1 = new Vector2D(10);
		Assert.Equal(10, vec1.X);
		Assert.Equal(10, vec1.Y);

		var vec2 = new Vector2D(5, 10);
		Assert.Equal(5, vec2.X);
		Assert.Equal(10, vec2.Y);
	}

	[Fact]
	public void Test_Initialization_Using_Indexer()
	{
		var vec = new Vector2D
		{
			[0] = 3,
			[1] = 4
		};

		Assert.Throws<IndexOutOfRangeException>(() => vec[2] = 5);
		Assert.Throws<IndexOutOfRangeException>(() => vec[2]);
		Assert.Equal(3, vec[0]);
		Assert.Equal(4, vec[1]);
	}

	[Fact]
	public void Test_Deconstructor()
	{
		var vec = new Vector2D(3, 4);
		var (x, y) = vec;
		Assert.Equal(3, x);
		Assert.Equal(4, y);
	}

	[Fact]
	public void Test_Norm()
	{
		var vec0 = new Vector2D(3, 4);
		Assert.Equal(5, vec0.Norm);

		var vec1 = new Vector2D(-3, -4);
		Assert.Equal(5, vec1.Norm);
	}

	[Fact]
	public void Test_NormSquared()
	{
		var vec = new Vector2D(3, 4);
		Assert.Equal(25, vec.NormSquared);
	}

	[Fact]
	public void Test_Dot_Product()
	{
		var vec0 = new Vector2D(1, 2);
		var vec1 = new Vector2D(3, 4);
		var result = vec0.Dot(vec1);
		Assert.Equal(11, result);
	}

	[Fact]
	public void Test_Addition_Of_Scalar_To_Vector()
	{
		var vec = new Vector2D(3, 4);
		var result = vec + 2;
		Assert.Equal(5, result.X);
		Assert.Equal(6, result.Y);
	}

	[Fact]
	public void Test_Subtraction_Of_Scalar_To_Vector()
	{
		var vec = new Vector2D(3, 4);
		var result = vec - 2;
		Assert.Equal(1, result.X);
		Assert.Equal(2, result.Y);
	}

	[Fact]
	public void Test_Scaling_Of_Vector()
	{
		var vec = new Vector2D(3, 4);
		var result = vec * 2;
		Assert.Equal(6, result.X);
		Assert.Equal(8, result.Y);
	}

	[Fact]
	public void Test_Addition_Of_Two_Vectors()
	{
		var vec0 = new Vector2D(1, 2);
		var vec1 = new Vector2D(3, 4);
		var result = vec0 + vec1;
		Assert.Equal(4, result.X);
		Assert.Equal(6, result.Y);
	}

	[Fact]
	public void Test_Subtraction_Of_Two_Vectors()
	{
		var vec0 = new Vector2D(1, 2);
		var vec1 = new Vector2D(4, 3);
		var result = vec0 - vec1;
		Assert.Equal(-3, result.X);
		Assert.Equal(-1, result.Y);
	}

	[Fact]
	public void Test_Equality_Of_Two_Vectors()
	{
		var vec0 = new Vector2D(3, 4);
		var vec1 = new Vector2D(3, 4);
		Assert.True(vec0 == vec1);
		Assert.True(vec0 >= vec1);
		Assert.True(vec0 <= vec1);

		var vec2 = new Vector2D(1, 2);
		var vec3 = new Vector2D(3, 4);
		Assert.False(vec2 == vec3);

		var vec4 = new Vector2D(1, 2);
		var vec5 = new Vector2D(3, 4);
		Assert.True(vec5 > vec4);
		Assert.True(vec5 >= vec4);
		Assert.False(vec5 < vec4);
		Assert.False(vec5 <= vec4);
	}

	[Fact]
	public void TestToString()
	{
		var vec = new Vector2D(3, 4);
		_testOutputHelper.WriteLine($"{vec}");
	}

	[Fact]
	public void Test_Equals()
	{
		var vec0 = new Vector2D(3, 4);
		var vec1 = new Vector2D(3, 4);
		Assert.True(vec0.Equals(vec1));
	}

	[Fact]
	public void Test_Equality_Precision()
	{
		var vec0 = new Vector2D(3.33332f, 4.44443f);
		var vec1 = new Vector2D(3.33336f, 4.44447f);
		Assert.True(vec0.Equals(vec1));

		var vec2 = new Vector2D(3.33332f, 4.44443f);
		var vec3 = new Vector2D(3.33338f, 4.44449f);
		Assert.False(vec2.Equals(vec3));
	}
}