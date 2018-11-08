using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LocalCommons.Utilities;

namespace LocalCommons.Network
{
	/// <summary>
	/// Provides functionality for writing primitive binary data.
	/// Author: Raphail
	/// </summary>
	public sealed class PacketWriter : IDisposable
	{
		private static readonly Stack<PacketWriter> MPool = new Stack<PacketWriter>();
		private bool _mLittleEndian;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="capacity">размер в байтах</param>
		/// <param name="littleEndian">порядок байтов от младших к старшим (слева направо)</param>
		/// <returns></returns>
		public static PacketWriter CreateInstance(int capacity = 32, bool littleEndian = false)
		{
			PacketWriter pw = null;
			lock (MPool)
			{
				if (MPool.Count > 0)
				{
					pw = MPool.Pop();

					if (pw != null)
					{
						pw._mCapacity = capacity;
						pw._mStream.SetLength(0);
					}
				}
			}
			if (pw == null)
			{
				pw = new PacketWriter(capacity);
			}

			pw._mLittleEndian = littleEndian;
			return pw;
		}

		/// <summary>
		/// Destructor
		/// </summary>
		/// <param name="pw">указатель на объект PacketWriter</param>
		public static void ReleaseInstance(PacketWriter pw)
		{
			lock (MPool)
			{
				if (!MPool.Contains(pw))
				{
					MPool.Push(pw);
				}
				else
				{
					try
					{
						using (StreamWriter op = new StreamWriter("neterr.log"))
						{
							op.WriteLine("{0}\tInstance pool contains writer", DateTime.Now);
						}
					}
					catch
					{
						Console.WriteLine("net error");
					}
				}
			}
		}

		/// <summary>
		/// Internal stream which holds the entire packet.
		/// </summary>
		private readonly MemoryStream _mStream;
		private int _mCapacity;

		/// <summary>
		/// Internal format buffer.
		/// </summary>
		private static readonly byte[] MBuffer = new byte[4];

		/// <summary>
		/// Instantiates a new PacketWriter instance with the default capacity of 4 bytes.
		/// </summary>
		public PacketWriter() : this(32)
		{
		}

		/// <summary>
		/// Instantiates a new PacketWriter instance with a given capacity.
		/// </summary>
		/// <param name="capacity">Initial capacity for the internal stream.</param>
		private PacketWriter(int capacity)
		{
			this._mStream = new MemoryStream(capacity);
			this._mCapacity = capacity;
		}

		/// <summary>
		/// Writes a 1-byte boolean value to the underlying stream. False is represented by 0, true by 1.
		/// </summary>
		public void Write(bool value)
		{
			this._mStream.WriteByte((byte)(value ? 1 : 0));
		}

		/// <summary>
		/// Writes a 1-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(byte value)
		{
			this._mStream.WriteByte(value);
		}

		/// <summary>
		/// Writes a 1-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(sbyte value)
		{
			this._mStream.WriteByte((byte)value);
		}

		/// <summary>
		/// Writes a 2-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(short value)
		{
			if (this._mLittleEndian)
			{
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[0] = (byte)value;
			}
			else
			{
				MBuffer[0] = (byte)(value >> 8);
				MBuffer[1] = (byte)value;
			}
			this._mStream.Write(MBuffer, 0, 2);
		}

		/// <summary>
		/// Writes a 2-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(ushort value)
		{
			if (this._mLittleEndian)
			{
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[0] = (byte)value;
			}
			else
			{
				MBuffer[0] = (byte)(value >> 8);
				MBuffer[1] = (byte)value;
			}
			this._mStream.Write(MBuffer, 0, 2);
		}

		/// <summary>
		/// Writes a 3-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(Uint24 value)
		{
			if (this._mLittleEndian)
			{
				MBuffer[2] = (byte)(value >> 16);
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[0] = (byte)value;
			}
			else
			{
				MBuffer[0] = (byte)(value >> 16);
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[2] = (byte)value;
			}
			this._mStream.Write(MBuffer, 0, 3);
		}

