/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using OpenTK.Graphics.OpenGL;

namespace Rendering.Exceptions;

public sealed class ShaderCompilationException : Exception
{
	public ShaderCompilationException(ShaderType type, string log = "")
		: base($"Failed to compile {type} shader. {log}")
	{
		Console.WriteLine(Message);
	}
}