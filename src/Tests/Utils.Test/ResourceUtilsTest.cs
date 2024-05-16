/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using Xunit.Abstractions;

namespace Utils.Test;

public class ResourceUtilsTest
{
	private readonly ITestOutputHelper _testOutput;

	public ResourceUtilsTest(ITestOutputHelper testOutputHelper)
	{
		_testOutput = testOutputHelper;
	}

	[Fact]
	public void TestCurrentDirectory()
	{
		_testOutput.WriteLine(ResourceUtils.CurrentDirectory);
	}

	[Fact]
	public void TestRootDirectory()
	{
		_testOutput.WriteLine(ResourceUtils.RootDirectory);
	}

	[Fact]
	public void TestResourcesDirectory()
	{
		_testOutput.WriteLine(ResourceUtils.ResourcesDirectory);
	}

	[Fact]
	public void TestReadAllFile()
	{
		var fileContents = ResourceUtils.ReadAllFile("test.txt");
		Assert.Equal("Hello, World!", fileContents);
		_testOutput.WriteLine(fileContents);
	}
}