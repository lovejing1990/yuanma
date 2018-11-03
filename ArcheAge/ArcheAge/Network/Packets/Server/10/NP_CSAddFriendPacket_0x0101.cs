using System;
using ArcheAge.ArcheAge.Network.Connections;
using LocalCommons.Network;

namespace ArcheAge.ArcheAge.Network.Packets.Server._10
{
    public sealed class NP_SCAddFriendPacket_0x0101 : NetPacket
    {
        public NP_SCAddFriendPacket_0x0101(ClientConnection net, string name) : base(01, 0x04B)
        {
            //1.0.1406
            //CSAddFriendPacket
            //Non persistent implementation. The friend is not stored onto the server database. 
            Random rnd = new Random();
            ns.Write(rnd.Next(2, 13)); // friend_id

            // friend_name
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(name);
            ns.Write((byte)19); // len
            ns.Write((byte)0); // ???
            for (int i=0; i < 19; i++) // (WriteUTFFixed caused problems)
                ns.Write((i < name.Length ? bytes[i] : (byte)0));

            ns.Write((byte)3); // location
            ns.Write((short)69); // level
            ns.Write((byte)0); // ???
            ns.Write((byte)3); // occupation

            // ???
            for (int i = 0; i < 8; i++)
                ns.Write(0);

            ns.Write((byte)1); // in_party
            ns.Write(1); // is_online
            ns.Write(1); // ???
            ns.Write(551); // message_id
        }
    }
}
 