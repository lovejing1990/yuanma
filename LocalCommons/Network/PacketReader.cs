using System;
using System.Text;
using System.IO;
using LocalCommons.Utilities;

namespace LocalCommons.Network
{
    /// <summary>
    /// Reader For Received Packets
    /// Author: Raphail
    /// </summary>
	public class PacketReader
	{
		private byte[] m_Data;
		private int m_Size;
		private int m_Index;

		public PacketReader( byte[] data, int offset )
		{
			this.m_Data = data;
			this.m_Size = data.Length;
			this.m_Index = offset;
		}

        /// <summary>
        /// Current Data.
        /// </summary>
		public byte[] Buffer
		{
			get { return this.m_Data; }
		}

        /// <summary>
        /// Data Length
        /// </summary>
		public int Size
		{
			get { return this.m_Size; }
		}

        /// <summary>
        /// Current Position
        /// </summary>
        public int Offset
        {
            get { return this.m_Index; }
            set { this.m_Index = value; }
        }

        /// <summary>
        /// Remaining Bytes Count
        /// </summary>
        public int Remaining
        {
            get { return this.m_Size - this.m_Index; }
        }

        public byte[] Clear()
        {
            for (int i = 0; i < this.m_Size; i++)
            {
	            this.m_Data[i] = 0;
            }
            return this.m_Data;
        }

        /// <summary>
        /// Reading Byte[] From Stream.
        /// </summary>
        /// <param name="length">Byte[] Length</param>
        /// <returns>Byte[] From Stream</returns>
        public byte[] ReadByteArray(int length)
        {
            if (length > this.m_Size)
                return new byte[0];

            byte[] data = new byte[length];
            Array.Copy(this.m_Data, this.m_Index, data, 0, data.Length);
	        this.m_Index += length;
            return data;
        }

        /// <summary>
        /// Sets Offset By SeekOrigin.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
		public int Seek( int offset, SeekOrigin origin )
		{
			switch ( origin )
			{
				case SeekOrigin.Begin:
					this.m_Index = offset; break;
				case SeekOrigin.Current:
					this.m_Index += offset; break;
				case SeekOrigin.End:
					this.m_Index = this.m_Size - offset; break;
			}

			return this.m_Index;
		}

        /// <summary>
        /// Reading Signed Int64 From Stream.
        /// </summary>
        /// <returns>Signed Int64</returns>
        public long ReadInt64()
        {
            if ((this.m_Index + 8) > this.m_Size)
                return 0;

            uint mlong = (uint)(this.m_Data[this.m_Index++] | this.m_Data[this.m_Index++] << 8 | this.m_Data[this.m_Index++] << 16 | this.m_Data[this.m_Index++] << 24);
            uint mhigher = (uint)(this.m_Data[this.m_Index++] | this.m_Data[this.m_Index++] << 8 | this.m_Data[this.m_Index++] << 16 | this.m_Data[this.m_Index++] << 24);
            return (long)((ulong)mhigher) << 32 | mlong;
        }

        /// <summary>
        /// Reading Signed Int32 From Stream.
        /// </summary>
        /// <returns>Signed Int32.</returns>
		public int ReadInt32()
		{
			if ( (this.m_Index + 4) > this.m_Size )
				return 0;

			return (this.m_Data[this.m_Index++] << 24)
				 | (this.m_Data[this.m_Index++] << 16)
				 | (this.m_Data[this.m_Index++] <<  8)
				 | this.m_Data[this.m_Index++];
		}

