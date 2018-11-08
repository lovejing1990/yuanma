using LocalCommons.Logging;
using LocalCommons.Network;
using System;
using System.Net.Sockets;

namespace ArcheAgeGame.ArcheAge.Network.Connections
{
    /// <summary>
    /// Connection That Used For Login Server Connection.
    /// </summary>
    public sealed class LoginConnection : IConnection
    {
        public LoginConnection(Socket socket) : base(socket)
        {
            Log.Info("Connected to LoginServer, installing data...");
	        this.DisconnectedEvent += this.LoginConnection_DisconnectedEvent;
			this.SendAsync(new Net_RegisterArcheAgeGame());
        }

	    private void LoginConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            Log.Info("LoginServer IP: {0} disconnected", this);
			this.Dispose();
        }

        public override void HandleReceived(byte[] data)
        {
            var reader = new PacketReader(data, 0);
            var opcode = reader.ReadLEInt16();
            var handler = DelegateList.LHandlers[opcode];
            if (handler != null)
                handler.OnReceive(this, reader);
            else
                Log.Info("Received Undefined Packet 0x{0:x2}", opcode);
        }
    }
}
