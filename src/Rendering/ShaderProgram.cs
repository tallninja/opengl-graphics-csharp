/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using OpenTK.Graphics.OpenGL;
using Rendering.Exceptions;
using Utils;

namespace Rendering;

public sealed class ShaderProgram : IDisposable
{
	private bool _disposed;

	public ShaderProgram(string vertexShaderPath, string fragmentShaderPath) : this()
	{
		CreateVertexShader(vertexShaderPath);
		CreateFragmentShader(fragmentShaderPath);
		LinkShaders();
	}

	public ShaderProgram()
	{
		ShaderProgramRef = GL.CreateProgram();
		if (ShaderProgramRef == 0)
		{
			throw new ShaderProgramCreationException();
		}
	}

	~ShaderProgram()
	{
		if (!_disposed)
		{
			Console.WriteLine("GPU Memory leak. Did you forget to call Dispose()!");
		}
	}

	public int ShaderProgramRef { get; set; }
	public int VertexShaderRef { get; set; }
	public int FragmentShaderRef { get; set; }

	public void CreateVertexShader(string shader, bool path = true)
	{
		VertexShaderRef = CreateShader(shader, ShaderType.VertexShader, path);
	}

	public void CreateFragmentShader(string shader, bool path = true)
	{
		FragmentShaderRef = CreateShader(shader, ShaderType.FragmentShader, path);
	}

	private int CreateShader(string shader, ShaderType type, bool path = true)
	{
		var shaderSource = path ? ResourceUtils.ReadAllFile(shader) : shader;
		var shaderRef = GL.CreateShader(type);

		if (shaderRef == 0)
		{
			throw new ShaderCreationException();
		}

		GL.ShaderSource(shaderRef, shaderSource);
		GL.CompileShader(shaderRef);

		GL.GetShader(shaderRef, ShaderParameter.CompileStatus, out var success);
		if (success == 0)
		{
			var log = GL.GetShaderInfoLog(shaderRef);
			throw new ShaderCompilationException(type, log);
		}

		GL.AttachShader(ShaderProgramRef, shaderRef);

		return shaderRef;
	}

	public void LinkShaders()
	{
		GL.LinkProgram(ShaderProgramRef);
		GL.GetProgram(ShaderProgramRef, GetProgramParameterName.LinkStatus, out var linkSuccess);
		if (linkSuccess == 0)
		{
			var log = GL.GetProgramInfoLog(ShaderProgramRef);
			throw new ShaderProgramLinkingException(log);
		}

		if (VertexShaderRef != 0)
		{
			GL.DetachShader(ShaderProgramRef, VertexShaderRef);
		}

		if (FragmentShaderRef != 0)
		{
			GL.DetachShader(ShaderProgramRef, FragmentShaderRef);
		}

		GL.ValidateProgram(ShaderProgramRef);
		GL.GetProgram(ShaderProgramRef, GetProgramParameterName.ValidateStatus, out var validateSuccess);
		if (validateSuccess == 0)
		{
			var log = GL.GetProgramInfoLog(ShaderProgramRef);
			throw new ShaderProgramValidationException(log);
		}
	}

	public void Bind()
	{
		GL.UseProgram(ShaderProgramRef);
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);

		if (_disposed) return;
		GL.DetachShader(ShaderProgramRef, VertexShaderRef);
		GL.DetachShader(ShaderProgramRef, FragmentShaderRef);
		GL.DeleteShader(VertexShaderRef);
		GL.DeleteShader(FragmentShaderRef);
		GL.DeleteProgram(ShaderProgramRef);

		_disposed = true;
	}
}