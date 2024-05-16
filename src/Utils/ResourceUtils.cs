/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using System.Net.Mime;
using System.Reflection;

namespace Utils;

public static class ResourceUtils
{
	public static string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
	public static string RootDirectory = CurrentDirectory[..CurrentDirectory.IndexOf("/src/", StringComparison.Ordinal)];
	public static string ResourcesDirectory = RootDirectory + "/src/Resources/";

	public static StreamReader ReadFile(string filePath)
	{
		var absolutePath = GetAbsoluteFilePath(filePath);
		var fileStreamReader = File.OpenText(absolutePath);
		return fileStreamReader;
	}

	public static string ReadAllFile(string filePath)
	{
		var absolutePath = GetAbsoluteFilePath(filePath);
		using var file = File.OpenText(absolutePath);
		return file.ReadToEnd();
	}

	private static string GetAbsoluteFilePath(String filePath)
	{
		var absolutePath = ResourcesDirectory + filePath;
		if (!File.Exists(absolutePath))
		{
			throw new FileNotFoundException();
		}

		return absolutePath;
	}
}