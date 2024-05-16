/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

namespace Rendering.Exceptions;

public sealed class ShaderProgramValidationException : Exception
{
	public ShaderProgramValidationException(string log = "")
		: base($"Error validating shader program. {log}")
	{

	}
}