using System;
using System.Linq;
using LocalCommons.Cryptography;
using LocalCommons.Compression;

namespace LocalCommons.Network
{
	/// <summary>
	/// Abstract Class For Writing Packets
	/// Author: Raphail
	/// </summary>
	public abstract class NetPacket
	{
		protected static PacketWriter ns;
		/// <summary>
		/// Опкод пакета
		/// </summary>
		private readonly int _mPacketId;
		/// <summary>
		/// Сначала младшие байты
		/// </summary>
		private readonly bool _mLittleEndian;
		/// <summary>
		/// Пакет от сервера
		/// </summary>
		private bool _mIsArcheAge;
		/// <summary>
		/// Уровень схатия/шифрования
		/// </summary>
		private readonly byte _level;
		//Fix by Yanlong-LI
		/// <summary>
		/// Глобальный подсчет пакетов DD05
		/// </summary>
		//Исправление входа второго пользователя, вторичный логин, счетчик повторного соединения с возвратом в лобби, вызванный ошибкой
		public static byte NumPckSc = 0;  //修复第二用户、二次登陆、大厅返回重连DD05计数器造成错误问题 BUG глобальный подсчет пакетов DD05
		public static sbyte NumPckCs = -1; //глобальный подсчет пакетов 0005

		/// <summary>
		/// Пакет от сервера/клиента
		/// </summary>
		public bool IsArcheAgePacket
		{
			get { return this._mIsArcheAge; }
			set { this._mIsArcheAge = true; }
		}

		/// <summary>
		/// Creates Instance Of Any Other Packet
		/// </summary>
		/// <param name="packetId">Packet Identifier(opcode)</param>
		/// <param name="isLittleEndian">Send Data In Little Endian Or Not.</param>
		protected NetPacket(int packetId, bool isLittleEndian)
		{
			this._mPacketId = packetId;
			this._mLittleEndian = isLittleEndian;
			ns = PacketWriter.CreateInstance(4092, isLittleEndian);
		}

		/// <summary>
		/// Creates Instance Of ArcheAge Game Packet.
		/// </summary>
		/// <param name="level">Packet Level</param>
		/// <param name="packetId">Packet Identifier(opcode)</param>
		protected NetPacket(byte level, int packetId)
		{
			this._mPacketId = packetId;
			this._level = level;
			this._mLittleEndian = true;
			this._mIsArcheAge = true;
			ns = PacketWriter.CreateInstance(4092, true);
		}

		/// <summary>
		/// Stream Where We Writing Data.
		/// </summary>
		public PacketWriter UnderlyingStream
		{
			get { return ns; }
		}

