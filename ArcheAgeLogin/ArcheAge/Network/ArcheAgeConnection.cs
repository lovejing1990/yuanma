using ArcheAgeLogin.ArcheAge.Holders;
using ArcheAgeLogin.ArcheAge.Structuring;
using LocalCommons.Logging;
using LocalCommons.Network;
using LocalCommons.Utilities;
using System;
using System.Net.Sockets;

namespace ArcheAgeLogin.ArcheAge.Network
{
    /// <summary>
    /// Connection For ArcheAge Client - Using Only For Authorization.
    /// </summary>
    public class ArcheAgeConnection : IConnection
    {
        public bool MovedToGame = false;
        public Account CurrentAccount { get; set; }

        public ArcheAgeConnection(Socket socket) : base(socket)
        {
            Log.Info("Client IP: {0} connected", this);
	        this.DisconnectedEvent += this.ArcheAgeConnection_DisconnectedEvent;
	        this.m_LittleEndian = true;
        }

        void ArcheAgeConnection_DisconnectedEvent(object sender, EventArgs e)
        {
            if (this.CurrentAccount != null)
            {
                if(ArcheAgeGameController.AuthorizedAccounts.ContainsKey(this.CurrentAccount.Session)) //AccountID
                {
                    ArcheAgeGameController.AuthorizedAccounts.Remove(this.CurrentAccount.Session); //AccountID
                }
                //Removing Account From All ArcheAgeGames
                foreach (ArcheAgeGame server in ArcheAgeGameController.CurrentArcheAgeGames.Values)
                {
                    if (server.CurrentAuthorized.Contains(this.CurrentAccount.AccountId))
                        server.CurrentAuthorized.Remove(this.CurrentAccount.AccountId);
                }
                if (this.CurrentAccount.Token!= null) //If you been fully authroized.
                {
	                this.CurrentAccount.LastEnteredTime = Utility.CurrentTimeMilliseconds();
                    AccountHolder.InsertOrUpdate(this.CurrentAccount);
                }
            }
            string arg = this.MovedToGame ? "moved to Game" : "disconnected";
            ArcheAgeConnection archeAgeConnection = this;
            Log.Info("ArcheAge: {0} {1}", this.CurrentAccount == null ? archeAgeConnection.ToString() : this.CurrentAccount.Name, arg);
	        this.Dispose();
        }

        public override void HandleReceived(byte[] data)
        {
            PacketReader reader = new PacketReader(data, 0);
            ushort opcode = reader.ReadLEUInt16();
            if (opcode > PacketList.LHandlers.Length)
            {
                Log.Info("Not enough length for LHandlers, disposing...");
	            this.Dispose();
                return;
            }

            PacketHandler0<ArcheAgeConnection> handler = PacketList.LHandlers[opcode];
            if (handler != null)
                handler.OnReceive(this, reader);
            else
                Log.Info("Received undefined packet 0x{0:x2}", opcode);

            reader = null;
        }
    }
}
