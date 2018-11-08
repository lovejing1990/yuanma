using System;
using LocalCommons.Logging;
using LocalCommons.Utilities;

namespace ArcheAgeGame
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				ArcheAgeGame.Instance.Run();
			}
			catch (Exception ex)
			{
				Log.Error("Error on startup: {0}, {1}", ex.GetType().Name, ex.Message);
				CliUtil.Exit(1, true);
			}
		}
	}
}