		/// <summary>
		/// Writes a 4-byte signed integer value to the underlying stream.
		/// </summary>
		public void Write(int value)
		{
			if (this._mLittleEndian)
			{
				MBuffer[3] = (byte)(value >> 24);
				MBuffer[2] = (byte)(value >> 16);
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[0] = (byte)value;
			}
			else
			{
				MBuffer[0] = (byte)(value >> 24);
				MBuffer[1] = (byte)(value >> 16);
				MBuffer[2] = (byte)(value >> 8);
				MBuffer[3] = (byte)value;
			}
			this._mStream.Write(MBuffer, 0, 4);
		}

		/// <summary>
		/// Writes a 4-byte unsigned integer value to the underlying stream.
		/// </summary>
		public void Write(uint value)
		{

			if (this._mLittleEndian)
			{
				MBuffer[3] = (byte)(value >> 24);
				MBuffer[2] = (byte)(value >> 16);
				MBuffer[1] = (byte)(value >> 8);
				MBuffer[0] = (byte)value;
			}
			else
			{
				MBuffer[0] = (byte)(value >> 24);
				MBuffer[1] = (byte)(value >> 16);
				MBuffer[2] = (byte)(value >> 8);
				MBuffer[3] = (byte)value;
			}

			this._mStream.Write(MBuffer, 0, 4);

		}

		public void Writec(float value, Boolean c)
		{
			if (c) { };
			byte[] data = BitConverter.GetBytes(value);
			if (!this._mLittleEndian)
			{
				Array.Reverse(data);
			}

			this._mStream.Write(data, 0, data.Length);
		}

		/// <summary>
		/// Разворачиваем байты LE / BE
		/// </summary>
		/// <param name="value"> float </param>
		/// <param name="le">LE-true, BE-false</param>
		public void WriteLEBE(float value, Boolean le)
		{
			byte[] data = BitConverter.GetBytes(value);
			if (!le)
			{
				Array.Reverse(data);
			}

			this._mStream.Write(data, 0, data.Length);
		}

		public void Write(float value)
		{
			byte[] data = BitConverter.GetBytes(value);
			if (!this._mLittleEndian)
			{
				Array.Reverse(data);
			}

			this._mStream.Write(data, 0, 4);
		}

		public void Write(long value)
		{
			byte[] data = BitConverter.GetBytes(value);
			if (!this._mLittleEndian)
			{
				Array.Reverse(data);
			}

			this._mStream.Write(data, 0, 8);
		}

		/// <summary>
		/// Writes a sequence of bytes to the underlying stream
		/// Пишем массив байт buffer, начиная со смещения offset в этом массива, длиной size, длину не вставляем перед массивом
		/// </summary>
		/// <param name="buffer">указатель на буфер пакета</param>
		/// <param name="offset">смещение в буфере пакета</param>
		/// <param name="size">размер буфера пакета</param>
		public void Write(byte[] buffer, int offset, int size)
		{
			this._mStream.Write(buffer, offset, size);
		}

		/// <summary>
		/// Writes a sequence of bytes to the underlying stream
		/// Пишем массив байт buffer, начиная со смещения offset в этом массива, длиной size подсчитанной из размера буфера,
		/// длину size вставляем перед массивом
		/// Author: NLObP
		/// </summary>
		/// <param name="buffer">указатель на буфер пакета</param>
		/// <param name="offset">смещение в буфере пакета</param>
		public void Write(byte[] buffer, int offset)
		{
			int size = buffer.Length;
			this.Write((short)size);
			this._mStream.Write(buffer, offset, size);
		}

		/// <summary>
		/// Writes a fixed-length ASCII-encoded string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// Записывает строковое значение с фиксированной длиной ASCII в базовый поток. Чтобы соответствовать (размер), содержимое строки либо усекается, либо дополняется нулевыми символами.
		/// Размер не пишем перед строкой
		/// </summary>
		public void WriteASCIIFixedNoSize(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteAsciiFixed() with null value");
				value = String.Empty;
			}
			int length = value.Length;
			this._mStream.SetLength(this._mStream.Length + size);
			if (length >= size)
			{
				this._mStream.Position += Encoding.ASCII.GetBytes(value, 0, size, this._mStream.GetBuffer(), (int)this._mStream.Position);
			}
			else
			{
				Encoding.ASCII.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
				this._mStream.Position += size;
			}
		}

