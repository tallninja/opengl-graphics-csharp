/*
 * Author: Ernest Wambua
 * Email: ernestwambua2@gmail.com
 * GitHub: https://github.com/tallninja
 */

using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Rendering;

public class BaseWindow : GameWindow
{
	public BaseWindow(string title, int width, int height, Color4 bgColor)
		: base(
			GameWindowSettings.Default,
			new NativeWindowSettings
			{
				Title = title,
				ClientSize = new Vector2i(width, height)
			})
	{
		Title = title;
		Width = width;
		Height = height;
		BgColor = bgColor;
	}

	public BaseWindow(string title, int width, int height)
		: this(title, width, height, Color4.Black)
	{
	}

	public BaseWindow(int width, int height, Color4 bgColor)
		: this("OpenGL Window", width, height, bgColor)
	{
	}

	public BaseWindow(int width, int height)
		: this(width, height, Color4.Black)
	{
	}

	public new string Title { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public Color4 BgColor { get; set; }

	protected override void OnLoad()
	{
		base.OnLoad();
		GL.ClearColor(BgColor);
	}

	protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
	{
		base.OnFramebufferResize(e);
		GL.Viewport(0, 0, Width, Height);
	}
}