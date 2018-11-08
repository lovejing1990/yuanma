using LocalCommons.Logging;
using LocalCommons.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ArcheAgeLogin.ArcheAge.Network
{
    /// <summary>
    /// Connection That Used Only For Interact With Game Servers.
    /// </summary>
    public class GameConnection : IConnection
    {
        private ArcheAgeGame m_CurrentInfo;

        public ArcheAgeGame CurrentInfo
        {
            get { return this.m_CurrentInfo; }
            set { this.m_CurrentInfo = value; }
        }

        public GameConnection(Socket socket) : base(socket) 
        {
            Log.Info("ArcheAgeGame IP: {0} connected", this);
	        this.DisconnectedEvent += this.ChannelConnection_DisconnectedEvent;
	        this.m_LittleEndian = true;
        }

        void ChannelConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            Log.Info("ArcheAgeGame IP: {0} disconnected", this.m_CurrentInfo != null ? this.m_CurrentInfo.Id.ToString() : this.ToString());
	        this.Dispose();
            ArcheAgeGameController.DisconnecteArcheAgeGame(this.m_CurrentInfo != null ? this.m_CurrentInfo.Id : this.CurrentInfo.Id);
	        this.m_CurrentInfo = null;
            //Game server will be corresponding status offline
        }

        public override void HandleReceived(byte[] data)
        {
            PacketReader reader = new PacketReader(data, 0);
            ushort opcode = reader.ReadLEUInt16();
            PacketHandler0<GameConnection> handler = PacketList.GHandlers[opcode];
            if (handler != null) {
                handler.OnReceive(this, reader);
            }
            else
                Log.Info("Received undefined ArcheAgeGame packet 0x{0:X2}", opcode);
            reader = null;
        }
    }
}
