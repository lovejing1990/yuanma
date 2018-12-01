using ArcheAgeGame.ArcheAge.Network.Connections;
using ArcheAgeGame.ArcheAge.Structuring.NPC;
using LocalCommons.Network;

namespace ArcheAgeGame.ArcheAge.Network.Packets.Server.Utils
{
	public sealed class UnitInfo : NetPacket
	{
		public static void WriteItemInfo(NPC unit)
		{
			//equip_slot 19
			NpcItemInfo(unit.EsHead); //ES_HEAD
			NpcItemInfo(unit.EsNeck); //ES_NECK
			NpcItemInfo(unit.EsChest); //ES_CHEST Нагрудник (ткань, кожа, латы)	23387
			NpcItemInfo(unit.EsWaist); //ES_WAIST
			NpcItemInfo(unit.EsLegs); //ES_LEGS Поножи (ткань, кожа, латы) 23388
			NpcItemInfo(unit.ES_HANDS); //ES_HANDS
			NpcItemInfo(unit.EsFeet); //ES_FEET Обувь (ткань, кожа, латы) 23390
			NpcItemInfo(unit.EsArms); //ES_ARMS
			NpcItemInfo(unit.EsBack); //ES_BACK	
			NpcItemInfo(unit.EsEar1); //ES_EAR_1
			NpcItemInfo(unit.EsEar2); //ES_EAR_2
			NpcItemInfo(unit.EsFinger1); //ES_FINGER_1
			NpcItemInfo(unit.EsFinger2); //ES_FINGER_2
			NpcItemInfo(unit.EsUndershirt); //ES_UNDERSHIRT
			NpcItemInfo(unit.EsUnderpants); //ES_UNDERPANTS
			NpcItemInfo(unit.ES_MAINHAND); //ES_MAINHAND Оружие
			NpcItemInfo(unit.ES_OFFHAND); //ES_OFFHAND Дополнительное оружие
			NpcItemInfo(unit.ES_RANGED); //ES_RANGED Лук
			NpcItemInfo(unit.ES_MUSICAL); //ES_MUSICAL Муз. инструмент (струнный, духовой, ударный)

			ns.Write((int) unit.FaceId); //type[somehow_special] d 19839 face
			ns.Write((int) unit.HairId); //type[somehow_special] d 25372 hair_id
			ns.Write((int) 0); //type[somehow_special] d 
			ns.Write((int) 0); //type[somehow_special] d
			ns.Write((int) 0); //type[somehow_special] d
			ns.Write((int) unit.Body); //type[somehow_special] d 536   body
			ns.Write((int) 0); //type[somehow_special] d

			//equip_slot
			NpcItemInfo(unit.EsBackpack); //ES_BACKPACK
			NpcItemInfo(unit.EsCosplay); //ES_COSPLAY
		}

		private static void NpcItemInfo(int itemId)
		{
			ns.Write((int) itemId); //d
			switch (itemId)
			{
				case 0:
					break;
				default:
					ns.Write((long) 0x00); //id type="Q" 
					ns.Write((byte) 0x00); //grade type="c" 
					break;
			}
		}

		public static void WritePlayerAppearance(NPC unit)
		{
			byte ext = 0;
			ext = unit.TotalCustomId != 0 ? (byte) 3 : (byte) 2;
			ns.Write((byte) ext); //ext c
			switch (ext)
			{
				case 0:
					break;
				case 1:
					ns.Write((int) unit.HairColorId); //type d
					break;
				case 2: //npc
					ns.Write((int) unit.HairColorId); //type d
					ns.Write((int) unit.SkinColorId); //unit.SkinColorId); //type d
					ns.Write((int) 0); //type d
					break;
				default: //actor/npc+
					ns.Write((int) unit.HairColorId); //type d        4299 hair_color_id
					ns.Write((int) unit.SkinColorId); //type d        4    skin_color_id
					ns.Write((int) 0); //type d         0

					ns.Write((int) 0); //type d         0
					ns.Write((float) 1f); //weight f    1
					ns.Write((float) 1f); //scale f     1
					ns.Write((float) 0); //rotate f     0

					ns.Write((short) 0); //moveX h      0
					ns.Write((short) 0); //moveY h      0

					//for (int i = 11; i < 15; i++)
					//{
					ns.Write((int) 0); //type d         0    face_fixed_decal_asset_0_id
					ns.Write((float) 1f); //weight f    1    face_fixed_decal_asset_0_weight
					ns.Write((int) 0); //type d         444  face_fixed_decal_asset_1_id
					ns.Write((float) 1f); //weight f    1    face_fixed_decal_asset_1_weight
					ns.Write((int) 0x0235); //type d    170  face_fixed_decal_asset_2_id
					ns.Write((float) 1f); //weight f    1    face_fixed_decal_asset_2_weight)
					ns.Write((int) 0); //type d         0    face_fixed_decal_asset_3_id
					ns.Write((float) 1f); //weight f    0.71 face_fixed_decal_asset_3_weight
					//}
					ns.Write((int) 0); //type d         0
					ns.Write((int) 0x21); //type d      0 face_normal_map_id
					ns.Write((int) 0); //type d         0
					ns.Write((float) 1f); //weight f    1
					ns.Write((uint) unit.Lip); //lip d  0
					ns.Write((uint) unit.LeftPupil); //leftPupil d       left_pupil_color
					ns.Write((uint) unit.RightPupil); //rightPupil d     right_pupil_color
					ns.Write((uint) unit.Eyebrow); //eyebrow d           eyebrow_color
					ns.Write((uint) unit.Decor); //decor d               deco_color
					//modifiers
					//ns.WriteHex("00FAFDE6F7DFE4553AF82622176437F5009CD934D8FE090800EBF06220BA2325F30E14FDFF02F0DA0FF325D7F516EB0A25C141E1B0D3159CCE0F0315001EFEF545E601043C1427FFED430DD5272A140023FCCB000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", true); //modifiers b
					var str = unit.Modifiers.Substring(0, 256); //надо отрезать в конце два символа \0\0
					ns.WriteHex(str, str.Length); //modifiers b
					break;
			}
		}

		public UnitInfo(byte level, int packetId) : base(level, packetId)
		{
		}
	}
}
