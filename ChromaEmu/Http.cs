using System;

namespace ChromaEmu
{
	public class Http
	{
		public static void Start()
		{
			Http.server = new SimpleHTTPServer(AppDomain.CurrentDomain.BaseDirectory + "html", 80);
		}

		public static void Stop()
		{
			Http.server.Stop();
		}

		private static SimpleHTTPServer server;
	}
}
