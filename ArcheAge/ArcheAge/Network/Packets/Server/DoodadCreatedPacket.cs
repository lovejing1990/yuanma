using ArcheAgeGame.ArcheAge.World;
using LocalCommons.Network;
using LocalCommons.Utilities;

namespace ArcheAgeGame.ArcheAge.Network.Packets.Server
{
	public class DoodadCreatedPacket : NetPacket
	{
		public DoodadCreatedPacket(Doodad doodad) : base(01, 0x106)
		{
			/*
			  SCDoodadCreatedPacket (штучки - предметы/ресурсы)
              bc     id       bc     bc     attachPoint x      y      z      rotX rotY rotZ scale    hasLootItem type     type     type Q           type     type     growing  plantTime        type     family   puzzleGroup ownerType dbHouseId data                         
              Залежи железа
                     1671                   59                                                                   3054                                                                                                                                         
              363102 87060000 000000 000000 3B          66C079 5A9C74 A7C503 0000 0000 0000 0000803F 00          EE0B0000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              Связка фейерверков
                     2226                   199                                                                  4261                                                                                                                                     
              2A5601 B2080000 000000 000000 C7          D1BA79 5D3974 B1BD03 0000 0000 F39D 0000803F 00          A5100000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              922703 B2080000 000000 000000 00          AAB979 C13974 C4BD03 0000 0000 0000 0000803F 00          A5100000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              Мешок с картофелем
                     2711                   0                                                                    5908                                                                                                                                     
              511C09 9C0A0000 000000 000000 00          9EBA79 E23A74 DABD03 0000 0000 0000 0000803F 00          14170000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              Каштановое дерево                                                                                                                                                                                                                   
                     384                    0                                                                    2692                                                                                                                                     
              0CAB08 80010000 000000 000000 00          101179 F6C574 B84404 0000 0000 3D6D 0000803F 00          840A0000 00000000 0000000000000000 00000000 00000000 963F7702 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              BB0E09 80010000 000000 000000 00          DE0C79 B9DC74 273904 0000 0000 0000 0000803F 00          840A0000 00000000 0000000000000000 00000000 00000000 AB546B02 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000

              065F00 B2140000 000000 000000 00          F3B879 CA3574 73BD03 0D03 DA01 DC82 0000803F 00          8C350000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              796A00 87060000 000000 000000 00          A0E279 FB8975 1A8B03 0000 0000 0000 0000803F 00          EE0B0000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              8D5B02 6B0A0000 000000 000000 00          02357A A21975 4FAD03 585E C7FD 23FE 0000803F 00          81160000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              5C5207 6B0A0000 000000 000000 00          75317A A31475 C9AF03 1D01 D9FF 1AFD 0000803F 00          81160000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              595401 33090000 000000 000000 00          31327A C41475 3DAF03 8450 6604 6D02 0000803F 00          77120000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              6DC308 33090000 000000 000000 00          9C357A 6B1875 BBAD03 2021 3DA4 D9B7 0000803F 00          77120000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              CE9107 FD0A0000 000000 000000 00          6D317A FF1575 84AE03 4BEF 4000 1CFD 0000803F 00          7A180000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              Каштановое дерево                                                                                                                                                                                                                   
                     419                    0                                                                    2007                                                                                                                                     
              2E5E04 A3010000 000000 000000 00          623A7A 135E75 91A203 0000 0000 7956 0000803F 00          7D070000 00000000 0000000000000000 00000000 00000000 91CF9C01 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
              075F00 B2140000 000000 000000 00          6B2B7A 321375 C0AD03 D7FD 1105 5F79 0000803F 00          8C350000 00000000 0000000000000000 00000000 00000000 00000000 0000000000000000 00000000 00000000 FFFFFFFF    FF        00000000  00000000
			*/

			//stream.WriteHex(
			//	"363102870600000000000000003B66C0795A9C74A7C5030000000000000000803F00EE0B000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFFFFFFFF0000000000000000",
			//	false);
			
			//GameNetwork.Instance.Database.LoadDoodadsData(_doodad.Id);

			ns.Write((Uint24)doodad.LiveObjectId); //bc d3
			ns.Write((int)doodad.Id); //id d
			ns.Write((Uint24)0); //bc d3
			ns.Write((Uint24)0); //bc d3
			ns.Write((byte)0); //attachPoint C
			
			ns.Write(LocalCommons.Utilities.Helpers.ConvertX(doodad.Position.X), 0, 3);
			ns.Write(LocalCommons.Utilities.Helpers.ConvertY(doodad.Position.Y), 0, 3);
			ns.Write(LocalCommons.Utilities.Helpers.ConvertZ(doodad.Position.Z), 0, 3);
			
			ns.Write((short) doodad.Direction.X); //rot.x h
			ns.Write((short) doodad.Direction.Y); //rot.y h
			ns.Write((short) doodad.Direction.Z); //rot.z h
			ns.Write((float)doodad.Scale); //scale f
			ns.Write((byte)0); //hasLootItem c
			ns.Write((int)doodad.Type[0]); //type d == указывает что будет отабражено на местности ==
			ns.Write((int)0); //type d
			ns.Write((long)0); //type Q
			ns.Write((int)0); //type d
			ns.Write((int)0); //type d
			ns.Write((int)doodad.GrowthTime); //growing d
			ns.Write((long)0); //plantTime Q
			ns.Write((int)0); //type d
			ns.Write((int)0); //family d
			ns.Write((uint)0x0ffffffff); //puzzleGroup d
			ns.Write((byte)0x0ff); //ownerType C
			ns.Write((int)0); //dbHouseId d
			ns.Write((int)0); //data d
		}
	}
}
