using AAEmu.Commons.Network;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Core.Packets.World.S2C.Utils;

namespace AAEmu.Game.Core.Packets.World.S2C
{
    public class CharacterStatePacket : GamePacket
    {
        private readonly uint _characterId;
        public CharacterStatePacket(uint characterId) : base(0x03B, GamePacketLevel.World)
        {
            _characterId = characterId;
        }

        public override PacketStream Write(PacketStream stream)
        {
			//stream.WriteHex(
			// //"A005 DD01 3B00" +
			// "000000001000DC0D0CFCD3E01847AD2A5D55EA471CDF00000000" +
			// "02000000" +
			// "06006E6577626965010101C4010000CE010000B3000000650000000000000000000000000000000000000000005B5B0000090000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B00000A0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00000B0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C11500000C0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000081800000D0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000EF1700000E0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000211800000F0000000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007E4D0000455E000000000000000000000000000018020000000000000000000000000000010B0B00000000B09ECC0300000000E43CBF0314AF004303DD0200000100000000000000000000000000803F0000803F0000000000000000000000000000803F000000000000803F300200000000803FAA0200000000803F000000001D000000000000000000803F000000005AB5F8FF5AB5F8FF3C2300FF603E48FF800000F5000011DC000B00000000170000000000F323000000003D0000000000000000000000000000000000000000000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000036007F422F530000000000000C302B5300000000000000000C302B530000000000000000B4412F5300000000C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001E00000000000000000000000000000000000000000000000000000000000000000000000000000000B33F2F53000000000000000000000000DBFB17C0DBFB170C920700000000000000000000560100004600000000000000000000000000000000000000000000000000000000000000920700000000000000000000000000000000000000000000323200C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C72C000022A21C530000000000"
			// , false);
			//return stream;

			var chr = this.Connection.SelectedCharacter;
	        //var chr = GameNetwork.Instance.Database.GetCharacter(_characterId);
            stream.Write((int)0); //iid d
            var guid = chr.Guid;// "0E4FC3755AE17949B1F626620F354A93";
            stream.WriteHex(guid); //guid_len h, guid b
            stream.Write((int)0); //rwd d
            stream.Write((int)chr.Id); //type d
            stream.Write(chr.Name); //name S

            stream.Write((byte)chr.Race); //Race c
            stream.Write((byte)chr.Gender); //Gender c
            stream.Write((byte)chr.Level); //level c
            stream.Write((int)chr.Hp); //health d 0x001C4
            stream.Write((int)chr.Mp); //mana d 0x001CE
            stream.Write((int)chr.StartingZoneId); //zid d
            stream.Write((int)chr.FactionId); //faction_id d
            var factionName = ""; //factionName SS
            stream.Write(factionName);
            //-----------------------------
            stream.Write((int)0x00); //type d
            stream.Write((int)0x00); //family d
            //for 19
	        //<!--  same as in character packets --> 
            UnitInfo.WriteItemInfo(stream, chr); //инвентарь персонажа
            //<!--  same as in character packets ends --> 
			//rof
	        stream.Write((byte)chr.Ability[0]); //специализация: 1-FIGHTER нападение, 7-MAGIC волшебство, 6-WILD исцеление, 10-LOVE преследование, 5-DEATH мистицизм, 8-VOCATION скрытность
            stream.Write((byte)chr.Ability[1]); //эффект класса 1
            stream.Write((byte)chr.Ability[2]); //эффект класса 2

            //position
            stream.Write((long)Helpers.ConvertLongX(chr.Position.X)); //x Q
            stream.Write((long)Helpers.ConvertLongY(chr.Position.Y)); //y Q
            stream.Write((float)chr.Position.Z); //z f

            //<!--  same as in character packets (2) --> 
            UnitInfo.WritePlayerAppearance(stream, chr);
            //<!--  same as in character packets (2) ends --> 

            stream.Write((short)0x36); //laborPower h  //очки работы = 5000
            stream.Write((long)0x532F427F); //lastLaborPowerModified Q
            stream.Write((short)0x00); //deadCount h
            stream.Write((long)0x532B300C); //deadTime Q
            stream.Write((int)0x00); //rezWaitDuration d
            stream.Write((long)0x532B300C); //rezTime Q
            stream.Write((int)0x00); //rezPenaltyDuration d
            stream.Write((long)0x532F41B4); //lastWorldLeaveTime Q
            stream.Write((long)0xC2); //moneyAmount Q  Number of copper coins Automatic 1:100:10000 Convert gold coins  //серебро, золото и платина (начало)
            stream.Write((long)0x00); //moneyAmount Q //серебро, золото и платина (продолжение)
            stream.Write((short)0x00); //crimePoint h
            stream.Write((int)0x00); //crimeRecord d
            stream.Write((short)0x00); //crimeScore h
            stream.Write((long)0x00); //deleteRequestedTime Q
            stream.Write((long)0x00); //transferRequestedTime Q
            stream.Write((long)0x00); //deleteDelay Q
            stream.Write((int) 0x07); //consumedLp d
            stream.Write((long)0x1E); //bmPoint Q  //монеты дару = 30
            stream.Write((long)0x00); //moneyAmount Q
            stream.Write((long)0x00); //moneyAmount Q
            stream.Write((byte)0x00); //autoUseAApoint A"
	        stream.Write((int)0x00); //prevPoint
            stream.Write((int)0x00); //point d
            stream.Write((int)0x00); //gift d
            stream.Write((long)0x00532F3FB3); //updated Q //B33F2F5300000000
            
            //Heading
            stream.Write((float)chr.Heading.X); //angles[0] f //00000000
            stream.Write((float)chr.Heading.Y); //angles[1] f //00000000
	        stream.Write((float)chr.Heading.Z); //angles[2] f //00000000
            //stream.WriteHex("DBFB17C0"); //angles[2] f //DBFB17C0

            stream.Write((int)0x0792); //exp d //92070000
            stream.Write((int)0x0792); //recoverableExp d //00000000
            stream.Write((int)0x00); //returnDistrictId d //00000000
            stream.Write((int)0x00); //returnDistrict d   //56010000
            stream.Write((int)0x0156); //resurrectionDistrict d //46000000
            stream.Write((int)0x46); //abilityExp[0] d //00000000
            stream.Write((int)0x00); //abilityExp[1] d //00000000
            stream.Write((int)0x00); //abilityExp[2] d //00000000
            stream.Write((int)0x00); //abilityExp[3] d //00000000
            stream.Write((int)0x00); //abilityExp[4] d //00000000
            stream.Write((int)0x00); //abilityExp[5] d //00000000
            stream.Write((int)0x00); //abilityExp[6] d //00000000
            stream.Write((int)0x00); //abilityExp[7] d //92070000
            stream.Write((int)0x00); //abilityExp[8] d //00000000
            stream.Write((int)0x00); //abilityExp[9] d //00000000
            stream.Write((int)0x00); //abilityExp[10] d //00000000
            stream.Write((int)0x00); //unreadMail d //00000000
            stream.Write((int)0x00); //unreadMiaMail d //00000000
            stream.Write((int)0x00); //unreadCommercialMail d //00000000
            stream.Write((byte)0x32); //numInvenSlots c //32
            stream.Write((short)0x0032); //numBankSlots h //3200
            stream.Write((long)0xc2); //moneyAmount Q //C200000000000000
            stream.Write((long)0x00); //moneyAmount Q //0000000000000000
            stream.Write((long)0x00); //moneyAmount Q //0000000000000000
            stream.Write((long)0x00); //moneyAmount Q //0000000000000000
            stream.Write((byte)0x00); //autoUseAAPoint C //00
            stream.Write((int)0x00); //juryPoint d //00000000
            stream.Write((int)0x00); //jailSeconds d //00000000
            stream.Write((long)0x00); //bountyMoney Q //0000000000000000
            stream.Write((long)0x00); //bountyTime Q //0000000000000000
            stream.Write((int)0x00); //reportedNo d //00000000
            stream.Write((int)0x00); //suspectedNo d //00000000
            stream.Write((int)0x2CC7); //totalPlayTime d //C72C0000 
            stream.Write((long)0x531CA222); //createdTime Q //22A21C5300000000
            stream.Write((byte)0x00); //expandedExpert C //00

            return stream;
        }
    }
}
