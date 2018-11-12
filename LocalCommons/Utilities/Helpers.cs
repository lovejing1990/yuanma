using System;
using System.Linq;
using System.Net;

namespace LocalCommons.Utilities
{
    public static class Helpers
    {
		public static float ConvertX(byte[] coords)
		{
			return (float)Math.Round(coords[0] * 0.002f + coords[1] * 0.5f + coords[2] * 128 - 14336, 4,
				MidpointRounding.ToEven);
		}

		public static byte[] ConvertX(float x)
		{
			var coords = new byte[3];
			var temp = x + 14336;
			coords[2] = (byte)(temp / 128f);
			temp -= coords[2] * 128;
			coords[1] = (byte)(temp / 0.5f);
			temp -= coords[1] * 0.5f;
			coords[0] = (byte)(temp * 512);
			return coords;
		}

		public static float ConvertY(byte[] coords)
		{
			return (float)Math.Round(coords[0] * 0.002f + coords[1] * 0.5f + coords[2] * 128 - 3072, 4,
				MidpointRounding.ToEven);
		}

		public static byte[] ConvertY(float y)
		{
			var coords = new byte[3];
			var temp = y + 3072;
			coords[2] = (byte)(temp / 128);
			temp -= coords[2] * 128;
			coords[1] = (byte)(temp / 0.5f);
			temp -= coords[1] * 0.5f;
			coords[0] = (byte)(temp * 512);
			return coords;
		}

		public static float ConvertZ(byte[] coords)
		{
			return (float)Math.Round(coords[0] * 0.001f + coords[1] * 0.2561f + coords[2] * 65.5625f - 100, 4,
				MidpointRounding.ToEven);
		}

		public static byte[] ConvertZ(float z)
		{
			var coords = new byte[3];
			var temp = z + 100;
			coords[2] = (byte)(temp / 65.5625f);
			temp -= coords[2] * 65.5625f;
			coords[1] = (byte)(temp / 0.2561);
			temp -= coords[1] * 0.2561f;
			coords[0] = (byte)(temp / 0.001);
			return coords;
		}

		public static float ConvertLongX(long x)
		{
			return ((x >> 32) / 4096f) - 14336;
		}

		public static long ConvertLongX(float x)
		{
			return ((long)((x + 14336) * 4096)) << 32;
		}

		public static float ConvertLongY(long y)
		{
			return ((y >> 32) / 4096f) - 3072;
		}

		public static long ConvertLongY(float y)
		{
			return ((long)((y + 3072) * 4096)) << 32;
		}

		public static short ConvertRotation(sbyte rotation)
		{
			return (short)(rotation * 0.0078740157f / 0.000030518509f);
		}

		public static sbyte ConvertRotation(short rotation)
		{
			return (sbyte)(rotation * 0.000030518509f / 0.0078740157f);
		}

		public static byte[] ConvertIP(string ip)
		{
			return IPAddress.Parse(ip).GetAddressBytes();
		}

		public static string ConvertIP(byte[] ip)
		{
			return new IPAddress(ip).ToString();
		}

		/// <summary>
		/// generate a cookie
		/// </summary>
		/// <returns></returns>
		public static int Cookie()
		{
			var random = new Random();
			var cookie = random.Next(255);
			cookie += random.Next(255) << 8;
			cookie += random.Next(255) << 16;
			cookie += random.Next(255) << 24;
			return cookie;
		}
	}
}
