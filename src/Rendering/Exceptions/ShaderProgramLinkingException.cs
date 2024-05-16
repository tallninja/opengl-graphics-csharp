/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

namespace Rendering.Exceptions;

public sealed class ShaderProgramLinkingException : Exception
{
	public ShaderProgramLinkingException(string log = "")
		: base($"Error linking shader programs. {log}")
	{
		Console.WriteLine(Message);
	}
}