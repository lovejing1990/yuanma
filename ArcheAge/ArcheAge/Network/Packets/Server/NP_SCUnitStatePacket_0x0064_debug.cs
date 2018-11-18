using System;
using System.Collections.Generic;
using ArcheAgeGame.ArcheAge.Structuring.NPC;
using LocalCommons.Logging;
using LocalCommons.Network;
using LocalCommons.Utilities;

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
			try
			{


				foreach (NPC npc in list)
				{
					if (npc == null)
					{
						continue;
					}

					//opcode
					ns.Write((short)0x64);
					if (npc.LiveObjectID == 0)
					{
						//获取当前NPC的在线索引
						int index = NPCs.OnlineNPCList.IndexOf(npc);

						//获取LiveObjectID
						npc.LiveObjectID = ArcheAgeGame.LiveObjectUid.Next();
						
						//更新当前NPC
						NPCs.OnlineNPCList[index] = npc;
					}
						
					//liveobjectid
					ns.Write(npc.LiveObjectID);
					//len
					ns.Write((short)0x0000);
					//type
					ns.Write((byte)0x01);
					///bc 我不知道BC代表什么意思
					//ns.Write((Uint24)0x9BE500);
					ns.Write(npc.LiveObjectID);
					ns.Write(npc.ID);
					//tpye 2
					ns.Write(0);
					ns.Write((short)0);
					ns.Write(LocalCommons.Utilities.Helpers.ConvertX(npc.Position.X), 0, 3);
					ns.Write(LocalCommons.Utilities.Helpers.ConvertY(npc.Position.Y), 0, 3);
					ns.Write(LocalCommons.Utilities.Helpers.ConvertZ(npc.Position.Z), 0, 3);
					byte[] Scale = (byte[])BitConverter.GetBytes(npc.Scale);
					ns.Write(Scale);
					//ns.WriteHex("0000803F");//100%=>1065353216  90%=>1064514355
					ns.Write(npc.Level);
					ns.Write(npc.ModelID);
					//未知
					ns.WriteHex("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
					//未知
					ns.WriteHex("02B0A473020200000000000000000000");
					//HP  1.00
					ns.Write(100*100);
					//MP
					ns.Write(100*100);
					//
					ns.WriteHex("FFFF");
					//姿势 NPC独有  怪兽没有
					ns.Write((short)0x04);//len
					ns.WriteHex("3E000000");
					//姿势 动作 
					ns.Write((byte)0x01);//len
					ns.Write((byte)0x0);

					//
					//ns.Write((short)0x0201);
					ns.WriteHex("010200000001000000000000");

					//rot
					ns.Write((byte)0xB0);

					//
					ns.WriteHex("000800A66201000000");
					//factionID
					ns.Write(npc.FactionId);

					ns.WriteHex("0000000000000000");



				}
			}
			catch(Exception ex)
			{
				Log.Exception(ex, "Write NPCs Send Stream Error");
			}

		}
    }
}