		/// <summary>
		/// Compiles Data And Return Compiled byte[]
		/// </summary>
		/// <returns></returns>
		public byte[] Compile()
		{
			var temporary = PacketWriter.CreateInstance(4096 * 4, this._mLittleEndian);
			//temporary.Write((short)(ns.Length + (m_IsArcheAge ? 6 : 2)));
			if (this._mIsArcheAge)
			{
				//Серверные пакеты
				switch (this._level)
				{
					case 5:
						//здесь будет шифрование пакета DD05
						temporary.Write((short)(ns.Length + 6));
						temporary.Write((byte)0xDD);
						temporary.Write((byte)this._level);
						//TODO: посмотреть, может по другому написать, через copy?
						byte[] numPck = new byte[1];
						numPck[0] = NumPckSc; //вставили номер пакета в массив
						byte[] data = numPck.Concat(BitConverter.GetBytes((short)this._mPacketId)).ToArray(); //объединили с ID
						data = data.Concat(ns.ToArray()).ToArray(); //объединили с телом пакета
						byte crc8 = Encrypt.Crc8(data); //посчитали CRC пакета
						byte[] crc = new byte[1];
						crc[0] = crc8; //вставили crc в массив
						data = crc.Concat(data).ToArray(); //добавили спереди контрольную сумму
						byte[] encrypt = Encrypt.StoCEncrypt(data); //зашифровали пакет
						temporary.Write(encrypt, 0, encrypt.Length);
						++NumPckSc; //следующий номер шифрованного пакета DD05
						break;
					case 3:
						//здесь будет шифрование пакета DD03 (один пакет)
						temporary.Write((short)(ns.Length + 4));
						temporary.Write((byte)0xDD);
						temporary.Write((byte)this._level);
						temporary.Write((short)this._mPacketId);
						//len  hash opcod Тело пакета
						//AC04 DD03 0900  CD550D6C1445147EB3BBD7BB6A2977B66ADB54A412ADD1885ECF23B6785D824448087A6A41B170A570D6682D6A6E37B097A8AB69625169281222E16C0C3F12C45A5A49688126A5058998A825FED15CD03431268A54D34862F05CDF4C776FF77AD7DE79FC4E7666DEBC79F3BDF7BDF9D93C327D8E9B7B3307F432B7A15F793A22ED39CEEB0A50453877BD3148DF6BB41866772D23DD0E637062E890B2B252EAEA63D063EF0385DEED34A6D3F7145933CC3697F326347CD4AB1CAD948E8D4353135584ACA11F2BCD8D5C4741586D3FA48C5449C309D08537B3A98C1A8D16C3326F9F4325C6009C2EE5FC71A967814035BE26969066D333D5C6EB56711D171FE802458E27E4707EAE05FA4C9ED21B95CA2B1934355745980C7A5F4DE3D4D03975D05D4841581DEB514E7AA5501F3F8D1F26D13758D4EF78D954468D468B61A93C0FE6E1830F46940B1BE492B7D909A126EA451CBE8DB55CA3994CCE1BDE512C3FDAC13F1538119BF52F8BFAF59BA88FCCAA468B61BAE271BB055A76877716CA9F77F2B790D35A49ECE2A097D7104FAEE107DC15E16385B2AF936FF637084DB84BAA08EB6E884FA715345A0CABA64187053AE20D3716C9873BF89965BE5DA70FB2A8B386FEB2CD1E3373DDE40E6B37CACD9FF08B47E741E97842C2454618E97B1A74FC5CCF0E083BCD2BB3BA2A5C1090DB76B013A22C6351BF624F0DD9F655C45CA89B2440DB13CE75E3DDE18A02B9BF83FF3EE6B2D5290C3AEB731D84F3B7133B3C54BFF6C597E4101C116ED303A0DDB611A5F8AC34670049A8A260E60DA0B616A0E5CF1A3D6CDAD10A4BE9AAEC6BCAE77B05BADA90ECEAE1ECDDD095295D05D0D55BC9AE66D105D9D794AEA6827BED09802D254B594681D08E56C0176CAA5513E7BA2BEE451C539B14C67B387DF68E2437DBCD2599485B3D69DC8CE23F68637252FF279B89A124B129C37BDB7AF9DDBCBA04607E20319A227CEFAC1ADEE900605B06465145764D8D21EBA98E0AAAE86500AAD8A5F754EBA70DABE376B6E76ED5680D719CB6D766D35480BF005C516099C01CA3ED183BA9BEC15194F52F47EFB14B8C0815D66FB17590B1EC8F0238BF03D03400C2B5CEC6F61BBC988C0680DB05AC3CC35A00DBA9BF99B4C7F847E32A5C4B75692442639FF16005DC192484CAB886F55DC528E10B862D3005C03F398BE88855DD94C9416875E198AC2F8377A7310D362FFCA2AC55A42F06D90BC73D80F3A8BCA21FB7E9E301E04C97331F01E869C1B4D094103AA107950B02ECA5BFD490690C41D8BC068764FBCFD0122775645859BF50DAF21923458EE2FCAFC616A0CCBE4FEB59673607262A363D6B4E5E1689F3CFE82FA0FC74F479785417BD9C82F8300830D6805689C457FD8E2AD25A404CE2525451EF976A4E5EE3C49D07CE9566423C969AF8CA214A7CE105CB8EFBFE507EF44BA5A7AE71E23FD5D50F0918BCFE4DBAE3D35313EFBC071792AFF3A13A1F05F63DD9ABD87CD2401FEFF184446E818D29AF68C3EDDF854FB2E9F287E5C6FD15A01AD504AC97783F38E0C3D504F5D61B1984F98CDA9A7C10E3D43C0795F62A695B1FDB53AEFA6A505B759F9FB31C542B351F522009D438A4B63B05B5CE720240AABFB5BCBAB625E158505623E3D4327A75E1D216CED97EC666A136E9AB3B1704F88D3E85D6C7E73F
						byte[] data3 = ns.ToArray(); //получим тело пакета
						byte[] compBytes3 = Compressing.Decompress(data3);
						temporary.Write(compBytes3, 0, compBytes3.Length);
						break;
					case 4:
						//здесь будет шифрование пакета DD04 (склеенные пакеты)

						//len  hash opcod Тело пакета
						//AC04 DD04 0900  CD550D6C1445147EB3BBD7BB6A2977B66ADB54A412ADD1885ECF23B6785D824448087A6A41B170A570D6682D6A6E37B097A8AB69625169281222E16C0C3F12C45A5A49688126A5058998A825FED15CD03431268A54D34862F05CDF4C776FF77AD7DE79FC4E7666DEBC79F3BDF7BDF9D93C327D8E9B7B3307F432B7A15F793A22ED39CEEB0A50453877BD3148DF6BB41866772D23DD0E637062E890B2B252EAEA63D063EF0385DEED34A6D3F7145933CC3697F326347CD4AB1CAD948E8D4353135584ACA11F2BCD8D5C4741586D3FA48C5449C309D08537B3A98C1A8D16C3326F9F4325C6009C2EE5FC71A967814035BE26969066D333D5C6EB56711D171FE802458E27E4707EAE05FA4C9ED21B95CA2B1934355745980C7A5F4DE3D4D03975D05D4841581DEB514E7AA5501F3F8D1F26D13758D4EF78D954468D468B61A93C0FE6E1830F46940B1BE492B7D909A126EA451CBE8DB55CA3994CCE1BDE512C3FDAC13F1538119BF52F8BFAF59BA88FCCAA468B61BAE271BB055A76877716CA9F77F2B790D35A49ECE2A097D7104FAEE107DC15E16385B2AF936FF637084DB84BAA08EB6E884FA715345A0CABA64187053AE20D3716C9873BF89965BE5DA70FB2A8B386FEB2CD1E3373DDE40E6B37CACD9FF08B47E741E97842C2454618E97B1A74FC5CCF0E083BCD2BB3BA2A5C1090DB76B013A22C6351BF624F0DD9F655C45CA89B2440DB13CE75E3DDE18A02B9BF83FF3EE6B2D5290C3AEB731D84F3B7133B3C54BFF6C597E4101C116ED303A0DDB611A5F8AC34670049A8A260E60DA0B616A0E5CF1A3D6CDAD10A4BE9AAEC6BCAE77B05BADA90ECEAE1ECDDD095295D05D0D55BC9AE66D105D9D794AEA6827BED09802D254B594681D08E56C0176CAA5513E7BA2BEE451C539B14C67B387DF68E2437DBCD2599485B3D69DC8CE23F68637252FF279B89A124B129C37BDB7AF9DDBCBA04607E20319A227CEFAC1ADEE900605B06465145764D8D21EBA98E0AAAE86500AAD8A5F754EBA70DABE376B6E76ED5680D719CB6D766D35480BF005C516099C01CA3ED183BA9BEC15194F52F47EFB14B8C0815D66FB17590B1EC8F0238BF03D03400C2B5CEC6F61BBC988C0680DB05AC3CC35A00DBA9BF99B4C7F847E32A5C4B75692442639FF16005DC192484CAB886F55DC528E10B862D3005C03F398BE88855DD94C9416875E198AC2F8377A7310D362FFCA2AC55A42F06D90BC73D80F3A8BCA21FB7E9E301E04C97331F01E869C1B4D094103AA107950B02ECA5BFD490690C41D8BC068764FBCFD0122775645859BF50DAF21923458EE2FCAFC616A0CCBE4FEB59673607262A363D6B4E5E1689F3CFE82FA0FC74F479785417BD9C82F8300830D6805689C457FD8E2AD25A404CE2525451EF976A4E5EE3C49D07CE9566423C969AF8CA214A7CE105CB8EFBFE507EF44BA5A7AE71E23FD5D50F0918BCFE4DBAE3D35313EFBC071792AFF3A13A1F05F63DD9ABD87CD2401FEFF184446E818D29AF68C3EDDF854FB2E9F287E5C6FD15A01AD504AC97783F38E0C3D504F5D61B1984F98CDA9A7C10E3D43C0795F62A695B1FDB53AEFA6A505B759F9FB31C542B351F522009D438A4B63B05B5CE720240AABFB5BCBAB625E158505623E3D4327A75E1D216CED97EC666A136E9AB3B1704F88D3E85D6C7E73F
						byte[] data4 = ns.ToArray(); //получим тело пакета
						byte[] compBytes4 = Compressing.Compress(data4);
						temporary.Write((short)(compBytes4.Length + 4));
						temporary.Write((byte)0xDD);
						temporary.Write((byte)this._level);
						temporary.Write((short)this._mPacketId);
						temporary.Write(compBytes4, 0, compBytes4.Length);
						break;
					default:
						temporary.Write((short)(ns.Length + 4));

						temporary.Write((byte)0xDD);
						temporary.Write((byte)this._level);
						temporary.Write((short)this._mPacketId);

						byte[] redata = ns.ToArray();
						temporary.Write(redata, 0, redata.Length);
						break;
				}
			}
			else
			{
				temporary.Write((short)(ns.Length + 2));
				temporary.Write((short)this._mPacketId);
				byte[] redata = ns.ToArray();
				temporary.Write(redata, 0, redata.Length);
			}
			PacketWriter.ReleaseInstance(ns);
			ns = null;
			byte[] compiled = temporary.ToArray();
			PacketWriter.ReleaseInstance(temporary);
			temporary = null;

			return compiled;
		}
		/// <summary>
		/// Compiles Data And Return Compiled byte[]
		/// </summary>
		/// <returns></returns>
		public byte[] Compile0()
		{
			PacketWriter temporary = PacketWriter.CreateInstance(4096 * 4, this._mLittleEndian);
			temporary.Write((short)(ns.Length + (this._mIsArcheAge ? 4 : 2)));
			if (this._mIsArcheAge)
			{
				temporary.Write((byte)0xDD);
				temporary.Write((byte)this._level);
				temporary.Write((short)this._mPacketId);
			}
			else
			{
				temporary.Write((short)this._mPacketId);
			}

			byte[] redata = ns.ToArray();
			PacketWriter.ReleaseInstance(ns);
			ns = null;
			temporary.Write(redata, 0, redata.Length);
			byte[] compiled = temporary.ToArray();
			PacketWriter.ReleaseInstance(temporary);
			temporary = null;
			return compiled;
		}
		/// <summary>
		/// Compiles Data And Return Compiled byte[]
		/// </summary>
		/// <returns></returns>
		public byte[] Compile2()
		{
			PacketWriter temporary = PacketWriter.CreateInstance(4096 * 4, this._mLittleEndian);

			byte[] redata = ns.ToArray();
			PacketWriter.ReleaseInstance(ns);
			ns = null;
			temporary.Write(redata, 0, redata.Length);
			byte[] compiled = temporary.ToArray();
			PacketWriter.ReleaseInstance(temporary);
			temporary = null;
			return compiled;
		}
	}
}
