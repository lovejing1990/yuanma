using LocalCommons.Network;
using LocalCommons.Utilities;
using ArcheAgeGame.ArcheAge.Network.Connections;
using ArcheAgeGame.ArcheAge.Network.Packets.Server.Utils;
using LocalCommons.World;
using ArcheAgeGame.ArcheAge.Structuring.NPC;
using System.Collections.Generic;

namespace ArcheAgeGame.ArcheAge.Network
{
    public sealed class NP_SCUnitStatePacket_0x0064_debug : NetPacket
    {
        public NP_SCUnitStatePacket_0x0064_debug(List<NPC> list) : base(04, 0x0009)
        {
			/**
			 * DD00
			 * dd01
			 * 6400 opcode
			 * 040F00 liveObjectID
			 * 0000
			 * 01
			 * 3ED500
			 * 0d0e0000
			 * 00000000
			 * 0000
			 * E69479
			 * A4F477
			 * 267A03
			 * 0000803F
			 * 15
			 * 3801
			0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000220C816430200000000000000000000204E0000B8880000FFFF00000001020000000100000000000029000400D812000000730000000000000000000000
			*/
            foreach(NPC npc in list)
			{
				//opcode
				ns.Write((short)0x64);
				if(npc.LiveObjectID==0)
					npc.LiveObjectID = ArcheAgeGame.LiveObjectUid.Next();
				//liveobjectid
				ns.Write(npc.LiveObjectID);
				//len
				ns.Write((short)0x0000);
				//type
				ns.Write((byte)0x01);
				///bc
				ns.Write((Uint24)0x9BE500);
				ns.Write(npc.ID);
				//tpye 2
				ns.Write(0);
				ns.Write((short)0);
				ns.Write(LocalCommons.Utilities.Helpers.ConvertX(npc.Position.X), 0, 3);
				ns.Write(LocalCommons.Utilities.Helpers.ConvertY(npc.Position.Y), 0, 3);
				ns.Write(LocalCommons.Utilities.Helpers.ConvertZ(npc.Position.Z), 0, 3);
				//ns.Write(npc.Scale);
				ns.WriteHex("0000803F");
				ns.Write(npc.Level);
				ns.Write(npc.ModelID);
				ns.WriteHex("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002B0A473020200000000000000000000D8590000B8880000FFFF04003E0000000100010200000001000000000000B0000800A66201000000650000000000000000000000");

			}
        }
    }
}


