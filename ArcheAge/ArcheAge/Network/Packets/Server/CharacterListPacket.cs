using ArcheAgeGame.ArcheAge.Network.Connections;
using ArcheAgeGame.ArcheAge.Network.Packets.Server.Utils;
using LocalCommons.Network;

namespace ArcheAgeGame.ArcheAge.Network.Packets.Server
{
    public class CharacterListPacket : NetPacket
    {
        public CharacterListPacket(ClientConnection net, int num, int last) : base(01, 0x039)
        {

            var accountId = net.CurrentAccount.AccountId;
	        var charList = net.CurrentAccount.Characters;
			var totalChars = net.CurrentAccount.Characters.Count;

            ns.Write((byte)last); //last c
            if (totalChars == 0)
            {
                ns.Write((byte)0); //count c //если пустой список, заканчиваем работу
            }
            else
            {
                ns.Write((byte)1); //count c
            }

            var aa = 0;
            foreach (var chr in charList)
            {
                if (num == aa) //параметр NUM отвечает, которого чара выводить в пакете (может быть от 0 до 2)
                {

                    ns.Write((int)chr.CharacterId); //type d
                    ns.WriteUTF8Fixed(chr.CharName, chr.CharName.Length); //name S
                    ns.Write((byte)chr.CharRace); //Race c
                    ns.Write((byte)chr.CharGender); //Gender c
                    ns.Write((byte)chr.Level); //level c
                    ns.Write((int)0x001C4); //health d
                    ns.Write((int)0x001CE); //mana d
                    ns.Write((int)chr.StartingZoneId); //zid d
                    ns.Write((int)chr.FactionId); //faction_id d
                    var factionName = ""; //factionName SS
                    ns.WriteUTF8Fixed(factionName, factionName.Length);
                    //-----------------------------
                    ns.Write((int)0x00); //type d
                    ns.Write((int)0x00); //family d
                    //<!--  same as in character packets --> 
                    /*
                    * инвентарь персонажа
                    */
                    CharacterInfo.WriteItemInfo(net, chr);
                    //<!--  same as in character packets ends--> 

                    //for (int i = 0; i < 3; i++)
                    //{
                    ns.Write((byte)chr.Ability[0]); //специализация: 1-FIGHTER нападение, 7-MAGIC волшебство, 6-WILD исцеление,
                                                        //10-LOVE преследование, 5-DEATH мистицизм, 8-VOCATION скрытность
                    ns.Write((byte)chr.Ability[1]); //эффект класса 1
                    ns.Write((byte)chr.Ability[2]); //эффект класса 2
                    //}
                    //position
	                ns.Write((long)LocalCommons.Utilities.Helpers.ConvertLongX(chr.Position.X)); //x Q
	                ns.Write((long)LocalCommons.Utilities.Helpers.ConvertLongY(chr.Position.Y)); //y Q
	                ns.Write((float)chr.Position.Z); //z f


                    //<!--  same as in character packets (2) --> 
	                CharacterInfo.WriteStaticData(net, chr);
                    //<!--  same as in character packets (2) ends --> 

                    ns.Write((short)0x36); //laborPower h  //очки работы = 5000
                    ns.Write((long)0x532F427F); //lastLaborPowerModified Q
                    ns.Write((short)0x00); //deadCount h
                    ns.Write((long)0x532B300C); //deadTime Q
                    ns.Write((int)0x00); //rezWaitDuration d
                    ns.Write((long)0x532B300C); //rezTime Q
                    ns.Write((int)0x00); //rezPenaltyDuration d
                    ns.Write((long)0x532F41B4); //lastWorldLeaveTime Q
                    ns.Write((long)0xC2); //moneyAmount Q  Number of copper coins Automatic 1:100:10000 Convert gold coins  //серебро, золото и платина (начало)
                    ns.Write((long)0x00); //moneyAmount Q //серебро, золото и платина (продолжение)
                    ns.Write((short)0x00); //crimePoint h
                    ns.Write((int)0x00); //crimeRecord d
                    ns.Write((short)0x00); //crimeScore h
                    ns.Write((long)0x00); //deleteRequestedTime Q
                    ns.Write((long)0x00); //transferRequestedTime Q
                    ns.Write((long)0x00); //deleteDelay Q
                    ns.Write((int) 0x07); //consumedLp d
                    ns.Write((long)0x1E); //bmPoint Q  //монеты дару = 30
                    //ns.Write((int)0x00); //consumedLp d ?
                    //ns.Write((int)0x00); //? пришлось вставить для выравнивания длины пакета
                    ns.Write((long)0x00); //moneyAmount Q
                    ns.Write((long)0x00); //moneyAmount Q
                    ns.Write((byte)0x00); //autoUseAApoint A"
					ns.Write((int)0x00); //prevPoint
					ns.Write((int)0x00); //point d
                    ns.Write((int)0x00); //gift d
                    ns.Write((long)0x00532F3FB3); //updated Q
                }
                ++aa;
            }
        }
    }
}
