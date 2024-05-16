/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
// ReSharper disable RedundantOverriddenMember

namespace Rendering;

public class TestWindow2 : BaseWindow
{
	private int _vbo, _vao;
	private ShaderProgram _shaderProgram;

	public TestWindow2()
		: base(800, 600)
	{
	}

	protected override void OnLoad()
	{
		base.OnLoad();
		GL.ClearColor(Color4.Turquoise);

		float[] vertices =
		[
			0.0f,  0.5f, 0.0f,
			-0.5f, -0.5f, 0.0f,
			0.5f, -0.5f, 0.0f,
		];

		_vbo = GL.GenBuffer();
		GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
		GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

		_vao = GL.GenVertexArray();
		GL.BindVertexArray(_vao);
		GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
		GL.EnableVertexAttribArray(0);

		_shaderProgram = new ShaderProgram("Shaders/Test1.vert", "Shaders/Test1.frag");

	}

	protected override void OnUpdateFrame(FrameEventArgs args)
	{
		base.OnUpdateFrame(args);
		_shaderProgram.Bind();
	}

	protected override void OnRenderFrame(FrameEventArgs args)
	{
		base.OnRenderFrame(args);
		GL.Clear(ClearBufferMask.ColorBufferBit);

		GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

		SwapBuffers();
	}

	public override void Dispose()
	{
		base.Dispose();
		_shaderProgram.Dispose();
		GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
		GL.DeleteBuffer(_vbo);
	}
}