/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using OpenTK.Graphics.OpenGL;

namespace Rendering.Exceptions;

public sealed class ShaderCreationException : Exception
{
	public ShaderCreationException(string message = "Failed to create shader") :
		base(message)
	{
		Console.WriteLine(Message);
	}
}