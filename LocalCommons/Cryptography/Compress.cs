using System;

namespace LocalCommons.Cryptography
{
	public class Compress
	{
		/// <summary>
		/// 解压缩
		/// </summary>
		/// <param name="inBytes"></param>
		/// <returns></returns>
		public static byte[] ByteInflater(byte[] inBytes)
		{
			java.util.zip.Inflater inf = new java.util.zip.Inflater(true);
			inf.setInput(ByteToSbyte(inBytes), 2, inBytes.Length - 2);
			sbyte[] buffer = new sbyte[32768];
			int count = inf.inflate(buffer);
			byte[] outBuffer = new byte[count];
			Array.Copy(SbyteToByte(buffer), outBuffer, count);
			return outBuffer;
		}

		/// <summary>
		/// 压缩
		/// </summary>
		/// <param name="inBytes"></param>
		/// <returns></returns>
		public static byte[] BytesDeflater(byte[] inBytes)
		{
			var def = new java.util.zip.Deflater(-1,true);
			sbyte[] mySByte = ByteToSbyte(inBytes);

			def.setInput(mySByte, 0, mySByte.Length);
			def.finish();
			sbyte[] buffer = new sbyte[32768];

			int count = def.deflate(buffer);
			byte[] outBuffer = new byte[count];
			Array.Copy(SbyteToByte(buffer), outBuffer, count);

			return outBuffer;
		}

		public static sbyte[] ByteToSbyte(byte[] inBytes)
		{
			return Array.ConvertAll(inBytes, (a) => (sbyte)a);
		}

		public static byte[] SbyteToByte(sbyte[] inSbytes)
		{
			return Array.ConvertAll(inSbytes, (a) => (byte)a);
		}
	}
}
