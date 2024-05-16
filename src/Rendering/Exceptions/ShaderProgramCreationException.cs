/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

namespace Rendering.Exceptions;

public sealed class ShaderProgramCreationException : Exception
{
	public ShaderProgramCreationException()
		: base("Error creating shader program")
	{
		// TODO: Use custom logger implementation instead of System.Console
		Console.WriteLine(Message);
	}
}