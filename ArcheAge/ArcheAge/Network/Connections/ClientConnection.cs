using ArcheAge.ArcheAge.Structuring;
using LocalCommons.Compression;
using LocalCommons.Logging;
using LocalCommons.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ArcheAge.ArcheAge.Network.Connections
{

    /// <summary>
    /// Connection That Used For ArcheAge Client( Game Side )
    /// </summary>
    public class ClientConnection : IConnection
    {
        //----- Static
        private static Dictionary<int, Account> m_CurrentAccounts = new Dictionary<int, Account>();
        private readonly byte _mRandom;
        //Fix by Yanlong-LI
        //Исправление входа второго пользователя, вторичный логин, счетчик повторного соединения с возвратом в лобби, вызванный ошибкой
        public byte NumPck = 0;  //修复第二用户、二次登陆、大厅返回重连DD05计数器造成错误问题 BUG глобальный подсчет пакетов DD05
        public static Dictionary<int, Account> CurrentAccounts
        {
            get { return m_CurrentAccounts; }
        }

        public Account CurrentAccount { get; set; }

        public ClientConnection(Socket socket) : base(socket)
        {
            Logger.Trace("Client IP: {0} connected", this);
            DisconnectedEvent += ClientConnection_DisconnectedEvent;
            m_LittleEndian = true;
        }

        public override void SendAsync(NetPacket packet)
        {
            packet.IsArcheAgePacket = true;
            //Fix by Yanlong-LI
            //Переопределяем счетчик для текущего соединения
            NetPacket.NumPckSc = NumPck;//重写为当前连接的计数
            base.SendAsync(packet);
            //Записываем счетчик обратно
            NumPck = NetPacket.NumPckSc;//将计数回写
        }
        public void SendAsyncd(NetPacket packet)
        {
            packet.IsArcheAgePacket = false;
            base.SendAsync(packet);
        }
        void ClientConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            Logger.Trace("Client IP: {0} disconnected", this);
            Dispose();
        }

        public override void HandleReceived(byte[] data)
        {
            PacketReader reader = new PacketReader(data, 0);
            //reader.Offset += 1; //Undefined Random Byte
            byte seq = reader.ReadByte();
            byte header = reader.ReadByte(); //Packet Level
            reader.Offset -= 2; //вернемся назад
            ushort ls = reader.ReadLEUInt16(); //Packet Level+seq 
            ushort opcode = reader.ReadLEUInt16(); //Packet Opcode
            //обрабатываем пакеты от клиента
            //len  seq header opcode Тело пакета
            //8200 00  01     0000   B10A4050184653CA705...
            switch (ls)
            {
                case 0x03:
                    byte[] compData3 = new byte[data.Length - 4];
                    Buffer.BlockCopy(data, 4, compData3, 0, data.Length - 4); //получим тело пакета
                    byte[] decompData3 = Сompressing.Decompress(compData3);   //разжимаем пакет
                    Buffer.BlockCopy(decompData3, 0, data, 0, decompData3.Length); //получим тело пакета
                    reader = new PacketReader(decompData3, 0);
                    break;
                case 0x04:
                    byte[] compData4 = new byte[data.Length - 4];
                    Buffer.BlockCopy(data, 4, compData4, 0, data.Length - 4); //получим тело пакета
                    byte[] decompData4 = Сompressing.Decompress(compData4);   //разжимаем пакет
                    Buffer.BlockCopy(decompData4, 0, data, 0, decompData4.Length); //получим тело пакета
                    reader = new PacketReader(decompData4, 0);
                    break;
                case 0x05:
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
                        default:
                            break;
                            //------------------------------
                            //здесь распаковка пакетов от клиента 
                            //здесь будет расшифровка пакета 0005

                            ////пробуем расшифровать
                            ////byte[] ciphertext = new byte[] {0x13, 0x00, 0x00, 0x05, 0x39, 0x96, 0x41, 0x57, 0x3F, 0x2C, 0xEF, 0x75, 0x3E, 0xC8, 0xC1, 0x75, 0xB5, 0xD2, 0x10, 0x43, 0x62};
                            //var pck = new CtoSDecrypt();

                            //var size = BitConverter.GetBytes((short) data.Length);
                            //data = size.Concat(data).ToArray(); //объединили с Size

                            //var ciphertext = Encrypt.CtoSEncrypt(data);
                            //Logger.Trace("EncodeXOR:      " + Utility.ByteArrayToString(ciphertext));
                            //var plaintext = pck.DecryptAes2(ciphertext);
                            //Logger.Trace("EncodeAES:      " + Utility.ByteArrayToString(plaintext));
                            ////"13 00 00 05" потеряли
                            ////"16 42|50 00 01 00|D7 94 01 00|3D A5 00 00|A4 3E A5" получили
                            ////reader.Offset += 2; //пропускаем hash&count
                            //Buffer.BlockCopy(plaintext, 2, data, 0, 2); //reader.ReadLEUInt16(); //Packet Opcode
                            //opcode = (ushort) BitConverter.ToInt16(plaintext, 2);
                    }
                    break;
                default:
                    break;
            }

            if (!DelegateList.ClientHandlers.ContainsKey(header))
            {
                Logger.Trace("DelegateList: Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2}", seq, header, opcode);
                return;
            }
            try
            {
                PacketHandler<ClientConnection> handler = DelegateList.ClientHandlers[header][opcode];
                if (handler != null)
                {
                    handler.OnReceive(this, reader);
                }
                else
                {
                    Logger.Trace("OnReceive: Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2}", seq, header, opcode);
                }
            }
            catch (Exception ex)
            {
                Logger.Trace("Exception: Received undefined packet - seq: {0}, header: {1}, opcode: 0x{2:X2} : {3}", seq, header, opcode, ex.Message);
                throw;
            }
        }
    }
}