        /// <summary>
        /// Reading Signed 2 Bytes Short From Stream.
        /// </summary>
        /// <returns>Signed Short From Stream.</returns>
		public short ReadInt16()
		{
			if ( (this.m_Index + 2) > this.m_Size )
				return 0;

			return (short) ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]);
		}

        /// <summary>
        /// Reading Byte From Stream.
        /// </summary>
        /// <returns></returns>
		public byte ReadByte()
		{
			if ( (this.m_Index + 1) > this.m_Size )
				return 0;

			return this.m_Data[this.m_Index++];
		}

        /// <summary>
        /// Reading Unsigned 3 bytes From Stream.
        /// </summary>
        /// <returns>Unsigned Integer From Stream.</returns>
		public Uint24 ReadUInt24()
		{
			if ( (this.m_Index + 4) > this.m_Size )
				return 0;

			return (Uint24)((this.m_Data[this.m_Index++] << 16) | (this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]);
		}

	    /// <summary>
	    /// Reading Unsigned Integer From Stream.
	    /// </summary>
	    /// <returns>Unsigned Integer From Stream.</returns>
	    public uint ReadUInt32()
	    {
	        if ((this.m_Index + 4) > this.m_Size)
	            return 0;

	        return (uint)((this.m_Data[this.m_Index++] << 24) | (this.m_Data[this.m_Index++] << 16) | (this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]);
	    }

        /// <summary>
        /// Reading Unsigned Short From Stream.
        /// </summary>
        /// <returns>Unsigned Short From Stream.</returns>
		public ushort ReadUInt16()
		{
			if ( (this.m_Index + 2) > this.m_Size )
				return 0;

			return (ushort) ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]);
		}

        /// <summary>
        /// Reading Signed Byte From Stream.
        /// </summary>
        /// <returns>Signed Byte From Stream.</returns>
		public sbyte ReadSByte()
		{
			if ( (this.m_Index + 1) > this.m_Size )
				return 0;

			return (sbyte) (this.m_Data[this.m_Index++]);
		}

        /// <summary>
        /// Reading Byte And Convert It To Boolean 
        /// True - Represents By 1 - False - 0
        /// </summary>
        /// <returns></returns>
		public bool ReadBoolean()
		{
			if ( (this.m_Index + 1) > this.m_Size )
				return false;

			return (this.m_Data[this.m_Index++] != 0 );
		}

        /// <summary>
        /// Reading Unicode Dynamic Length Little Endian String
        /// </summary>
        /// <returns>Readed String</returns>
		public string ReadUnicodeStringLE()
		{
			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < this.m_Size && (c = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0 )
				sb.Append( (char)c );

			return sb.ToString();
		}

        /// <summary>
        /// Reading Fixed Length Unicode String
        /// </summary>
        /// <param name="fixedLength">String Length</param>
        /// <returns>Readed String</returns>
		public string ReadUnicodeStringLESafe( int fixedLength )
		{
			int bound = this.m_Index + (fixedLength << 1);
			int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < bound && (c = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0 )
			{
				if (this.IsSafeChar( c ) )
					sb.Append( (char)c );
			}

			this.m_Index = end;

			return sb.ToString();
		}

        /// <summary>
        /// Reading Dynamic Lengthened -  Little Endian Unicode String.
        /// </summary>
        /// <returns>Little Endian Unicode String.</returns>
		public string ReadUnicodeStringLESafe()
		{
			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < this.m_Size && (c = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0 )
			{
				if (this.IsSafeChar( c ) )
					sb.Append( (char)c );
			}

			return sb.ToString();
		}

        /// <summary>
        /// Reading Dynamic Length Unicode String Safe.
        /// </summary>
        /// <returns>Readed String.</returns>
        public string ReadUnicodeStringSafe()
        {
            StringBuilder sb = new StringBuilder();

            int c;

            while ((this.m_Index + 1) < this.m_Size && (c = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0)
            {
                if (this.IsSafeChar(c))
                    sb.Append((char)c);
            }

            return sb.ToString();
        }

        #region Little Endian Readers 

        /// <summary>
        /// Reading Little Endian 2 - Bytes - Short.
        /// </summary>
        /// <returns>Readed Short</returns>
        public short ReadLEInt16()
        {
            if ((this.m_Index + 2) > this.m_Size)
                return 0;
            short value = BitConverter.ToInt16(this.m_Data, this.m_Index);
	        this.m_Index += 2;
            return value;
        }

	    /// <summary>
	    /// Reading Little Endian 2 - Bytes - UShort.
	    /// </summary>
	    /// <returns>Readed Short</returns>
	    public ushort ReadLEUInt16()
	    {
	        if ((this.m_Index + 2) > this.m_Size)
	            return 0;
	        ushort value = BitConverter.ToUInt16(this.m_Data, this.m_Index);
		    this.m_Index += 2;
	        return value;
	    }

        /// <summary>
        /// Reading Little Endian 4 - Bytes - UInt.
        /// </summary>
        /// <returns>Readed Int32</returns>
        public uint ReadLEUInt32()
        {
            if ((this.m_Index + 4) > this.m_Size)
                return 0;

            uint value = BitConverter.ToUInt32(this.m_Data, this.m_Index);
	        this.m_Index += 4;
            return value;
        }

	    /// <summary>
	    /// Reading Little Endian 4 - Bytes - Int.
	    /// </summary>
	    /// <returns>Readed Int32</returns>
	    public int ReadLEInt32()
	    {
	        if ((this.m_Index + 4) > this.m_Size)
	            return 0;

	        int value = BitConverter.ToInt32(this.m_Data, this.m_Index);
		    this.m_Index += 4;
	        return value;
	    }

        /// <summary>
        /// Reading Little Endian 8 - Bytes - Long.
        /// </summary>
        /// <returns>Readed Long</returns>
        public long ReadLEInt64()
        {
            if ((this.m_Index + 8) > this.m_Size)
                return 0;

            long value = BitConverter.ToInt64(this.m_Data, this.m_Index);
	        this.m_Index += 8;
            return value;
        }

        /// <summary>
        /// Reading Little Endian 4 - Bytes - Float.
        /// </summary>
        /// <returns>Readed Float</returns>
        public float ReadLESingle()
        {
            if ((this.m_Index + 4) > this.m_Size)
                return 0;

            float value = BitConverter.ToSingle(this.m_Data, this.m_Index);
	        this.m_Index += 4;
            return value;
        }

        #endregion

        /// <summary>
        /// Reading Dynamic - Length Unicode String.
        /// </summary>
        /// <returns>Readed String</returns>
        public string ReadUnicodeString()
		{
			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < this.m_Size && (c = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0 )
				sb.Append( (char)c );

			return sb.ToString();
		}

        /// <summary>
        /// Checking Is Char Safe Or Not.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Readed String</returns>
		public bool IsSafeChar( int c )
		{
			return ( c >= 0x20 && c < 0xFFFE );
		}

       /// <summary>
       /// Reading Fixed lengthened String From Stream With Checking Character Safeness.
       /// </summary>
       /// <param name="fixedLength"></param>
       /// <returns>Readed</returns>
		public string ReadUTF8StringSafe( int fixedLength )
		{
			if (this.m_Index >= this.m_Size )
			{
				this.m_Index += fixedLength;
				return String.Empty;
			}

			int bound = this.m_Index + fixedLength;
			//int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			int count = 0;
			int index = this.m_Index;
			int start = this.m_Index;

			while ( index < bound && this.m_Data[index++] != 0 )
				++count;

			index = 0;

			byte[] buffer = new byte[count];
			int value = 0;

			while (this.m_Index < bound && (value = this.m_Data[this.m_Index++]) != 0 )
				buffer[index++] = (byte)value;

			string s = Encoding.UTF8.GetString( buffer );

			bool isSafe = true;

			for ( int i = 0; isSafe && i < s.Length; ++i )
				isSafe = this.IsSafeChar( (int) s[i] );

			this.m_Index = start + fixedLength;

			if ( isSafe )
				return s;

			StringBuilder sb = new StringBuilder( s.Length );

			for ( int i = 0; i < s.Length; ++i )
				if (this.IsSafeChar( (int) s[i] ) )
					sb.Append( s[i] );

			return sb.ToString();
		}

        /// <summary>
        /// Reading UTF8 Dynamic Length String With Checking Character Safeness.
        /// </summary>
        /// <returns>Readed Safe String.</returns>
		public string ReadUTF8StringSafe()
		{
			if (this.m_Index >= this.m_Size )
				return String.Empty;

			int count = 0;
			int index = this.m_Index;

			while ( index < this.m_Size && this.m_Data[index++] != 0 )
				++count;

			index = 0;

			byte[] buffer = new byte[count];
			int value = 0;

			while (this.m_Index < this.m_Size && (value = this.m_Data[this.m_Index++]) != 0 )
				buffer[index++] = (byte)value;

			string s = Encoding.UTF8.GetString( buffer );

			bool isSafe = true;

			for ( int i = 0; isSafe && i < s.Length; ++i )
				isSafe = this.IsSafeChar( (int) s[i] );

			if ( isSafe )
				return s;

			StringBuilder sb = new StringBuilder( s.Length );

			for ( int i = 0; i < s.Length; ++i )
			{
				if (this.IsSafeChar( (int) s[i] ) )
					sb.Append( s[i] );
			}

			return sb.ToString();
		}

        /// <summary>
        /// Reads UTF8 Dynamic-Lengthened String From Stream
        /// </summary>
        /// <returns>Readed String</returns>
		public string ReadUTF8String()
		{
			if (this.m_Index >= this.m_Size )
				return String.Empty;

			int count = 0;
			int index = this.m_Index;

			while ( index < this.m_Size && this.m_Data[index++] != 0 )
				++count;

			index = 0;

			byte[] buffer = new byte[count];
			int value = 0;

			while (this.m_Index < this.m_Size && (value = this.m_Data[this.m_Index++]) != 0 )
				buffer[index++] = (byte)value;

			return Encoding.UTF8.GetString( buffer );
		}

        /// <summary>
        /// Reading Dynamic Length String
        /// </summary>
        /// <returns></returns>
		public string ReadDynamicString()
		{
			StringBuilder sb = new StringBuilder();

			int c;

			while (this.m_Index < this.m_Size && (c = this.m_Data[this.m_Index++]) != 0 )
				sb.Append( (char)c );

			return sb.ToString();
		}

        /// <summary>
        /// Reading Dynamic-Length String With Checking Character Safeness.
        /// </summary>
        /// <returns>Readed String</returns>
		public string ReadStringSafe()
		{
			StringBuilder sb = new StringBuilder();

			int c;

			while (this.m_Index < this.m_Size && (c = this.m_Data[this.m_Index++]) != 0 )
			{
				if (this.IsSafeChar( c ) )
					sb.Append( (char)c );
			}

			return sb.ToString();
		}

        /// <summary>
        /// Reading Unicode Safe String Without Checking Characters on Safeness.
        /// </summary>
        /// <param name="fixedLength">String Length</param>
        /// <returns>Readed String</returns>
		public string ReadUnicodeStringSafe( int fixedLength )
		{
			int bound = this.m_Index + (fixedLength << 1);
			int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < bound && (c = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0 )
			{
				if (this.IsSafeChar( c ) )
					sb.Append( (char)c );
			}

			this.m_Index = end;

			return sb.ToString();
		}

        /// <summary>
        /// Reading Unicode String
        /// </summary>
        /// <param name="fixedLength">String Length</param>
        /// <returns>Readed String</returns>
		public string ReadUnicodeString( int fixedLength )
		{
			int bound = this.m_Index + (fixedLength << 1);
			int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			StringBuilder sb = new StringBuilder();

			int c;

			while ( (this.m_Index + 1) < bound && (c = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0 )
				sb.Append( (char)c );

			this.m_Index = end;

			return sb.ToString();
		}

        /// <summary>
        /// Reading String With Checking is Safe Char Or Not.
        /// </summary>
        /// <param name="fixedLength">String Length</param>
        /// <returns>Readed String.</returns>
		public string ReadStringSafe( int fixedLength )
		{
			int bound = this.m_Index + fixedLength;
			int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			StringBuilder sb = new StringBuilder();

			int c;

			while (this.m_Index < bound && (c = this.m_Data[this.m_Index++]) != 0 )
			{
				if (this.IsSafeChar( c ) )
					sb.Append( (char)c );
			}

			this.m_Index = end;

			return sb.ToString();
		}

        /// <summary>
        /// Reading Fixed Length String From Stream.
        /// </summary>
        /// <param name="fixedLength">Length Of String</param>
        /// <returns>Readed String.</returns>
		public string ReadString( int fixedLength )
		{
			int bound = this.m_Index + fixedLength;
			int end   = bound;

			if ( bound > this.m_Size )
				bound = this.m_Size;

			StringBuilder sb = new StringBuilder();

			int c;

			while (this.m_Index < bound && (c = this.m_Data[this.m_Index++]) != 0 )
				sb.Append( (char)c );

			this.m_Index = end;

			return sb.ToString();
		}
        /// <summary>
        /// Reading String in HEX
        /// </summary>
        /// <param name="fixedLength">Length Of String</param>
        /// <returns>Readed String.</returns>
        public string ReadHexString(int fixedLength)
        {
            int bound = this.m_Index + fixedLength;
            int end = bound;

            if (bound > this.m_Size)
                bound = this.m_Size;

            StringBuilder sb = new StringBuilder();

            int c;

            while (this.m_Index < bound && (c = this.m_Data[this.m_Index++]) != 0)
                sb.Append(c.ToString("x0").PadLeft(2, '0'));

	        this.m_Index = end;

            return sb.ToString();
        }
    }
}