/*
 Author: Ernest Wambua
 Email: ernestwambua2@gmail.com
 GitHub: tallninja
 */

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace GameEngine;

public class Engine : GameWindow
{
	public Engine(string title, int width, int height)
		: base(
			GameWindowSettings.Default,
			new NativeWindowSettings
			{
				Title = title,
				ClientSize = new Vector2i(width, height),
				WindowBorder = WindowBorder.Fixed,
				Vsync = VSyncMode.Adaptive
			})
	{
	}
}