		/// <summary>
		/// Writes a fixed-length ASCII-encoded string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// Записывает строковое значение с фиксированной длиной ASCII в базовый поток. Чтобы соответствовать (размер), содержимое строки либо усекается, либо дополняется нулевыми символами.
		/// Размер пишем перед строкой
		/// </summary>
		public void WriteASCIIFixed(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteAsciiFixed() with null value");
				value = String.Empty;
			}
			int length = value.Length;
			this.Write((short)size);
			this._mStream.SetLength(this._mStream.Length + size);
			if (length >= size)
			{
				this._mStream.Position += Encoding.ASCII.GetBytes(value, 0, size, this._mStream.GetBuffer(), (int)this._mStream.Position);
			}
			else
			{
				Encoding.ASCII.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
				this._mStream.Position += size;
			}
		}

		/// <summary>
		/// Writes a fixed-length UTF-encoded string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// Записывает строковое значение с фиксированной длиной UTF-8 в базовый поток. Чтобы соответствовать (размер), содержимое строки либо усекается, либо дополняется нулевыми символами.
		/// Размер пишем перед строкой
		/// </summary>
		/// <param name="value"></param>
		/// <param name="size"></param>
		public void WriteUTF8Fixed(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteUTF8Fixed() with null value");
				value = String.Empty;
			}
			int length = value.Length;
			this.Write((short)size);
			this._mStream.SetLength(this._mStream.Length + size);
			if (length >= size)
			{
				this._mStream.Position += Encoding.UTF8.GetBytes(value, 0, size, this._mStream.GetBuffer(), (int)this._mStream.Position);
			}
			else
			{
				Encoding.UTF8.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
				this._mStream.Position += size * 3; //зачем умножение на 3?!
			}
		}
		/// <summary>
		/// Записываем строку переведенную из шестнадцатеричного текста в байты, длину не записываем спереди
		/// </summary>
		/// <param name="value"></param>
		public void WriteHex(string value)
		{
			if (value.Length % 2 != 0)
			{
				Console.Write("Network: Attempted to WriteHex() the binary key cannot have an odd number of digits");
				return;
			}
			int length = value.Length / 2;
			this._mStream.SetLength(this._mStream.Length + length);
			byte[] bytes = new byte[value.Length / 2];
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = byte.Parse(value.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
			}
			bytes.CopyTo(this._mStream.GetBuffer(), (int)this._mStream.Position);
			this._mStream.Position += length;
		}
		/// <summary>
		/// Записываем строку переведенную из шестнадцатеричного текста в байты, длину записываем спереди
		/// длина берется из длины строки
		/// </summary>
		/// <param name="value">строка в виде HEX</param>
		/// <param name="size">параметр не используется</param>
		public void WriteHex(string value, int size)
		{
			if (value.Length % 2 != 0)
			{
				Console.Write("Network: Attempted to WriteHex() the binary key cannot have an odd number of digits");
				return;
			}
			if (value.Length / 2 != size / 2)
			{
				Console.WriteLine("Network: Attempted to WriteHex(value, size) with not equ value.Length and size value");
			}
			int length = value.Length / 2;
			this.Write((short)length);
			this._mStream.SetLength(this._mStream.Length + length);
			byte[] bytes = new byte[length];
			for (int i = 0; i < length; i++)
			{
				bytes[i] = byte.Parse(value.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
			}
			bytes.CopyTo(this._mStream.GetBuffer(), (int)this._mStream.Position);
			this._mStream.Position += length;
		}

		/// <summary>
		/// Writes a dynamic-length ASCII-encoded string value to the underlying stream, followed by a 1-byte null character.
		/// </summary>
		public void WriteDynamicASCII(string value)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteAsciiNull() with null value");
				value = String.Empty;
			}
			int length = value.Length;
			this._mStream.SetLength(this._mStream.Length + length + 1);
			Encoding.ASCII.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
			this._mStream.Position += length + 1;
		}

		/// <summary>
		/// Writes a dynamic-length little-endian unicode string value to the underlying stream, followed by a 2-byte null character.
		/// </summary>

		public void WriteDynamicLittleUni(string value)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteLittleUniNull() with null value");
				value = String.Empty;
			}

			int length = value.Length;
			this._mStream.SetLength(this._mStream.Length + ((length + 1) * 2));

			this._mStream.Position += Encoding.Unicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
			this._mStream.Position += 2;
		}

		/// <summary>
		/// Writes a fixed-length little-endian unicode string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// </summary>

		public void WriteFixedLittleEndian(string value, int size)
		{

			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteLittleUniFixed() with null value");
				value = String.Empty;

			}
			size *= 2;

			int length = value.Length;
			this.Write((short)length);
			this._mStream.SetLength(this._mStream.Length + size);

			if ((length * 2) >= size)
			{
				this._mStream.Position += Encoding.Unicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
			}
			else
			{
				Encoding.Unicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
				this._mStream.Position += size;
			}
		}

		/// <summary>
		/// Writes a dynamic-length big-endian unicode string value to the underlying stream, followed by a 2-byte null character.
		/// </summary>
		public void WriteDynamicBigUnicode(string value)
		{

			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteBigUniNull() with null value");
				value = String.Empty;
			}
			int length = value.Length;
			this.Write((short)length);
			this._mStream.SetLength(this._mStream.Length + ((length + 1) * 2));

			this._mStream.Position += Encoding.BigEndianUnicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
			this._mStream.Position += 2;
		}

		/// <summary>
		/// Writes a fixed-length big-endian unicode string value to the underlying stream. To fit (size), the string content is either truncated or padded with null characters.
		/// </summary>
		public void WriteFixedBigUnicode(string value, int size)
		{
			if (value == null)
			{
				Console.WriteLine("Network: Attempted to WriteBigUniFixed() with null value");
				value = String.Empty;
			}
			size *= 2;
			int length = value.Length;
			this.Write((short)length);
			this._mStream.SetLength(this._mStream.Length + size);

			if ((length * 2) >= size)
			{
				this._mStream.Position += Encoding.BigEndianUnicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
			}
			else
			{
				Encoding.BigEndianUnicode.GetBytes(value, 0, length, this._mStream.GetBuffer(), (int)this._mStream.Position);
				this._mStream.Position += size;
			}
		}

		/// <summary>
		/// Fills the stream from the current position up to (capacity) with 0x00's
		/// </summary>

		public void Fill()
		{
			this.Fill((int)(this._mCapacity - this._mStream.Length));
		}

		/// <summary>
		/// Writes a number of 0x00 byte values to the underlying stream.
		/// </summary>

		public void Fill(int length)
		{
			if (this._mStream.Position == this._mStream.Length)
			{
				this._mStream.SetLength(this._mStream.Length + length);
				this._mStream.Seek(0, SeekOrigin.End);
			}
			else
			{
				this._mStream.Write(new byte[length], 0, length);
			}
		}
		/// <summary>
		/// Gets the total stream length.
		/// </summary>
		public long Length
		{
			get
			{
				return this._mStream.Length;
			}
		}

		/// <summary>
		/// Gets or sets the current stream position.
		/// </summary>
		public long Position
		{
			get
			{
				return this._mStream.Position;
			}
			set
			{
				this._mStream.Position = value;
			}
		}

		/// <summary>
		/// The internal stream used by this PacketWriter instance.
		/// </summary>
		public MemoryStream UnderlyingStream
		{
			get
			{
				return this._mStream;
			}
		}

		/// <summary>
		/// Offsets the current position from an origin.
		/// </summary>
		public long Seek(long offset, SeekOrigin origin)
		{
			return this._mStream.Seek(offset, origin);
		}

		/// <summary>
		/// Gets the entire stream content as a byte array.
		/// </summary>

		public byte[] ToArray()
		{
			return this._mStream.ToArray();
		}

		#region IDisposable Support
		private bool disposedValue = false; // Для определения избыточных вызовов

		private void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					// TODO: освободить управляемое состояние (управляемые объекты).
					this._mStream.Dispose();
				}

				// TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
				// TODO: задать большим полям значение NULL.

				this.disposedValue = true;
			}
		}

		// TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
		// ~PacketWriter() {
		//   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
		//   Dispose(false);
		// }

		// Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
		public void Dispose()
		{
			// Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
			this.Dispose(true);
			// TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
			GC.SuppressFinalize(this);
		}
		#endregion

	}

}
