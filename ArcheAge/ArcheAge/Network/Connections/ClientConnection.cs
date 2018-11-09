using LocalCommons.Logging;
using LocalCommons.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using ArcheAgeGame.ArcheAge.Structuring;
using LocalCommons.Cryptography;
using LocalCommons.Utilities;

namespace ArcheAgeGame.ArcheAge.Network.Connections
{

    /// <summary>
    /// Connection That Used For ArcheAge Client( Game Side )
    /// </summary>
    public class ClientConnection : IConnection
    {
        //----- Static
	    private readonly byte _mRandom;
        //Fix by Yanlong-LI
        //Исправление входа второго пользователя, вторичный логин, счетчик повторного соединения с возвратом в лобби, вызванный ошибкой
        public byte NumPck = 0;  //修复第二用户、二次登陆、大厅返回重连DD05计数器造成错误问题 BUG глобальный подсчет пакетов DD05
        public static Dictionary<int, Account> CurrentAccounts { get; } = new Dictionary<int, Account>();

	    public Account CurrentAccount { get; set; }

        public ClientConnection(Socket socket) : base(socket)
        {
            Log.Info("Client IP: {0} connected", this);
	        this.DisconnectedEvent += this.ClientConnection_DisconnectedEvent;
	        this.m_LittleEndian = true;
        }

        public override void SendAsync(NetPacket packet)
        {
            packet.IsArcheAgePacket = true;
            //Fix by Yanlong-LI
            //Переопределяем счетчик для текущего соединения
            NetPacket.NumPckSc = this.NumPck;//重写为当前连接的计数
            base.SendAsync(packet);
            //Записываем счетчик обратно
	        this.NumPck = NetPacket.NumPckSc;//将计数回写
        }

        public void SendAsyncd(NetPacket packet)
        {
            packet.IsArcheAgePacket = false;
            base.SendAsync(packet);
        }
        void ClientConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            Log.Info("Client IP: {0} disconnected", this);
	        this.Dispose();
        }

