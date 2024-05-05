/*
 Author: Ernest Wambua
 Email: ernestwambua2@gmail.com
 GitHub: tallninja
 */

using GameEngine;

namespace OpenGLGraphics;

public class Program
{
	public static void Main()
	{
		using var engine = new Engine("Test Window", 800, 600);
		engine.Run();
	}
}