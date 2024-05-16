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

public class TestWindow1 : BaseWindow
{
	public TestWindow1() : base(800, 600, Color4.Aqua)
	{}

	protected override void OnLoad()
	{
		base.OnLoad();
	}

	protected override void OnUpdateFrame(FrameEventArgs args)
	{
		base.OnUpdateFrame(args);
	}

	protected override void OnRenderFrame(FrameEventArgs args)
	{
		base.OnRenderFrame(args);
		GL.Clear(ClearBufferMask.ColorBufferBit);
		SwapBuffers(); // important
	}
}