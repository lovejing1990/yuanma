using LocalCommons.Logging;
using LocalCommons.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

namespace ArcheAgeStream.ArcheAge.Network
{
    /// <summary>
    /// Connection That Used Only For Interact With Game Servers.
    /// </summary>
    public class StreamConnection : IConnection
    {
        private StreamServer m_CurrentInfo;

        public StreamServer CurrentInfo
        {
            get { return this.m_CurrentInfo; }
            set { this.m_CurrentInfo = value; }
        }

        public StreamConnection(Socket socket) : base(socket) 
        {
            Log.Info("Client IP: {0} connected", this);
	        this.DisconnectedEvent += this.ChannelConnection_DisconnectedEvent;
	        this.m_LittleEndian = true;
        }

        void ChannelConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            Log.Info("Client IP: {0} disconnected", this.m_CurrentInfo != null ? this.m_CurrentInfo.Id.ToString() : this.ToString());
	        this.Dispose();
            //StreamServerController.DisconnecteStreamServer(m_CurrentInfo != null ? m_CurrentInfo.Id : this.CurrentInfo.Id);
	        this.m_CurrentInfo = null;
            //Offline the game server's status
        }

        public override void HandleReceived(byte[] data)
        {
            PacketReader reader = new PacketReader(data, 0);

            //Log.Info("Allocated Memory = " + (Process.GetCurrentProcess().PrivateMemorySize64 / 1000000) + " MB");

            ushort opcode = reader.ReadLEUInt16();
            PacketHandler0<StreamConnection> handler = PacketList.GHandlers[opcode];
            if (handler != null) {
                handler.OnReceive(this, reader);
            }
            else
                Log.Info("Received Undefined StreamServer Packet 0x{0:X2}", opcode);
            reader = null;
        }
    }
}