        public override void HandleReceived(byte[] data)
        {
            PacketReader reader = new PacketReader(data, 0);
            //reader.Offset += 1; //Undefined Random Byte
            byte seq = reader.ReadByte();
            byte header = reader.ReadByte(); //Packet Level
            ushort opcode = reader.ReadLEUInt16(); //Packet Opcode
			//обрабатываем пакеты от клиента
/*
	        if (header == 0x04 && seq == 00)
	        {
		        //len  hash opcod Тело пакета
		        //AC04 DD04 0900  CD550D6C1445147EB3BBD7BB6A2977B66ADB54A412ADD1885ECF23B6785D824448087A6A41B170A570D6682D6A6E37B097A8AB69625169281222E16C0C3F12C45A5A49688126A5058998A825FED15CD03431268A54D34862F05CDF4C776FF77AD7DE79FC4E7666DEBC79F3BDF7BDF9D93C327D8E9B7B3307F432B7A15F793A22ED39CEEB0A50453877BD3148DF6BB41866772D23DD0E637062E890B2B252EAEA63D063EF0385DEED34A6D3F7145933CC3697F326347CD4AB1CAD948E8D4353135584ACA11F2BCD8D5C4741586D3FA48C5449C309D08537B3A98C1A8D16C3326F9F4325C6009C2EE5FC71A967814035BE26969066D333D5C6EB56711D171FE802458E27E4707EAE05FA4C9ED21B95CA2B1934355745980C7A5F4DE3D4D03975D05D4841581DEB514E7AA5501F3F8D1F26D13758D4EF78D954468D468B61A93C0FE6E1830F46940B1BE492B7D909A126EA451CBE8DB55CA3994CCE1BDE512C3FDAC13F1538119BF52F8BFAF59BA88FCCAA468B61BAE271BB055A76877716CA9F77F2B790D35A49ECE2A097D7104FAEE107DC15E16385B2AF936FF637084DB84BAA08EB6E884FA715345A0CABA64187053AE20D3716C9873BF89965BE5DA70FB2A8B386FEB2CD1E3373DDE40E6B37CACD9FF08B47E741E97842C2454618E97B1A74FC5CCF0E083BCD2BB3BA2A5C1090DB76B013A22C6351BF624F0DD9F655C45CA89B2440DB13CE75E3DDE18A02B9BF83FF3EE6B2D5290C3AEB731D84F3B7133B3C54BFF6C597E4101C116ED303A0DDB611A5F8AC34670049A8A260E60DA0B616A0E5CF1A3D6CDAD10A4BE9AAEC6BCAE77B05BADA90ECEAE1ECDDD095295D05D0D55BC9AE66D105D9D794AEA6827BED09802D254B594681D08E56C0176CAA5513E7BA2BEE451C539B14C67B387DF68E2437DBCD2599485B3D69DC8CE23F68637252FF279B89A124B129C37BDB7AF9DDBCBA04607E20319A227CEFAC1ADEE900605B06465145764D8D21EBA98E0AAAE86500AAD8A5F754EBA70DABE376B6E76ED5680D719CB6D766D35480BF005C516099C01CA3ED183BA9BEC15194F52F47EFB14B8C0815D66FB17590B1EC8F0238BF03D03400C2B5CEC6F61BBC988C0680DB05AC3CC35A00DBA9BF99B4C7F847E32A5C4B75692442639FF16005DC192484CAB886F55DC528E10B862D3005C03F398BE88855DD94C9416875E198AC2F8377A7310D362FFCA2AC55A42F06D90BC73D80F3A8BCA21FB7E9E301E04C97331F01E869C1B4D094103AA107950B02ECA5BFD490690C41D8BC068764FBCFD0122775645859BF50DAF21923458EE2FCAFC616A0CCBE4FEB59673607262A363D6B4E5E1689F3CFE82FA0FC74F479785417BD9C82F8300830D6805689C457FD8E2AD25A404CE2525451EF976A4E5EE3C49D07CE9566423C969AF8CA214A7CE105CB8EFBFE507EF44BA5A7AE71E23FD5D50F0918BCFE4DBAE3D35313EFBC071792AFF3A13A1F05F63DD9ABD87CD2401FEFF184446E818D29AF68C3EDDF854FB2E9F287E5C6FD15A01AD504AC97783F38E0C3D504F5D61B1984F98CDA9A7C10E3D43C0795F62A695B1FDB53AEFA6A505B759F9FB31C542B351F522009D438A4B63B05B5CE720240AABFB5BCBAB625E158505623E3D4327A75E1D216CED97EC666A136E9AB3B1704F88D3E85D6C7E73F
		        byte[] arraBytes = Encrypt.DecompressString2(data);

	        }
*/

			if (header == 0x05 && seq == 00)
            {
                reader.Offset -= 2; //вернемся к hash, count
                byte hash = reader.ReadByte(); //считываем hash или CRC (он не меняется)
                byte count = reader.ReadByte(); //считываем count (шифрован, меняется)
                //------------------------------
                //потом switch уберем
                switch (hash)
                {
                    case 0x33:
                        opcode = 0x008E; //вход в игру5
                        break;
                    case 0x34:
                        opcode = 0x0088; //пакет на релогин из лобби
                        break;
                    //case 0x35:
                    //    opcode = 0x0088; //пакет на релогин из игры
                    //    break;
                    case 0x36:
                        opcode = 0x008F; //вход в игру6
                        break;
                    case 0x37:
                        opcode = 0x008B; //вход в игру2
                        break;
                    case 0x38:
                        opcode = 0x008A; //вход в игру1
                        break;
                    case 0x39:
                        opcode = 0x008C; //вход в игру3
                        break;
                    case 0x3F:
                        opcode = 0x008D; //вход в игру4
                        break;
                        //default:
                        //    msg = "";
                        //    break;
                }
                //------------------------------
                //здесь распаковка пакетов от клиента 
                //здесь будет расшифровка пакета 0005

                ////пробуем расшифровать
                ////byte[] ciphertext = new byte[] {0x13, 0x00, 0x00, 0x05, 0x39, 0x96, 0x41, 0x57, 0x3F, 0x2C, 0xEF, 0x75, 0x3E, 0xC8, 0xC1, 0x75, 0xB5, 0xD2, 0x10, 0x43, 0x62};
                //var pck = new CtoSDecrypt();

                //var size = BitConverter.GetBytes((short) data.Length);
                //data = size.Concat(data).ToArray(); //объединили с Size

                //var ciphertext = Encrypt.CtoSEncrypt(data);
                //Log.Info("EncodeXOR:      " + Utility.ByteArrayToString(ciphertext));
                //var plaintext = pck.DecryptAes2(ciphertext);
                //Log.Info("EncodeAES:      " + Utility.ByteArrayToString(plaintext));
                ////"13 00 00 05" потеряли
                ////"16 42|50 00 01 00|D7 94 01 00|3D A5 00 00|A4 3E A5" получили
                ////reader.Offset += 2; //пропускаем hash&count
                //Buffer.BlockCopy(plaintext, 2, data, 0, 2); //reader.ReadLEUInt16(); //Packet Opcode
                //opcode = (ushort) BitConverter.ToInt16(plaintext, 2);
            }

            if (!DelegateList.ClientHandlers.ContainsKey(header))
            {
                Log.Info("Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2}", seq, header, opcode);
                return;
            }
            try
            {
                PacketHandler0<ClientConnection> handler = DelegateList.ClientHandlers[header][opcode];
                if (handler != null)
                {
                    handler.OnReceive(this, reader);
                }
                else
                {
                    Log.Info("Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2}", seq, header, opcode);
                }
            }
            catch (Exception)
            {
                Log.Info("Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2}", seq, header, opcode);
                throw;
            }
        }
    }
}
