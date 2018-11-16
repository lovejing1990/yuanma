using LocalCommons.Logging;
using LocalCommons.Network;
using LocalCommons.Utilities;
using LocalCommons.World;
using System;
using System.Collections.Generic;
using System.Linq;
using ArcheAgeGame.ArcheAge.Holders;
using ArcheAgeGame.ArcheAge.Network.Connections;
using ArcheAgeGame.ArcheAge.Network.Packets.Server;
using ArcheAgeGame.ArcheAge.Structuring;
using System.IO;
using System.Threading;
using ArcheAgeGame.ArcheAge.Structuring.NPC;

namespace ArcheAgeGame.ArcheAge.Network
{
	///<summary>
	///Delegate List That Contains Information About Received Packets.
	///Contains a list of delegates that receive packet information.
	///</summary>
	public static class DelegateList
	{
		private static string _clientVersion;
		private static int _mMaintained;
		private static PacketHandler0<LoginConnection>[] _mLHandlers;
		//private static PacketHandler<ClientConnection>[] _mCHandlers;
		private static Dictionary<int, PacketHandler0<ClientConnection>[]> _levels;
		private static LoginConnection _mCurrentLoginServer;

		//public static List<Character> CharacterList = new List<Character>(); //здесь будет храниться список персонажей для текущеко account

		private static bool enter1;
		private static bool enter2;
		private static bool enter3;
		private static bool enter4;
		private static bool enter5;
		private static bool enter6;
		private static bool enter7;
		private static bool enter8;
		private static bool enter9;
		private static bool once2;
		private static bool once3;
		private static bool once4;
		private static bool once5;
		private static bool once6;

		public static LoginConnection CurrentLoginServer
		{
			get { return _mCurrentLoginServer; }
		}

		public static Dictionary<int, PacketHandler0<ClientConnection>[]> ClientHandlers
		{
			get { return _levels; }
		}

		public static PacketHandler0<LoginConnection>[] LHandlers
		{
			get { return _mLHandlers; }
		}

		public static void Initialize(string clientVersion)
		{
			_clientVersion = clientVersion;
			_mLHandlers = new PacketHandler0<LoginConnection>[0x20];
			//m_LHandlers = new PacketHandler<ClientConnection>[0x30];
			_levels = new Dictionary<int, PacketHandler0<ClientConnection>[]>();

			once2 = true; //если false, то больше не повторять
			once3 = true; //если false, то больше не повторять
			once4 = true; //если false, то больше не повторять
			once5 = true; //если false, то больше не повторять
			once6 = true; //если false, то больше не повторять
			enter1 = false; //если true, то больше не повторять
			enter4 = false; //если true, то больше не повторять
			enter5 = false; //если true, то больше не повторять
			enter6 = false; //если true, то больше не повторять
			enter7 = false; //если true, то больше не повторять
			enter8 = false; //если true, то больше не повторять
			enter9 = false; //если true, то больше не повторять

			RegisterDelegates();
		}
		///<summary>
		///Registration service
		///Using - Packet Level - Packet Opcode(short) - Receive Delegate
		///</summary>
		private static void RegisterDelegates()
		{
			//-------------- Login - Game Communication Packets ------------
			//Game Communication Service
			Register(0x00, Handle_GameRegisterResult); //Taken Fully
			Register(0x01, (net, reader) => Handle_AccountInfoReceived(_clientVersion, net, reader)); //Taken Fully
			switch (_clientVersion)
			{
				//-------------- Client Communication Packets ------------------
				//Client Communication Service
				//-------------- Using - Packet Level - Packet Opcode(short) - Receive Delegate -----
				case "1": //1.0.1406 Feb 11 2014
						  //Using: Level-Opcode(short) ---------- Receive Delegate -----
					Register(0x01, 0x0000, (net, reader) => OnPacketReceive_0x01_X2EnterWorld_0x0000(_clientVersion, net, reader)); //01
					Register(0x01, 0x001F, OnPacketReceive_0x01_CSListCharacter_0x001F); //04
					//Entrance to the world
					Register(0x01, 0x0020, OnPacketReceive_0x01_CSRefreshInCharacterList_0x0020); //05
					Register(0x01, 0x0116, OnPacketReceive_0x01_CSRestrictCheck_0x0116); //06
					Register(0x01, 0x0024, OnPacketReceive_0x01_CSSelectCharacter_0x0024); //07
					Register(0x01, 0x00FB, OnPacketReceive_0x01_CSSetLpManageCharacter_0x00FB); //08
					Register(0x01, 0x0025, OnPacketReceive_0x01_CSSpawnCharacter_0x0025); //13 task
					//other
					Register(0x01, 0x0001, OnPacketReceive_0x01_CSLeaveWorld_0x0001);
					Register(0x01, 0x0021, OnPacketReceive_0x01_CSCreateCharacter_0x0021);
					Register(0x01, 0x0023, OnPacketReceive_0x01_CSDeleteCharacter_0x0023);
					Register(0x01, 0x0027, OnPacketReceive_0x01_CSNotifyInGame_0x0027); //14

					Register(0x01, 0x0028, OnPacketReceive_0x01_CSNotifyInGame_0x0028);// 15 welcome

					Register(0x01, 0x0061, OnPacketReceive_0x01_NP_CSChatPacket_0x0061);//收到客户机信息

					Register(0x01, 0x0088, OnPacketReceive_0x01_NP_CSMoveUnitPacket_0x0088);//角色动作

					//task 
					Register(0x01, 0x00D3, OnPacketReceive_0x01_NP_CSGiveupTaskPacket_0x00D3);//Give up the task
					Register(0x01, 0x0114, OnPacketReceive_0x01_NP_CSGiveupTaskPacket_0x0114);//task window state

					//02
					Register(0x02, 0x0001, (net, reader) => OnPacketReceive_0x02_FinishState_0x0001(_clientVersion, net, reader)); //02, 03, 09, 10, 11, 12, 14, 15
					Register(0x02, 0x0012, OnPacketReceive_0x02_Ping_0x0012); //
					break;
				case "3": //3.0.3.0
						  //Using: Level-Opcode(short) ---------- Receive Delegate -----
					Register(0x01, 0x0000, (net, reader) => OnPacketReceive_0x01_X2EnterWorld_0x0000(_clientVersion, net, reader)); //+
					Register(0x02, 0x0012, OnPacketReceive_0x02_Ping_0x0012); //+
					Register(0x02, 0x0001, (net, reader) => OnPacketReceive_0x02_FinishState_0x0001(_clientVersion, net, reader)); //+
					Register(0x01, 0xE4FB, OnPacketReceive_ClientE4FB);
					Register(0x01, 0x0D7C, OnPacketReceive_Client0D7C);
					Register(0x01, 0xE17B, OnPacketReceive_ClientE17B);
					Register(0x05, 0x0438, OnPacketReceive_Client0438);
					Register(0x05, 0x0088, OnPacketReceive_ReloginRequest_0x0088);
					//Entrance to the world временные пакеты, пока нет расшифровки
					Register(0x05, 0x008A, OnPacketReceive_EnterWorld_0x008A); //вход в игру1
					Register(0x05, 0x008B, OnPacketReceive_EnterWorld_0x008B); //вход в игру2
					Register(0x05, 0x008C, OnPacketReceive_EnterWorld_0x008C); //вход в игру3
					Register(0x05, 0x008D, OnPacketReceive_EnterWorld_0x008D); //вход в игру4
					Register(0x05, 0x008E, OnPacketReceive_EnterWorld_0x008E); //вход в игру5
					Register(0x05, 0x008F, OnPacketReceive_EnterWorld_0x008F); //вход в игру6
					break;
				default:
					break;
			}
		}
		#region Client Callbacks Implementation

		///<summary>
		///Обновить количество персонажей на аккаунте
		///</summary>
		///<param name="net"></param>
		///<param name="accountId"></param>
		///<param name="count"></param>
		private static void Handle_UpdateCharacters(ClientConnection net, uint accountId, int totalCars)
		{
			var currentAcc = AccountHolder.AccountList.FirstOrDefault(n => n.AccountId == accountId);
			currentAcc.CharactersCount = (byte)totalCars;
			AccountHolder.InsertOrUpdate(currentAcc);
		}

		private static void OnPacketReceive_0x01_CSSetLpManageCharacter_0x00FB(ClientConnection net, PacketReader reader)
		{

			//CharacterList = CharacterHolder.LoadCharacterData(net.CurrentAccount.AccountId,net); //считываем данные имеющихся персонажей на аккаунте

			var characterId = reader.ReadLEUInt32(); //characterId D считываем UID выбранного (входящего в мир) персонажа

			//считаем его данные
			foreach (var chr in net.CurrentAccount.Characters)
			{
				if (chr.CharacterId == characterId)
				{
					CharacterHolder.LoadEquipPacksData(chr, chr.Ability[0]); //дополнительно прочитать NewbieClothPackId, NewbieWeaponPackId из таблицы character_equip_packs
					CharacterHolder.LoadClothsData(chr, chr.NewbieClothPackId); //дополнительно прочитать Head,Chest,Legs,Gloves,Feet из таблицы equip_pack_cloths
					CharacterHolder.LoadWeaponsData(chr, chr.NewbieWeaponPackId); //дополнительно прочитать Weapon,WeaponExtra,WeaponRanged,Instrument из таблицы equip_pack_weapons
					CharacterHolder.LoadCharacterBodyCoord(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать body, x, y, z из таблицы charactermodel
					CharacterHolder.LoadZoneFaction(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать FactionId,StartingZoneId из таблицы characters

					net.CurrentAccount.Character = chr; //сохраним для дальнейшего использования
				}
			}
		}

		private static void CharacterListPacket(string clientVersion, ClientConnection net)
		{
			var accountId = net.CurrentAccount.AccountId;
			//net.CurrentAccount.Characters = CharacterHolder.LoadCharacterData(accountId,net);
			var totalChars =net.CurrentAccount.Characters.Count();
			switch (clientVersion)
			{
				case "1":
					if (totalChars == 0)
					{
						net.SendAsync(new NP_CharacterListPacket_0x0039(net, 0, 1));
					}
					else
					{
						for (var i = 0; i < totalChars; i++)
						{
							net.SendAsync(new NP_CharacterListPacket_0x0039(net, i, i == totalChars - 1 ? 1 : 0));
						}
					}
					break;
				case "3":
					if (totalChars == 0)
					{
						net.SendAsync(new NP_0x05_CharacterListPacket_0x0079(net, 0, 1));
					}
					else
					{
						for (var i = 0; i < totalChars; i++)
						{
							net.SendAsync(new NP_0x05_CharacterListPacket_0x0079(net, i, i == totalChars - 1 ? 1 : 0));
						}
					}
					break;
			}
		}

		private static void OnPacketReceive_0x01_CSDeleteCharacter_0x0023(ClientConnection net, PacketReader reader)
		{
			//"Recv: 0800 0001 2300 FF091A00
			var characterId = reader.ReadLEUInt32(); //characterId D

			var deleteStatus = 1; // 1 - сразу удалет  2 - запускает таймер
			net.SendAsync(new NP_SCDeleteCharacterResponse_0x0034(characterId, deleteStatus)); //удаляем выбранного персонажа

			if (deleteStatus == 1)
			{
				//Немедленное удаление данных!
				CharacterHolder.DeleteCharacterData(characterId); //удаляем запись с заданным UID персонажа из базы
				ArcheAgeGame.CharcterUid.ReleaseUniqueInt(characterId); //освобождаем неиспользуемый uid
			}
			else
			{
				//TODO: сделать таймер удаления персонажа из БД
			}
			//CharacterListPacket(_clientVersion, net);
		}

		private static void OnPacketReceive_0x01_NP_CSMoveUnitPacket_0x0088(ClientConnection net, PacketReader reader)
		{
			//                     bc     type time     flags ix     iy     iz     vel.x vel.y vel.z rot.x rot.y rot.z a.dm.x a.dm.y a.dm.z a.stance a.alertness a.flags
			//Recv: 2500 0001 8800 F52700 01   9F751900 02    0B3D82 650E76 62BD03 E107  77FA  DC03  00    00    D9    00     7F     00     01       00          04

			//                     bc     type time     flags ix     iy     iz     vel.x vel.y vel.z rot.x rot.y rot.z a.dm.x a.dm.y a.dm.z a.stance a.alertness a.flags
			//      2500 0001 8800 2D0801 01   336D0200 00    097C7A 248775 499503 0000  0000  0000  00    00    C4    00     00     00     01       00          00
			//      2500 0001 8800 2D0801 01   E96D0200 04    097C7A 248775 499503 0000  0000  0000  00    00    C4    00     00     00     01       00          14

			var bc = reader.ReadUInt24();//LiveObject
			byte type = reader.ReadByte();
			int time = reader.ReadLEInt32();
			byte flag = reader.ReadByte();
			//reader.Offset += 6; 

			var x = LocalCommons.Utilities.Helpers.ConvertX(reader.ReadByteArray(3)) + 1.0f;
			var y = LocalCommons.Utilities.Helpers.ConvertY(reader.ReadByteArray(3)) + 1.0f;
			var z = LocalCommons.Utilities.Helpers.ConvertZ(reader.ReadByteArray(3));
			net.CurrentAccount.Character.Position = new Position(x, y, z); //сохраним позицию

			reader.Offset += 6; //
			short rotx = reader.ReadByte();
			short roty = reader.ReadByte();
			short rotz = reader.ReadByte();
			net.CurrentAccount.Character.Heading = new Direction(rotx, roty, rotz); //сохраним направление взгляда

			CharacterHolder.InsertOrUpdate(net.CurrentAccount.Character,net); //записываем в базу character_records

			//net.SendAsync(new NP_SCUnitMovementsPacket_0x0066(net));

			//MoveUnit

			String move = Utility.ByteArrayToString(reader.Buffer);
			move = move.Substring(7*2,move.Length-7*2-2);
			foreach (KeyValuePair<int, Account> account in ClientConnection.CurrentAccounts)
			{
				//If role is not online, it will not be sent.
				if (account.Value.Character != null)
				{
					account.Value.Connection.SendAsync(new NP_SCUnitMovementsPacket_0x0066(net, move));
				}

			}

			// 根据条件判断是否加载NPC
			if(net.CurrentAccount.Character.LastLoadedNPC.X-x>25|| net.CurrentAccount.Character.LastLoadedNPC.X - x < 25
				||
				net.CurrentAccount.Character.LastLoadedNPC.Y - y > 25 || net.CurrentAccount.Character.LastLoadedNPC.Y - y < 25)
			{
				//todo 待完成 2018年11月16日
			}

			////查询NPC，AND Send to Client

			//Thread thread = new Thread(new ThreadStart(method));//创建线程

			//thread.Start();                                                           //启动线程
		}

		//OnPacketReceive_0x01_NP_CSGiveupTaskPacket_0x00D3
		/// <summary>
		/// 放弃任务
		/// </summary>
		/// <param name="net"></param>
		/// <param name="reader"></param>
		private static void OnPacketReceive_0x01_NP_CSGiveupTaskPacket_0x00D3(ClientConnection net, PacketReader reader)
		{
			//read task ID
			int taskID = reader.ReadLEInt32();
			Log.Info(net.CurrentAccount.Character.CharName + " [Give up the Taks]：" + taskID.ToString());
		}
		/// <summary>
		/// quest_window 
		/// 任务窗口相关信息包括 任务快捷列表 勾选状态 打开状态 折叠状态 关闭状态等等等等
		/// </summary>
		/// <param name="net"></param>
		/// <param name="reader"></param>
		private static void OnPacketReceive_0x01_NP_CSGiveupTaskPacket_0x0114(ClientConnection net, PacketReader reader)
		{
			short queryNameLen = reader.ReadLEInt16();
			string queryName = reader.ReadUTF8StringSafe(queryNameLen);
			Log.Debug(net.CurrentAccount.Character.CharName+">>"+queryName);
		}

		///<summary>
		///CSCreateCharacter_0x0021
		///</summary>
		///<param name="net"></param>
		///<param name="reader"></param>
		private static void OnPacketReceive_0x01_CSCreateCharacter_0x0021(ClientConnection net, PacketReader reader)
		{
			var newCharacter = new Character();
			newCharacter.AccountId = net.CurrentAccount.AccountId; //куда записывать параметры нового персонажа

			//len  name      
			//Recv: 1801 0001 2100 0900 72656D6F746164696E 01 02 7F4D0000 1C630000 00000000 00000000 00000000 00000000 00000000 03 CB100000 04 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F BC 01 00 00 00 00 80 3F AA 00 00 00 00 00 80 3F 00 00 00 00 8F C2 35 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F E3 7B 8B FF AF EC EF FF AF EC EF FF 58 48 38 FF 00 00 00 00 80 00 00 EF 00 EF 00 EE 00 01 03 00 00 00 00 00 00 11 00 00 00 00 00 FE 00 06 3B B9 00 D8 00 EE 00 D4 00 28 1B EB E1 00 E7 00 F0 37 23 00 00 00 00 00 64 00 00 00 00 00 00 00 64 00 00 00 F0 00 00 00 00 00 00 00 2B D5 00 00 00 64 00 00 00 00 F9 00 00 00 E0 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 08 0B 0B 01
			//Recv: 1401 0001 2100 0500 6172747572         01 01 7E4D0000 455E0000 00000000 00000000 00000000 00000000 00000000 03 DD020000 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 80 3F 30 02 00 00 00 00 80 3F AA 02 00 00 00 00 80 3F 00 00 00 00 1D 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 5A B5 F8 FF 5A B5 F8 FF 3C 23 00 FF 60 3E 48 FF 80 00 00 F5 00 00 11 DC 00 0B 00 00 00 00 17 00 00 00 00 00 F3 23 00 00 00 00 3D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 0B 0B 01
			//Recv: 1201 0001 2100 0300 71617A             06 02 964E0000 753F0000 00000000 00000000 00000000 00000000 00000000 03 83 08 00 00 0B 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 65 03 00 00 00 00 80 3F 39 03 00 00 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F C0 00 2B FF 00 5D BC FF 00 5D BC FF FF E5 F7 FF 00 00 00 00 80 00 00 FD 64 26 53 1C 41 AD 00 21 00 00 AB 00 00 2D 00 5A 64 FC 00 00 00 0E 64 10 00 00 00 19 63 00 10 33 AE ED 04 00 07 00 E1 00 11 B7 13 16 26 00 B6 1D 28 C6 E7 FA 00 D6 0A 2B 00 FE DB 14 12 06 00 F4 9C 9C 64 00 64 9C D4 E8 00 01 33 00 00 00 00 00 C5 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 0B 0B 01
			var len = reader.ReadLEInt16(); //name s
			newCharacter.CharName = reader.ReadString(len); //имя персонажа

			//проверка на существования имя персонажа
			//Character testCharacter = CharacterHolder.GetCharacter(newCharacter.CharName);
			//Character testCharacter = CharacterHolder.LoadCharacterData(newCharacter.CharName);
			//if (testCharacter != null && testCharacter.CharName != null)
			//Character testCharacter = CharacterHolder.LoadCharacterData(newCharacter.CharName);
			if (CharacterHolder.CharacterExists(newCharacter.CharName))
			{
				net.SendAsync(new NP_SCCharacterCreationFailed_0x0038(net));
				return; //завершаем работу, такой чар уже есть
			}

			//CharRace c
			newCharacter.CharRace = reader.ReadByte(); //раса персонажа
													   //CharGender c
			newCharacter.CharGender = reader.ReadByte(); //пол персонажа
														 //цикл по equip персонажа
			for (var i = 0; i < 7; i++)
			{
				newCharacter.Type[i] = reader.ReadLEInt32(); //type[somehow_special] d
			}

			newCharacter.CharacterId = ArcheAgeGame.CharcterUid.Next();

			var ext = reader.ReadByte(); //ext c
			newCharacter.Ext = ext;
			switch (ext)
			{
				case 0:
					break;
				case 1:
					newCharacter.Type[7] = reader.ReadLEInt32(); //type d
					break;
				case 2:
					newCharacter.Type[7] = reader.ReadLEInt32(); //type d
					newCharacter.Type[8] = reader.ReadLEInt32(); //type d
					newCharacter.Type[9] = reader.ReadLEInt32(); //type d
					break;
				default: //- <case id="default">
					newCharacter.Type[7] = reader.ReadLEInt32(); //type d
					newCharacter.Type[8] = reader.ReadLEInt32(); //type d
					newCharacter.Type[9] = reader.ReadLEInt32(); //type d
					newCharacter.Type[10] = reader.ReadLEInt32(); //type d
					newCharacter.Weight[10] = reader.ReadLESingle(); //в них 0-9 нет данных, 10 //weight f
					newCharacter.Scale = reader.ReadLESingle();    //scale f
					newCharacter.Rotate = reader.ReadLESingle();   //rotate f
					newCharacter.MoveX = reader.ReadLEUInt16();    //moveX h
					newCharacter.MoveY = reader.ReadLEUInt16();    //moveY h
					for (var i = 11; i < 15; i++)
					{
						newCharacter.Type[i] = reader.ReadLEInt32();    //11, 12, 13, 14 //type d
						newCharacter.Weight[i] = reader.ReadLESingle(); //11, 12, 13, 14 //weight f
					}
					newCharacter.Type[15] = reader.ReadLEInt32(); //type d
					newCharacter.Type[16] = reader.ReadLEInt32(); //type d
					newCharacter.Type[17] = reader.ReadLEInt32(); //type d
					newCharacter.Weight[17] = reader.ReadLESingle(); //в них 17, 15-16 нет данных //weight f
					newCharacter.Lip = reader.ReadLEInt32(); //lip d
					newCharacter.LeftPupil = reader.ReadLEInt32(); //leftPupil d
					newCharacter.RightPupil = reader.ReadLEInt32(); //rightPupil d
					newCharacter.Eyebrow = reader.ReadLEInt32(); //eyebrow d
					newCharacter.Decor = reader.ReadLEInt32(); //decor d
					var modifiersLen = reader.ReadLEInt16(); //modifiers_len h
					byte[] modfr;
					modfr = reader.ReadByteArray(modifiersLen); //modifiers b
																//добавляется в конце два символа \0\0 !
					newCharacter.Modifiers = Utility.ByteArrayToString(modfr); //newCharacter.Modifiers = reader.ReadHexString(modifiersLen);
					break;
			}
			newCharacter.Ability[0] = reader.ReadByte(); //a[0] c
			newCharacter.Ability[1] = reader.ReadByte(); //a[1] c
			newCharacter.Ability[2] = reader.ReadByte(); //a[2] c
			newCharacter.Level = reader.ReadByte(); //level c

			//начальная позиция при создании персонажа
			CharacterHolder.LoadCharacterBodyCoord(newCharacter, newCharacter.CharRace, newCharacter.CharGender); //дополнительно прочитать body, x, y, z из таблицы charactermodel

			var x = LocalCommons.Utilities.Helpers.ConvertX(BitConverter.GetBytes(newCharacter.X));
			var y = LocalCommons.Utilities.Helpers.ConvertY(BitConverter.GetBytes(newCharacter.Y));
			var z = LocalCommons.Utilities.Helpers.ConvertZ(BitConverter.GetBytes(newCharacter.Z));
			newCharacter.Position = new Position(x, y, z); //сохраним позицию

			//reader.Offset += 6; //
			//short rotx = reader.ReadLEInt16();
			//short roty = reader.ReadLEInt16();
			//short rotz = reader.ReadLEInt16();
			//net.CurrentAccount.Character.Heading = new Direction(rotx, roty, rotz); //сохраним направление взгляда

			CharacterHolder.InsertOrUpdate(newCharacter,net); //записываем в базу character_records

			//выводим созданного чара
			var accountId = net.CurrentAccount.AccountId;
			//var charList = CharacterHolder.LoadCharacterData(accountId,net);
			var totalChars = net.CurrentAccount.Characters.Count();

			//Handle_UpdateCharacters(net, net.CurrentAccount.AccountId, totalChars);

			//net.SendAsync(new NP_SCCreateCharacterResponse_0x0033(net, totalChars - 1, 1));
			net.SendAsync(new NP_CharacterListPacket_0x0039(net, totalChars - 1, 1));
		}

		private static void OnPacketReceive_0x01_CSLeaveWorld_0x0001(ClientConnection net, PacketReader reader)
		{
			//клиентский пакет на выход из игры Recv: 0500 0001 0100 00
			//клиентский пакет на релогин       Recv: 0500 0001 0100 02

			CharacterHolder.InsertOrUpdate(net.CurrentAccount.Character,net); //записываем в базу character_records

			int reason = reader.ReadByte();
			switch (reason)
			{
				case 0:
					//quit from game

					net.SendAsync(new NP_SCLeaveWorldGrantedPacket_0x0003()); //quit
					break;
				case 1:
					//Recv: 05 00 00 01 01 00 01 смена персонажа когда находимся в игре
					net.SendAsync(new NP_SCReconnectAuthPacket_0x0001(net)); //reconnect does not always work
					break;
				case 2:
					//Recv: 05 00 00 01 01 00 00
					net.SendAsync(new NP_SCReconnectAuthPacket_0x0001(net)); //reconnect
					break;
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008A(ClientConnection net, PacketReader reader)
		{
			if (!enter1) //регулируем последовательность входа
			{
				//клиентский пакет  Recv: 130000053829157BA816DB909183220859E934EFF6
				net.SendAsyncHex(new NP_EnterGame_008A());//вход в игру1, пакет A>s 0x038
														  //net.SendAsyncHex(new NP_EnterGame_008A_2());//вход в игру1, пакет A>s 0x038
				enter1 = true;
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008B(ClientConnection net, PacketReader reader)
		{
			if (enter1) //регулируем последовательность входа
			{
				if (once2) //защитим от повтора посылки пакетов
				{
					//вход в игру2
					//13000005371947B88E92319E86B077729237FC244E
					net.SendAsyncHex(new NP_EnterGame_008B());//вход в игру2, пакет A>s 0x037
															  //net.SendAsyncHex(new NP_EnterGame_008B_2());//вход в игру2, пакет A>s 0x037
					enter2 = true;
					once2 = false;
				}
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008C(ClientConnection net, PacketReader reader)
		{
			if (enter2) //регулируем последовательность входа
			{
				if (once3)
				{
					//вход в игру3
					//13000005390AEDA4C3949E6A5B4AC06820F2BC202A
					//13000005370B469961E9F541A6AF4E8DB8BBB3EAFE
					net.SendAsyncHex(new NP_EnterGame_008C());//вход в игру3, пакет A>s 0x039
															  //net.SendAsyncHex(new NP_EnterGame_008C_2());//вход в игру3, пакет A>s 0x039
					enter3 = true;
					enter2 = false;
					once3 = false;
				}
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008D(ClientConnection net, PacketReader reader)
		{
			if (enter3)
			{
				if (once4)
				{
					net.SendAsyncHex(new NP_EnterGame_008D());//вход в игру4, пакет A>s 0x03F
															  //net.SendAsyncHex(new NP_EnterGame_008D_2());//вход в игру4, пакет A>s 0x03F
					enter4 = true;
					enter3 = false;
					once4 = false;
				}
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008E(ClientConnection net, PacketReader reader)
		{
			if (enter4)
			{
				if (once5)
				{
					net.SendAsyncHex(new NP_EnterGame_008E());//вход в игру5, пакет A>s 0x033
															  //net.SendAsyncHex(new NP_EnterGame_008E_2());//вход в игру5, пакет A>s 0x033
					once5 = false;
					enter5 = true;
					enter4 = false;
				}
			}
		}

		public static void OnPacketReceive_EnterWorld_0x008F(ClientConnection net, PacketReader reader)
		{
			if (enter5)
			{
				if (once6)
				{
					//net.SendAsyncHex(new NP_EnterGame_008F());//вход в игру6, пакет A>s 0x036
					once6 = false;
					enter6 = true;
					enter5 = false;
				}
			}
		}

		///<summary>
		///Verify user login permissions
		///</summary>
		///<param name="clientVersion"></param>
		///<param name="net"></param>
		///<param name="reader"></param>
		public static void OnPacketReceive_0x01_X2EnterWorld_0x0000(string clientVersion, ClientConnection net, PacketReader reader)
		{
			switch (clientVersion)
			{
				case "1":
					//               p_from   p_to     accId
					//2100 0001 0000 B9040000 BC040000 1AC70000 08C5B985FFFFFFFF0035CB020000000000
					var pFrom01 = reader.ReadLEInt32(); //p_from d
					var pTo01 = reader.ReadLEInt32(); //p_to d
					var accountId01 = reader.ReadLEUInt32(); //AccountId d
					var cookie01 = reader.ReadLEInt32(); //cookie d
					var zoneId01 = reader.ReadLEInt32(); //zoneId d
					var tb01 = reader.ReadByte(); //tb c
					var revision01 = reader.ReadLEInt64(); //revision Q, The resource version is the same as the brackets in the client header. (r.321543)
					var m_Authorized = ClientConnection.CurrentAccounts.FirstOrDefault(kv => kv.Value.Session == cookie01 && kv.Value.AccountId == accountId01).Value;
					if (m_Authorized == null)
					{
						net.Dispose();
						Log.Info("Account ID: {0} not logged in, can not continue", net);
					}
					else
					{
						//从客户列表读取登陆用户后写入当前SOCKET中
						net.CurrentAccount = m_Authorized;
						//todo 将当前客户
						m_Authorized.Connection = net;
						//反写当前客户到客户列表，用于后续的在线列表读取，消息群发等
						ClientConnection.CurrentAccounts[cookie01] = m_Authorized;

						//加载当前客户所有角色到内存中
						net.CurrentAccount.Characters = new List<Character>();
						CharacterHolder.LoadCharacterData(net); //считываем данные имеющихся персонажей на аккаунте

						foreach (var chr in net.CurrentAccount.Characters)
						{
							CharacterHolder.LoadEquipPacksData(chr, chr.Ability[0]); //дополнительно прочитать NewbieClothPackId, NewbieWeaponPackId из таблицы character_equip_packs
							CharacterHolder.LoadClothsData(chr, chr.NewbieClothPackId); //дополнительно прочитать Head,Chest,Legs,Gloves,Feet из таблицы equip_pack_cloths
							CharacterHolder.LoadWeaponsData(chr, chr.NewbieWeaponPackId); //дополнительно прочитать Weapon,WeaponExtra,WeaponRanged,Instrument из таблицы equip_pack_weapons
							CharacterHolder.LoadCharacterBodyCoord(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать body, x, y, z из таблицы charactermodel
							CharacterHolder.LoadZoneFaction(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать FactionId,StartingZoneId из таблицы characters

							net.CurrentAccount.Character = chr; //сохраним для дальнейшего использования

						}

						Log.Info("Account ID: {0} logged in, continue...", net);
						net.SendAsync(new NP_X2EnterWorldResponsePacket01_0x0000());
						//DD02 A>S
						net.SendAsync(new NP_ChangeState_0x0000(-1)); //начальный пакет NP_ChangeState с параметром 0
					}
					break;
				case "3":
					//v.3.0.3.0
					/*
                    [1]             A>s             0ms.            19:48:01 .455      25.07.18
                    -------------------------------------------------------------------------------
                     TType: ArcheageServer: GS1     Parse: 6           EnCode: off         
                    ------- 0  1  2  3  4  5  6  7 -  8  9  A  B  A  D  E  F    -------------------
                    000000 28 00 00 01 00 00 00 00 | 6D 05 00 00 6D 05 00 00     (.......m...m...
                    000010 1A C7 00 00 00 00 00 00 | 28 10 B4 7A FF FF FF FF     .З......(.ґzяяяя
                    000020 00 F3 0C 05 00 00 00 00 | 00 00                       .у........
                    -------------------------------------------------------------------------------
                    Archeage: "X2EnterWorld"                     size: 42     prot: 2  $002
                    Addr:  Size:    Type:         Description:     Value:
                    0000     2   word          psize             40         | $0028
                    0002     2   word          type              256        | $0100
                    0004     2   word          ID                0          | $0000
                    0006     2   word          type              0          | $0000
                    0008     4   integer       p_from            1389       | $0000056D
                    000C     4   integer       p_to              1389       | $0000056D
                    0010     8   int64         accountId         50970      | $0000C71A
                    0018     4   integer       cookie            2058620968 | $7AB41028
                    001C     4   integer       zoneId            -1         | $FFFFFFFF
                    0020     2   word          tb                62208      | $F300
                    0022     4   integer       revision          1292       | $0000050C
                    0026     4   integer       index             0          | $00000000

                    Recv: 2800 0001 0000 0000 6D050000 6D050000 1AC7000000000000 2810B47A FFFFFFFF 00F3 0C050000 00000000
                     */
					//type и ID нет в теле пакета (забрано ранее)
					//reader.Offset += 2; //Undefined Random Byte
					var type = reader.ReadLEInt16(); //type
					var pFrom = reader.ReadLEInt32(); //p_from
					var pTo = reader.ReadLEInt32(); //p_to
					var accountId = reader.ReadLEUInt32(); //Account Id
					reader.Offset += 4; //
					var cookie = reader.ReadLEInt32(); //cookie
					var zoneId = reader.ReadLEInt32(); //zoneId
					var tb = reader.ReadLEInt16(); //tb
					var revision = reader.ReadLEInt32(); //revision, The resource version is the same as the brackets in the client header. (r.321543)
					var index = reader.ReadLEInt32(); //index

					//пропускаем недо X2EnterWorld
					//if (type == 0)
					//{
					m_Authorized = ClientConnection.CurrentAccounts.FirstOrDefault(kv => kv.Value.Session == cookie && kv.Value.AccountId == accountId).Value;
					if (m_Authorized == null)
					{
						net.Dispose();
						Log.Info("Account ID: {0} not logged in, can not continue", net);
					}
					else
					{
						net.CurrentAccount = m_Authorized;
						//нулевой пакет DD05 S>A
						//0x01 0x0000_X2EnterWorldPacket
						//net.SendAsyncHex(new NP_X2EnterWorldResponsePacket());
						//CharacterList = CharacterHolder.LoadCharacterData(net); //считываем данные имеющихся персонажей на аккаунте
						Log.Info("Account ID: {0} logged in, continue...", net);
						net.SendAsync(new NP_X2EnterWorldResponsePacket_0x0000(clientVersion));
						//DD02 A>S
						net.SendAsync(new NP_ChangeState_0x0000(-1)); //начальный пакет NP_ChangeState с параметром 0
					}
					//}
					break;
				default:
					break;
			}
		}

		/*
                public static void OnPacketReceive_Client001F(ClientConnection net, PacketReader reader)
                {
                    //SC AiDebugPacket
                    net.SendAsyncHex(new NP_Hex("1C00DD01B8010500000001000000000000000000000073CF565300000000"));
                    //SC UnitVisualOptionsPacket
                    net.SendAsyncHex(new NP_Hex("4000DD01C001FF091A000B004A757374746F636865636B10006368617261637465725F6F7074696F6E1300675F686964655F7475746F7269616C20310D0A14000000"));
                    //SC UnitVisualOptionsPacket
                    net.SendAsyncHex(new NP_Hex("3B0EDD01C001FF091A000B004A757374746F636865636B0B006B65795F62696E64696E67130E7072696D6172790D0A202020206275696C74696E0D0A2020202020202020657363617065206F70656E5F636F6E6669670D0A20202020202020204354524C2D53484946542D3120676F646D6F64650D0A20202020202020204354524C2D53484946542D3220666C796D6F64650D0A2020202020202020746162206379636C655F686F7374696C655F666F72776172640D0A20202020202020204354524C2D746162206379636C655F667269656E646C795F666F72776172640D0A202020202020202053484946542D746162206379636C655F686F7374696C655F6261636B776172640D0A20202020202020204354524C2D53484946542D746162206379636C655F667269656E646C795F6261636B776172640D0A202020202020202071206D6F76656C6566740D0A20202020202020204354524C2D7120746F67676C655F73686F775F67756964655F646563616C0D0A202020202020202077206D6F7665666F72776172640D0A202020202020202065206D6F766572696768740D0A20202020202020204354524C2D6520746F67676C655F706F73740D0A20202020202020204354524C2D7220746F67676C655F726169645F6672616D650D0A202020202020202053484946542D7220746F67676C655F726169645F7465616D5F6D616E616765720D0A20202020202020204354524C2D53484946542D72207265706C795F6C6173745F776869737065720D0A2020202020202020414C542D53484946542D72207265706C795F6C6173745F7768697370657265640D0A202020202020202053484946542D7420746F67676C655F65787065646974696F6E5F6D616E6167656D656E740D0A20202020202020206920746F67676C655F6261670D0A20202020202020204354524C2D6920746F67676C655F676D5F636F6E736F6C650D0A20202020202020206F20746F67676C655F63726166745F626F6F6B0D0A20202020202020207020746F67676C655F636F6D6D6F6E5F6661726D5F696E666F0D0A2020202020202020656E746572206F70656E5F636861740D0A202020202020202061207475726E6C6566740D0A202020202020202073206D6F76656261636B0D0A202020202020202064207475726E72696768740D0A20202020202020206620646F5F696E746572616374696F6E5F310D0A20202020202020204354524C2D6620746F67676C655F666F7263655F61747461636B0D0A20202020202020206720646F5F696E746572616374696F6E5F320D0A20202020202020206820646F5F696E746572616374696F6E5F330D0A20202020202020206A20646F5F696E746572616374696F6E5F340D0A20202020202020206B20746F67676C655F7370656C6C626F6F6B0D0A20202020202020206C20746F67676C655F71756573740D0A20202020202020207A2061637469766174655F776561706F6E0D0A20202020202020207820646F776E0D0A20202020202020206320746F67676C655F6368617261637465720D0A20202020202020204354524C2D7620746F67676C655F6E616D657461670D0A202020202020202053484946542D7620746F67676C655F667269656E640D0A202020202020202053484946542D6220746F67676C655F636F6D6D65726369616C5F6D61696C0D0A20202020202020206E20746F67676C655F696E67616D6573686F700D0A20202020202020206D20746F67676C655F776F726C646D61700D0A202020202020202053484946542D6D20746F67676C655F63726166745F72657365617263680D0A20202020202020202E20746F67676C655F77616C6B0D0A20202020202020207370616365206A756D700D0A2020202020202020663120726F756E645F7461726765740D0A2020202020202020414C542D663520646F665F626F6B65685F636972636C650D0A2020202020202020414C542D663620646F665F626F6B65685F68657861676F6E0D0A2020202020202020414C542D663720646F665F626F6B65685F68656172740D0A2020202020202020414C542D663820646F665F626F6B65685F737461720D0A20202020202020206E756D6C6F636B206175746F72756E0D0A20202020202020206631322073637265656E73686F746D6F64650D0A20202020202020204354524C2D6631322073637265656E73686F7463616D6572610D0A2020202020202020686F6D652072696768745F63616D6572610D0A2020202020202020414C542D686F6D6520646F665F626F6B65685F6164645F73697A650D0A20202020202020204354524C2D686F6D6520646F665F6164645F646973740D0A202020202020202053484946542D757020616374696F6E5F6261725F706167655F707265760D0A2020202020202020706167657570206379636C655F63616D6572615F636F756E7465725F636C6F636B776973650D0A2020202020202020414C542D70616765757020646F665F626F6B65685F6164645F696E74656E736974790D0A20202020202020204354524C2D70616765757020646F665F6164645F72616E67650D0A2020202020202020656E64206261636B5F63616D6572610D0A2020202020202020414C542D656E6420646F665F626F6B65685F7375625F73697A650D0A20202020202020204354524C2D656E6420646F665F7375625F646973740D0A202020202020202053484946542D646F776E20616374696F6E5F6261725F706167655F6E6578740D0A202020202020202070616765646F776E206379636C655F63616D6572615F636C6F636B776973650D0A2020202020202020414C542D70616765646F776E20646F665F626F6B65685F7375625F696E74656E736974790D0A20202020202020204354524C2D70616765646F776E20646F665F7375625F72616E67650D0A2020202020202020696E736572742066726F6E745F63616D6572610D0A2020202020202020414C542D696E7365727420646F665F626F6B65685F746F67676C650D0A20202020202020204354524C2D696E7365727420646F665F746F67676C650D0A202020202020202064656C657465206C6566745F63616D6572610D0A20202020202020204354524C2D64656C65746520646F665F6175746F5F666F6375730D0A2020202020202020776865656C75702073637265656E73686F745F7A6F6F6D5F696E0D0A20202020202020204354524C2D776865656C7570206275696C6465725F7A6F6F6D5F696E0D0A202020202020202053484946542D776865656C7570206275696C6465725F726F746174655F6C6566745F6C617267650D0A2020202020202020414C542D776865656C7570206275696C6465725F726F746174655F6C6566745F736D616C6C0D0A2020202020202020776865656C646F776E2073637265656E73686F745F7A6F6F6D5F6F75740D0A20202020202020204354524C2D776865656C646F776E206275696C6465725F7A6F6F6D5F6F75740D0A202020202020202053484946542D776865656C646F776E206275696C6465725F726F746174655F72696768745F6C617267650D0A2020202020202020414C542D776865656C646F776E206275696C6465725F726F746174655F72696768745F736D616C6C0D0A20202020202020206D6F757365647820726F746174657961770D0A20202020202020206D6F757365647920726F7461746570697463680D0A20202020202020206D6F757365647A207A6F6F6D696E670D0A202020206275696C74696E5F6D756C74690D0A2020202020202020616374696F6E5F6261725F627574746F6E0D0A2020202020202020202020203120310D0A20202020202020202020202053484946542D312031330D0A2020202020202020202020203220320D0A20202020202020202020202053484946542D322031340D0A2020202020202020202020203320330D0A20202020202020202020202053484946542D332031350D0A2020202020202020202020203420340D0A20202020202020202020202053484946542D342031360D0A2020202020202020202020203520350D0A20202020202020202020202053484946542D352031370D0A2020202020202020202020203620360D0A20202020202020202020202053484946542D362031380D0A2020202020202020202020203720370D0A20202020202020202020202053484946542D372031390D0A2020202020202020202020203820380D0A20202020202020202020202053484946542D382032300D0A2020202020202020202020203920390D0A20202020202020202020202053484946542D392032310D0A202020202020202020202020302031300D0A20202020202020202020202053484946542D302032320D0A2020202020202020202020206D696E75732031310D0A20202020202020202020202053484946542D6D696E75732032330D0A202020202020202020202020657175616C732031320D0A20202020202020202020202053484946542D657175616C732032340D0A20202020202020206D6F64655F616374696F6E5F6261725F627574746F6E2028207220312C207420322C207920332C2075203420290D0A20202020202020207465616D5F746172676574202820663220312C20663320322C20663420332C206635203420290D0A20202020202020206F7665725F686561645F6D61726B6572202820663620312C20663720322C206638203320290D0A7365636F6E640D0A202020206275696C74696E0D0A20202020202020204354524C2D414C542D663120676F646D6F64650D0A2020202020202020414C542D53484946542D663120666C796D6F64650D0A20202020202020207570206D6F7665666F72776172640D0A20202020202020206C656674207475726E6C6566740D0A20202020202020207269676874207475726E72696768740D0A2020202020202020646F776E206D6F76656261636B0D0A20202020202020206D6F75736534206175746F72756E0D0A72656D6F7665640D0A140E0000"));
                    //SC SCRaceCongestionPacket
                    net.SendAsyncHex(new NP_Hex("0D00DD013A00000000000000000000"));

                    //SC CharacterListPacket
                    CharacterListPacket(_clientVersion, net);

                    //net.SendAsyncHex(new NP_Hex("8104DD0139000101FF091A000B004A757374746F636865636B010203C4010000CE010000B3000000650000000000000000000000000000000000000000005B5B00004618C1000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B00004718C1000000000000000100000001000000004600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00004818C1000000000000000100000001000000002300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D61700004918C1000000000000000100000001000000009100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B0000000000000000000000000000000000000000EF1700004A18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000003A1800004B18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007F4D0000D85D00000000000000000000000000001B020000000000000000000000000000070B0B00000000A8B7CF03000000006090A603EFFC104303BE1000000400000000000000000000000000803F0000803F0000000000000000000000000000803FCF0100000000803FA60000000000803F000000008FC2353F0000000000000000000000000000803FE37B8BFFAFECEFFFAFECEFFF000000FF00000000800000EF00EF00EE0017D40000000000001000000000000000063BB900D800EE00D400281BEBE100E700F037230000000000640000000000000064000000F0000000000000002BD50000006400000000F9000000E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000036007F422F530000000000000C302B5300000000000000000C302B530000000000000000B4412F5300000000C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001E00000000000000000000000000000000000000000000000000000000000000000000000000000000B33F2F5300000000"));
                }
        */
		public static void OnPacketReceive_0x01_CSRefreshInCharacterList_0x0020(ClientConnection net, PacketReader reader)
		{
			//SC ResultRestrictCheck
			net.SendAsync(new NP_SCResultRestrictCheck_0x01C3(net)); //net.SendAsyncHex(new NP_Hex("0D00DD01C301000000000000000000"));
		}

		public static void OnPacketReceive_0x01_CSRestrictCheck_0x0116(ClientConnection net, PacketReader reader)
		{
			//Recv: 0900 0001 1601 FF091A00 01
			var characterId = reader.ReadLEUInt32(); //Character Id
			var reason = reader.ReadByte();

			//SC ICSMenuList
			net.SendAsync(new NP_SCICSMenuList_0x01C4(net, characterId, reason)); //net.SendAsyncHex(new NP_Hex("0A00DD01C401FF091A000100"));
		}
		/// <summary>
		/// 选择使用角色
		/// </summary>
		/// <param name="net"></param>
		/// <param name="reader"></param>
		public static void OnPacketReceive_0x01_CSSelectCharacter_0x0024(ClientConnection net, PacketReader reader)
		{
			//- < packet id = "0x002401" name = "SelectCharacterPacket" >
			//0900 0001 2400 FF091A00 01
			var characterId = reader.ReadLEUInt32(); //Character Id
			var gm = reader.ReadByte();

			var character = new Character();
			net.CurrentAccount.Character = character;

			var accountId = net.CurrentAccount.AccountId;

			//CharacterList = CharacterHolder.LoadCharacterData(accountId,net);

			//считаем данные для всех созданых на аккаунте персонажей
			foreach (var chr in net.CurrentAccount.Characters)
			{
				CharacterHolder.LoadEquipPacksData(chr, chr.Ability[0]); //дополнительно прочитать NewbieClothPackId, NewbieWeaponPackId из таблицы character_equip_packs
				CharacterHolder.LoadClothsData(chr, chr.NewbieClothPackId); //дополнительно прочитать Head,Chest,Legs,Gloves,Feet из таблицы equip_pack_cloths
				CharacterHolder.LoadWeaponsData(chr, chr.NewbieWeaponPackId); //дополнительно прочитать Weapon,WeaponExtra,WeaponRanged,Instrument из таблицы equip_pack_weapons
				CharacterHolder.LoadCharacterBodyCoord(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать body, x, y, z из таблицы charactermodel
				CharacterHolder.LoadZoneFaction(chr, chr.CharRace, chr.CharGender); //дополнительно прочитать FactionId,StartingZoneId из таблицы characters

				if (chr.CharacterId == characterId)
				{
					net.CurrentAccount.Character = chr; //сохраним для дальнейшего использования
				}
			}

			net.CurrentAccount.Character.CharacterId = characterId; //запомним текущего персонажа, которым заходим в игру

			//SC CharacterStatePacket
			net.SendAsync(new NP_SCCharacterStatePacket_0x003B(net, characterId)); //net.SendAsyncHex(new NP_Hex("4205DD013B000000000010000E4FC3755AE17949B1F626620F354A9300000000FF091A000B004A757374746F636865636B010203C4010000CE010000B3000000650000000000000000000000000000000000000000005B5B00004618C1000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B00004718C1000000000000000100000001000000004600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00004818C1000000000000000100000001000000002300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D61700004918C1000000000000000100000001000000009100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B0000000000000000000000000000000000000000EF1700004A18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000003A1800004B18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007F4D0000D85D00000000000000000000000000001B020000000000000000000000000000070B0B00000000A8B7CF03000000006090A603EFFC104303BE1000000400000000000000000000000000803F0000803F0000000000000000000000000000803FCF0100000000803FA60000000000803F000000008FC2353F0000000000000000000000000000803FE37B8BFFAFECEFFFAFECEFFF000000FF00000000800000EF00EF00EE0017D40000000000001000000000000000063BB900D800EE00D400281BEBE100E700F037230000000000640000000000000064000000F0000000000000002BD50000006400000000F9000000E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000036007F422F530000000000000C302B5300000000000000000C302B530000000000000000B4412F5300000000C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001E00000000000000000000000000000000000000000000000000000000000000000000000000000000B33F2F53000000000000000000000000DBFB17C092070000000000000000000056010000460000000000000000000000000000000000000000000000000000000000000092070000000000000000000000000000000000000000000000000000323200C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C72C000022A21C530000000000"));

			//SC CharacterInvenInitPacket
			net.SendAsync(new NP_SCCharacterInvenInitPacket_0x0046(net)); //net.SendAsyncHex(new NP_Hex("0C00DD0146003200000032000000"));

			//инвентарь временно убрал
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("1F02DD014700020500CD0F00004C18C1000000000000010100000000000000000000000000000000000000000B00000000000000000000000000000000674900004D18C1000000000000010100000000000000000000000000000000000000000B00000000000000000000000000000000684900004E18C1000000000000010300000000000000000000000000000000000000000B00000000000000000000000000000000DA0F0000628354010000000000010300000000B8282F530000000000000000000000000B00000000000000000000000000000000561F000086A155010000000000000600000000F13C2F530000000000000000000000000B00000000000000000000000000000000481F000087A155010000000000000400000000F13C2F530000000000000000000000000B00000000000000000000000000000000530D0000F5A155010000000000000300000000F83C2F530000000000000000000000000B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("CF00DD0147000205050000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("7F00DD01470002030A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("CF00DD0147000305000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("CF00DD0147000305050000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//SC CharacterInvenContentsPacket
			net.SendAsyncHex(new NP_Hex("7F00DD01470003030A000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
			//инвентарь временно убрал

			//SC GamePointChangedPacket
			net.SendAsync(new NP_SCGamePointChangedPacket_0x0180(net)); //net.SendAsyncHex(new NP_Hex("2C00DD01800100000000100000000000000000000000000000000000000000000000000000000000000010000000"));

			//SC CharacterReturnDistrictsPacket
			net.SendAsync(new NP_SCCharacterReturnDistrictsPacket_0x0057(net)); //net.SendAsyncHex(new NP_Hex("7900DD015700020000006B6008002900D09ED0BAD180D0B5D181D182D0BDD0BED181D182D0B820D0A5D0BED183D0BFD184D0BED180D0B4D0B0B3000000C40F9B44BD650145F47DFC428B6C3940317508001000D0A5D0BED183D0BFD184D0BED180D0B4B30000002D73A54478DBE54479E9F54251A00B406B600800"));
		}
		/// <summary>
		/// 任务列表
		/// </summary>
		/// <param name="net"></param>
		/// <param name="reader"></param>
		public static void OnPacketReceive_0x01_CSSpawnCharacter_0x0025(ClientConnection net, PacketReader reader)
		{
			//пакеты квеста временно убрал
			//SCCSQuestAcceptConditionalPacket
			//发送任务列表
			net.SendAsyncHex(new NP_Hex("5700DD014201B6EA050100000000FB0000000303000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF0000000000000000000000000000000000000000000000000000000000000000"));
			net.SendAsyncHex(new NP_Hex("5700DD014201B6EA050100000000FC0000000300000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF0000000000000000000000000000000000000000000000000000000000000000"));
			net.SendAsyncHex(new NP_Hex("5700DD014201B6EA050100000000FD0000000200000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF0000000000000000000000000000000000000000000000000000000000000000"));
			//SCCSQuestAcceptConditionalPacket
			net.SendAsyncHex(new NP_Hex("5700DD014201F6EA050100000000E40900000300000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF0000000000000000000000000000000000000000000000000000000000000000"));
			//--- квест ---
			//SCUnitStatePacket
			net.SendAsync(new NP_SCUnitStatePacket_0x0064(net)); //net.SendAsyncHex(new NP_Hex("B504DD016400F527000B004A757374746F636865636B00FF091A0000000000000000000000F5F6790CD27499BC030000803F030B00000000000000000000005B5B00004618C1000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B00004718C1000000000000000100000001000000004600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00004818C1000000000000000100000001000000002300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D61700004918C1000000000000000100000001000000009100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B0000000000000000000000000000000000000000EF1700004A18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000003A1800004B18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007F4D0000D85D00000000000000000000000000001B02000000000000000000000000000003BE1000000400000000000000000000000000803F0000803F0000000000000000000000000000803FCF0100000000803FA60000000000803F000000008FC2353F0000000000000000000000000000803FE37B8BFFAFECEFFFAFECEFFF000000FF00000000800000EF00EF00EE0017D40000000000001000000000000000063BB900D800EE00D400281BEBE100E700F037230000000000640000000000000064000000F0000000000000002BD50000006400000000F9000000E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000090B0000078B40000FFFF00000002AB29000001002A000001000000000000D02100000000000065000000000000000000000000FF00000000FF00000000FF00000000FF00000000FF00000000FF920700000000000000FF00000000FF00000000FF01070000001E3C320028640101010000000001020000007709000000F5270000000000010100204E0000000000000000000000000000010000000000000000000000000101000000B119000000F527000000000001010000000000000000000000000000000000010000000000000000000000"));

			//SCCooldownsPacket
			net.SendAsync(new NP_SCCooldownsPacket_0x0045(net)); //net.SendAsyncHex(new NP_Hex("0C00DD0145000000000000000000"));

			//SC DetailedTimeOfDayPacket
			net.SendAsync(new NP_DetailedTimeOfDayPacket_0x00EA(net)); //net.SendAsyncHex(new NP_Hex("1400DD01EA004871B241D171DA3A000000000000C041"));


			//将自己的模型投放给所有用户
			foreach (KeyValuePair<int, Account> account in ClientConnection.CurrentAccounts)
			{
				//判断不能是自己的角色，防止重复
				if (account.Value.Connection != null && account.Value.AccountId != net.CurrentAccount.AccountId)
				{
					//给对方投放self Object
					account.Value.Connection.SendAsync(new NP_SCUnitStatePacket_0x0064(net));
					//同时拉取对方模型给自己
					net.SendAsync(new NP_SCUnitStatePacket_0x0064(account.Value.Connection));
				}

			}
		}

		public static void OnPacketReceive_0x01_CSNotifyInGame_0x0027(ClientConnection net, PacketReader reader)
		{
			//SCChatMessagePacket
			var msg = "Hi, people!"; //сообщений не видно =(
			var msg2 = "Welcome!";
			short chatId = -2; //системный?
			net.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, chatId, msg, msg2)); //net.SendAsyncHex(new NP_Hex("2D00DD01C600FEFF000000000000000000000000000000000000000000080057656C636F6D65210000000000000000"));

			//SCDeleteFriendPacket
			net.SendAsyncHex(new NP_Hex("0E00DD01C40006000000940000000000"));//势力 国家 联盟
			net.SendAsyncHex(new NP_Hex("0E00DD01C40001000500000000000000"));//场景
			net.SendAsyncHex(new NP_Hex("0E00DD01C40002000600000000000000"));//交易
			net.SendAsyncHex(new NP_Hex("0E00DD01C4000B000000940000000000"));
			net.SendAsyncHex(new NP_Hex("0E00DD01C40003000600940000000000"));//组队
			net.SendAsyncHex(new NP_Hex("0E00DD01C4000E000600940000000000"));//种族

			////          count 
			////AC04 DD04 0900  CD550D6C1445147EB3BBD7BB6A2977B66ADB54A412ADD1885ECF23B6785D824448087A6A41B170A570D6682D6A6E37B097A8AB69625169281222E16C0C3F12C45A5A49688126A5058998A825FED15CD03431268A54D34862F05CDF4C776FF77AD7DE79FC4E7666DEBC79F3BDF7BDF9D93C327D8E9B7B3307F432B7A15F793A22ED39CEEB0A50453877BD3148DF6BB41866772D23DD0E637062E890B2B252EAEA63D063EF0385DEED34A6D3F7145933CC3697F326347CD4AB1CAD948E8D4353135584ACA11F2BCD8D5C4741586D3FA48C5449C309D08537B3A98C1A8D16C3326F9F4325C6009C2EE5FC71A967814035BE26969066D333D5C6EB56711D171FE802458E27E4707EAE05FA4C9ED21B95CA2B1934355745980C7A5F4DE3D4D03975D05D4841581DEB514E7AA5501F3F8D1F26D13758D4EF78D954468D468B61A93C0FE6E1830F46940B1BE492B7D909A126EA451CBE8DB55CA3994CCE1BDE512C3FDAC13F1538119BF52F8BFAF59BA88FCCAA468B61BAE271BB055A76877716CA9F77F2B790D35A49ECE2A097D7104FAEE107DC15E16385B2AF936FF637084DB84BAA08EB6E884FA715345A0CABA64187053AE20D3716C9873BF89965BE5DA70FB2A8B386FEB2CD1E3373DDE40E6B37CACD9FF08B47E741E97842C2454618E97B1A74FC5CCF0E083BCD2BB3BA2A5C1090DB76B013A22C6351BF624F0DD9F655C45CA89B2440DB13CE75E3DDE18A02B9BF83FF3EE6B2D5290C3AEB731D84F3B7133B3C54BFF6C597E4101C116ED303A0DDB611A5F8AC34670049A8A260E60DA0B616A0E5CF1A3D6CDAD10A4BE9AAEC6BCAE77B05BADA90ECEAE1ECDDD095295D05D0D55BC9AE66D105D9D794AEA6827BED09802D254B594681D08E56C0176CAA5513E7BA2BEE451C539B14C67B387DF68E2437DBCD2599485B3D69DC8CE23F68637252FF279B89A124B129C37BDB7AF9DDBCBA04607E20319A227CEFAC1ADEE900605B06465145764D8D21EBA98E0AAAE86500AAD8A5F754EBA70DABE376B6E76ED5680D719CB6D766D35480BF005C516099C01CA3ED183BA9BEC15194F52F47EFB14B8C0815D66FB17590B1EC8F0238BF03D03400C2B5CEC6F61BBC988C0680DB05AC3CC35A00DBA9BF99B4C7F847E32A5C4B75692442639FF16005DC192484CAB886F55DC528E10B862D3005C03F398BE88855DD94C9416875E198AC2F8377A7310D362FFCA2AC55A42F06D90BC73D80F3A8BCA21FB7E9E301E04C97331F01E869C1B4D094103AA107950B02ECA5BFD490690C41D8BC068764FBCFD0122775645859BF50DAF21923458EE2FCAFC616A0CCBE4FEB59673607262A363D6B4E5E1689F3CFE82FA0FC74F479785417BD9C82F8300830D6805689C457FD8E2AD25A404CE2525451EF976A4E5EE3C49D07CE9566423C969AF8CA214A7CE105CB8EFBFE507EF44BA5A7AE71E23FD5D50F0918BCFE4DBAE3D35313EFBC071792AFF3A13A1F05F63DD9ABD87CD2401FEFF184446E818D29AF68C3EDDF854FB2E9F287E5C6FD15A01AD504AC97783F38E0C3D504F5D61B1984F98CDA9A7C10E3D43C0795F62A695B1FDB53AEFA6A505B759F9FB31C542B351F522009D438A4B63B05B5CE720240AABFB5BCBAB625E158505623E3D4327A75E1D216CED97EC666A136E9AB3B1704F88D3E85D6C7E73F
			////строка сжата официальным сервером
			////net.SendAsyncHex(new NP_Hex("AC04DD040900CD550D6C1445147EB3BBD7BB6A2977B66ADB54A412ADD1885ECF23B6785D824448087A6A41B170A570D6682D6A6E37B097A8AB69625169281222E16C0C3F12C45A5A49688126A5058998A825FED15CD03431268A54D34862F05CDF4C776FF77AD7DE79FC4E7666DEBC79F3BDF7BDF9D93C327D8E9B7B3307F432B7A15F793A22ED39CEEB0A50453877BD3148DF6BB41866772D23DD0E637062E890B2B252EAEA63D063EF0385DEED34A6D3F7145933CC3697F326347CD4AB1CAD948E8D4353135584ACA11F2BCD8D5C4741586D3FA48C5449C309D08537B3A98C1A8D16C3326F9F4325C6009C2EE5FC71A967814035BE26969066D333D5C6EB56711D171FE802458E27E4707EAE05FA4C9ED21B95CA2B1934355745980C7A5F4DE3D4D03975D05D4841581DEB514E7AA5501F3F8D1F26D13758D4EF78D954468D468B61A93C0FE6E1830F46940B1BE492B7D909A126EA451CBE8DB55CA3994CCE1BDE512C3FDAC13F1538119BF52F8BFAF59BA88FCCAA468B61BAE271BB055A76877716CA9F77F2B790D35A49ECE2A097D7104FAEE107DC15E16385B2AF936FF637084DB84BAA08EB6E884FA715345A0CABA64187053AE20D3716C9873BF89965BE5DA70FB2A8B386FEB2CD1E3373DDE40E6B37CACD9FF08B47E741E97842C2454618E97B1A74FC5CCF0E083BCD2BB3BA2A5C1090DB76B013A22C6351BF624F0DD9F655C45CA89B2440DB13CE75E3DDE18A02B9BF83FF3EE6B2D5290C3AEB731D84F3B7133B3C54BFF6C597E4101C116ED303A0DDB611A5F8AC34670049A8A260E60DA0B616A0E5CF1A3D6CDAD10A4BE9AAEC6BCAE77B05BADA90ECEAE1ECDDD095295D05D0D55BC9AE66D105D9D794AEA6827BED09802D254B594681D08E56C0176CAA5513E7BA2BEE451C539B14C67B387DF68E2437DBCD2599485B3D69DC8CE23F68637252FF279B89A124B129C37BDB7AF9DDBCBA04607E20319A227CEFAC1ADEE900605B06465145764D8D21EBA98E0AAAE86500AAD8A5F754EBA70DABE376B6E76ED5680D719CB6D766D35480BF005C516099C01CA3ED183BA9BEC15194F52F47EFB14B8C0815D66FB17590B1EC8F0238BF03D03400C2B5CEC6F61BBC988C0680DB05AC3CC35A00DBA9BF99B4C7F847E32A5C4B75692442639FF16005DC192484CAB886F55DC528E10B862D3005C03F398BE88855DD94C9416875E198AC2F8377A7310D362FFCA2AC55A42F06D90BC73D80F3A8BCA21FB7E9E301E04C97331F01E869C1B4D094103AA107950B02ECA5BFD490690C41D8BC068764FBCFD0122775645859BF50DAF21923458EE2FCAFC616A0CCBE4FEB59673607262A363D6B4E5E1689F3CFE82FA0FC74F479785417BD9C82F8300830D6805689C457FD8E2AD25A404CE2525451EF976A4E5EE3C49D07CE9566423C969AF8CA214A7CE105CB8EFBFE507EF44BA5A7AE71E23FD5D50F0918BCFE4DBAE3D35313EFBC071792AFF3A13A1F05F63DD9ABD87CD2401FEFF184446E818D29AF68C3EDDF854FB2E9F287E5C6FD15A01AD504AC97783F38E0C3D504F5D61B1984F98CDA9A7C10E3D43C0795F62A695B1FDB53AEFA6A505B759F9FB31C542B351F522009D438A4B63B05B5CE720240AABFB5BCBAB625E158505623E3D4327A75E1D216CED97EC666A136E9AB3B1704F88D3E85D6C7E73F"));
			////строка сжата нашим сервером
			//net.SendAsyncHex(new NP_Hex("1704DD040900E361E43733646A67638002EBB4039551734A961F65868934D833BCE366201AFC070118472B8C7113078C73FCE2AECA58CB928D7BC1467F9E0B367AA90099464F52674618CDB06A67E541CB92237B915D4DB6D181329C73B8E052F376553EB22AB98562B488389946F3ACE66860844B0908567E3B5AB2C38505C4B1CD051BDDC285C50C2098665FCE84D7E8DD7C9C4846DFE3A9DC79A744DD9205C9D5B88C5E1D928DDF68B678864D2270A9CF3B2A4F999614EF65E665BEC578A7096C748F2976A3B10114A32BB31810898F61C1A3CADF9DA552DD54497CBDD14CD9081F3399562D922CF55FCB1C1177FCAFF23FB0D18D62641A1D13C48E6474A961D56291D293EB9965196FFE97FA4B99D191218CC69C702943A3AA2322A5B6EB995B02D2587299C046970B916974EE610E24A3E79856654B94EE5ECBACA068BBE4E676CA8C3E3791FD2F2240720DABFE8B96B6AC63F67EEFC0200309902A09328DD68B63598C48D7495655C271A513178153486518D8E85A76ECC64C3C3F87115D0CC5687694749DAD5D65245C7A602DF3F5BF82ACF19594A5EB14866FAA8CEC0CCE8979F905A5C50C7B58949054CE7C5429F9A6C4EC1033C80E16E45C191DCDC0D0F13104EA6C4628660825DE15D800D61C1403B4AA13D32A371A581507B4AA0BD32A651A58850FD40733304C910A85388311EE8C26D24CD964A41F8CD7193380D26FD430AC994D9A35D38C0958F31E5807F562062A89BE410718D62802F36D1FEDADA9F36560708A43159340AB95980538A0B6C301308B8231BA1884366582D01B9910E20168EA5833E5FF83703113D3FF95ACACFF1B1818BE323008DE81381152CF7F06A754DBC3EF119620EA2C068C32061978E393C40902EE001B07D740450AD078A63E3D2079059831A1E1612808A153A1AA592FFD04D3CB6165D97F620970EA94B33162D048616484453188DE2809248025185C8081E10F9B07DC7DC85E4E61E81304F2192B141926F3C204739E57E655969C3E0C2EE1982CF006116D00D384358718901290821F03C38E0E489002C39401EE094E06168695A07AAF1849770AC3A4649092D94F193AE09EDA73ABB2C2BD64CA31B0A7180F02455EA532A082CD8968025BD00526A453E02962005380DC0161248F3B0093AA4721168FDF027AFC731A03BAC713DE8294F40933223C5E72A7B2C1A424E4D420F7B8C0967732C478FC2F768FC75E042971FF8D14E3B61F2AEF0794C85C1AE41E7F109F789105C1C7E9717EEC1E5FAF0B5272818FC18E0F2618BEB392D5B6E4D05E6663E3627B2617561AFB000B60DAB004582423F8372261F99785C10EE45E149F6D60E060589604E220C74F0A8313D86BC97C0CF670AF196FAF9C675532732FA468B21B08AF251804E0F29A2D03BAD798805E5B8AC56BEBD541A5AEDD55A45297D5B7EA6F4A69C39C012C7505E6DD6325A6D4B50626C5D7A08C819C1401"));

			////SCUnitMovementsPacket
			//net.SendAsyncHex(new NP_Hex("2700DD01660001005DD100019434E70F001BF07908517406D20336FBAF0575FE00000F007F00010005"));

			////SCUnitPointsPacket
			//net.SendAsyncHex(new NP_Hex("0F00DD01B200F5270090B0000078B40000"));

			////SCUnitMovementsPacket
			//net.SendAsyncHex(new NP_Hex("2700DD01660001005DD100010C35E70F00B6EF79815174BED10354FBAC054AFE00000F007F00010005"));
			//net.SendAsyncHex(new NP_Hex("2700DD01660001005DD100019735E70F005AEF79F0517479D1035EFBA1053FFE00000F007F00010005"));
			////net.SendAsyncHex(new NP_Hex("4202DD040700C5544D68134114FE6637F567210996B4560B121BD2A056D05AB5D6C06A6AB122158B287A5169B7F1E049D245D8430939140F0A422FA2018B78510BEAADE8C9E2212ADA8248932054517AA9C160894A355DDFAC8919D3045A28CDF2CDCCDB6FDECCBC6FDECC6888BF04C036A4316447EE9B8A1843CD7A2A2A0361556A65397A051BC91DAB6D970A0BBA8F01A35700D3248EF18E5C505B6043BC9AC810953C347C3F4B36DB718015447DBD68849AF4EEDB151435B173C2C363A7D838CA8A8A9716E5CBD228163823642A74D778D8A557DDA8A0A8EBA9DE115A9E42B35056D4B7D2A29E6EA761ECBD03B17A322C28BB0CF746FDE6881C0C0EAACAA0B0639FF6590ECB538D9798ACAF8893D2F2654908A02EC4D07A88D139B4E11685C1201EC66A9238B79FE83E2A79686096C406075EFC9338DE6468F57AE281CC6F98A2906F4F0755224EF48A7F647F384F551EDD47F216B59DC5AEC49545E3EAA2AEC49E2262A00B08F00B24F075C226705ABEEF0018C42FAC72312253F80FABBBAD09B80FF7F8DB6EE626157FD2AF9AAFC7CC3BE70256D9E6B59B470F9F32C3C05C76FAC7D4E7936D3F1B1BD66B7B3388265AE2F36BD76026DDE37EE2F1CE3A5C59534A279DB3DEC94CED8CE27D76F0E3A3B735D1374EB9069BE6331DD3CCE677F9CC54BBFD9D6FAB0B9EDFAF68BD25414C79338D64FFA57C729D0DBF16A6BCED34F7BCF458B8AAD7AA8C2FA3FD57C7AC9457E6513D1E08BAAC34507084B25755A6737C6FE1A33AF09C0631448447B5D369AC1AEE6F895550D4F0854C6431A292A544FD01"));
			//net.SendAsyncHex(new NP_Hex("8A00DD016600040027FD00010036E70F00A4A47AEA4D750E98037402F2023D000000F2007F000100053A5800010036E70F0088057A0EB97488C203A5FFDB02CDFF000003007F000100055DD100010036E70F0012EF7948527442D1035DFB9A053AFE00000F007F00010005F65E00010036E70F00366C7A542C754B9F0386036FFEDEFF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD016600040027FD00016E36E70F00C2A47A0D4E751498037102F1023E000000F2007F000100053A5800016E36E70F0084057A33B97483C20391FF7703C2FF000003007F000100055DD100016E36E70F00A4EE79CD5274F0D00364FB89053BFE00000FFE7F00010005F65E00016E36E70F006E6C7A3B2C75479F0385036FFEDEFF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD016600040027FD0001DA36E70F00F6A47A4D4E751E98037102F3023E000000F2007F000100053A580001DA36E70F0077057A9AB97475C2038AFFB103BEFF000003007F000100055DD10001DA36E70F0045EE793D5374A9D003E7FBBB0470FE000010FE7F00010005F65E0001DA36E70F00C76C7A132C75419F0387036DFEDEFF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD016600040027FD00013F37E70F0014A57A704E752498030000000000000000F20000000100053A5800013F37E70F006A057A05BA7466C20386FFC603BCFF000003007F000100055DD100013F37E70F00D0ED79BE537452D003CBFB070472FE000012EA7F00010005F65E00013F37E70F002D6D7AE62B75369F0383036FFECDFF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("0E00DD01FD00422D0004003D00000001"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A5800010439E70F0030057ACCBB7446C20382FFD403F0FF000003007F00010005D8CA00010439E70F0086827A4B3375EF9C0358FE63030600000009007F00010005F65E00010439E70F00CF6E7A2B2B75FE9E0382036DFEC3FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A5800017539E70F0022057A38BC7443C20382FFD303F0FF000003007F00010005D8CA00017539E70F0057827AAB3375F09C034EFE6C030500000009007F00010005F65E00017539E70F00326F7AFE2A75F19E037F036DFEC3FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD0166000400422D0001EA39E70F0033B7799E3A7499BD030000000000000000020000000100043A580001EA39E70F0013057AA7BC743FC20382FFD603F0FF000003007F00010005D8CA0001EA39E70F0025827A0F3475EF9C034DFE7203F0FF000009007F00010005F65E0001EA39E70F00986F7AD12A75E49E0380036CFEC3FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("2700DD0166000100F6250101230858000099E27919EC7436C203000000000000000031000000010004"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A580001633AE70F0005057A18BD743CC20381FFD803F0FF000003007F00010005D8CA0001633AE70F00FF817A5C3475E59C0350FE7403CFFF000009007F00010005F65E0001633AE70F00E66F7AAD2A75D99E0381036CFEC3FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A580001DD3AE70F00F6047A87BD7438C20382FFD703F0FF000003007F00010005D8CA0001DD3AE70F00CE817AC03475D99C0351FE7403C8FF000009007F00010005F65E0001DD3AE70F004B707A7F2A75BB9E0370036AFE73FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A580001543BE70F00E9047AF3BD7435C20382FFD703F0FF000003007F00010005D8CA0001543BE70F009F817A203575CD9C0351FE7203C7FF000009007F00010005F65E0001543BE70F00AB707A532A75999E0367036DFE64FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("6900DD01660003003A580001CC3BE70F00DA047A64BE7432C20382FFD303F0FF000003007F00010005D8CA0001CC3BE70F0062817A9F3575BD9C034FFE7603C7FF000009007E00010005F65E0001CC3BE70F000E717A252A75759E0365036EFE61FF0000D8007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD01660004003A580001463CE70F00CB047AD6BE742EC20382FFD403F0FF000003007F00010005D8CA0001463CE70F002F817A063675B09C034EFE7703C6FF000009007F00010005F65E0001463CE70F008D717AEB2975479E0368036FFE60FF0000D8007F000100057EC40001463CE70F00480F7A06A07434C80300FE8900B6FF00009B007F00010005"));
			//net.SendAsyncHex(new NP_Hex("8A00DD01660004003A580001C33CE70F00BC047A4CBF742AC20382FFD503F0FF000003007F00010005D8CA0001C33CE70F00FB807A713675A29C034EFE7503C7FF000009007F00010005F65E0001C33CE70F00F6717ABA2975229E0368036FFE5FFF0000D8007F000100057EC40001C33CE70F00EF0E7A1EA0741BC8039EFCE60083FF00001A007F00010005"));
			//net.SendAsyncHex(new NP_Hex("AB00DD01660005008E110101413DE70F006CE7796E7974CBC303DF01D7005E000000ED0066000100053A580001413DE70F00AE047ABCBF7427C20382FFD203F0FF000003007F00010005D8CA0001413DE70F00D5807ABE3675989C034EFE7403C6FF000009007F00010005F65E0001413DE70F0059727A8D2975FE9D036A036FFE5FFF0000D8007F000100057EC40001413DE70F00A30E7A33A07405C8036CFCF7007AFF00001A007F00010005"));
			////net.SendAsyncHex(new NP_Hex(""));

		}


		public static void OnPacketReceive_0x01_CSNotifyInGame_0x0028(ClientConnection net, PacketReader reader)
		{
			string welcome = "Welcome :" + net.CurrentAccount.Character.CharName + "!\nThis is a Private ArcheRage emulation server.\nHave fun.";
			net.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, -2, "system", welcome));
		}

		/// <summary>
		/// 1.1406 recv 16 00 00 01 61 00 00 00 00 00 00 00 00 00 00 00 01 00 31 09 00 00 00 00
		/// 3.0.3.0 send 2d00dd055ed5c000d2a2724212e3b3832963f4c6fd66340fdd30754516e2b6c7244395c697414010e0b09176c1f020
		/// 2d00dd05CFB4F10100000000000000007A4000026902000A0895000000040041736462010031000000001027000000
		/// </summary>
		/// <param name="net"></param>
		/// <param name="reader"></param>
		private static void OnPacketReceive_0x01_NP_CSChatPacket_0x0061(ClientConnection net, PacketReader reader)
		{
			//获取聊天类型ID
			short chatId = reader.ReadLEInt16();
			//未知
			short var1 = reader.ReadLEInt16();
			//未知
			reader.Offset += 6;

			//读取信息
			short msgLen = reader.ReadInt16();
			string msg = reader.ReadUTF8StringSafe(msgLen);

			//私聊
			//if (chatId == -3)
			//{
			//	net.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, -2,"System", "No support for whispers."));
			//	return;
			//}

			//debug
			if (chatId == 6)
			{
				string msg2 = "The information you sent is not recognized.\n你发送的信息不能被识别";
				switch (msg)
				{
					case "/dev"://开发命令
						msg2 = "Online Number  /on \n" +
								"Development Command /dev \n" +
								"Online User List /oul\n" +
								"Online Character /ocl\n";
						break;
					case "/on"://在线人数
						msg2 = ClientConnection.CurrentAccounts.Count.ToString();
						break;
					case "/oul":
						msg2 = "Online User List :\n";
						foreach(var account in  ClientConnection.CurrentAccounts)
						{
							msg2 += account.Value.Name+"\n";
						}

						break;
					case "/ocl":
						msg2 = "Online Character List :\n";
						foreach (KeyValuePair<int, Account> account in ClientConnection.CurrentAccounts)
						{
							if (account.Value.Connection != null)
							{
								msg2 += account.Value.Character.CharName+"\n";
							}

						}
						break;
					case "/re"://重新拉去所有用户模型

						//将自己的模型投放给所有用户
						foreach (KeyValuePair<int, Account> account in ClientConnection.CurrentAccounts)
						{
							//判断不能是自己的角色，防止重复
							if (account.Value.Connection != null && account.Value.AccountId != net.CurrentAccount.AccountId)
							{
								//给对方投放self Object
								account.Value.Connection.SendAsync(new NP_SCUnitStatePacket_0x0064(net));
								//同时拉取对方模型给自己
								net.SendAsync(new NP_SCUnitStatePacket_0x0064(account.Value.Connection));
							}

						}
						msg2 = "Refresh the success";
						break;
					case "/hp":
						net.SendAsync(new NP_SCUnitStatePacket_0x0064_debug(NPCs.RangeNPCs(net.CurrentAccount.Character.Position.X,net.CurrentAccount.Character.Position.Y)));
						break;
					case "npc":
						net.SendAsyncHex(new NP_Hex("DD00dd0164000d0e000000013ED5000d0e0000000000000000E69479A4F477267A033333733F02440500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002B0A473020200000000000000000000D8590000B8880000FFFF04003E0000000100010200000001000000000000B0000800A66201000000650000000000000000000000"));
						return;
						//break;
					case "hex":
						string text = File.ReadAllText(@"testhex.txt");
						net.SendAsyncHex(new NP_Hex(text.Trim()));
						break;
					default:

						break;
				}
				net.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, -1, "system", msg2));


				return;
				//务必将超长的dd01 转换成 DD04 ，否则客户端将丢失部分数据。
				//net.SendAsyncHex(new NP_Hex("1704DD040900E361E43733646A67638002EBB4039551734A961F65868934D833BCE366201AFC070118472B8C7113078C73FCE2AECA58CB928D7BC1467F9E0B367AA90099464F52674618CDB06A67E541CB92237B915D4DB6D181329C73B8E052F376553EB22AB98562B488389946F3ACE66860844B0908567E3B5AB2C38505C4B1CD051BDDC285C50C2098665FCE84D7E8DD7C9C4846DFE3A9DC79A744DD9205C9D5B88C5E1D928DDF68B678864D2270A9CF3B2A4F999614EF65E665BEC578A7096C748F2976A3B10114A32BB31810898F61C1A3CADF9DA552DD54497CBDD14CD9081F3399562D922CF55FCB1C1177FCAFF23FB0D18D62641A1D13C48E6474A961D56291D293EB9965196FFE97FA4B99D191218CC69C702943A3AA2322A5B6EB995B02D2587299C046970B916974EE610E24A3E79856654B94EE5ECBACA068BBE4E676CA8C3E3791FD2F2240720DABFE8B96B6AC63F67EEFC0200309902A09328DD68B63598C48D7495655C271A513178153486518D8E85A76ECC64C3C3F87115D0CC5687694749DAD5D65245C7A602DF3F5BF82ACF19594A5EB14866FAA8CEC0CCE8979F905A5C50C7B58949054961DAE9C995451D3CA0CB28305395746473330747C0C813A9B118A194289770536803507C500ADEAC4B4CA8D0656C501ADEAC2B44A990656E103F5C10C0C53A44221CE60843BA38934533619E907E375C60CA0F41B350C6B669366CD346302D6BC07D641BD98814AA26FD00186358AC07CDB477B6BEA7C19189CE250C524D06A2566010EA8ED7000CCA2608C2E06A14D9920F446268478009A3AD64CF9FF205CCCC4F47F252BEBFF060686AF0C0C8277204E84D4F39FC129D5F6F07B8425883A8B01A38C4106DEF8247182803BC0C6C135509102349EA94F0F485E01664C6878180A42E854A86AD64B3FC1F4725859F69F58029C3AE56C8C183452181961510CA2374A0209600906176060F8C3E601771FB2975318FA04817CC60A4586C9BC30C19CE795799525A70F834B38260BBC41441BC03461CD2106A404A4E0C7C0B0A30312A4C03065807B829381856125A8DE2B46D29DC2302919A464F653860EB8A7F6DCAAAC702F99720CEC29C683409157A90CA86073229AC016748109E914788A18C01420774018C9E30EC0A4EA5188C5E3B7801EFF9CC680EEF184B720257DC28C088F97DCA96C3029093935C83D2EB0E59D0C311EFF8BDDE3B117414ADC7F23C5B8ED87CAFB0125329706B9C71FC4275E6441F0717A9C1FBBC7D7EB82945CE063B0E3830986EFAC64B52D39B497D9D8B8D89EC98595C63EC00298362C0116C908FE8D4858FE6561B003B917C5671B18381896258138C8F193C2E004F65A321F833DDC6BC6DB2BE75995CCDC0B299AEC06C26B090601B8BC66CB80EE3526A0D79662F1DA7A7550A96B7715A9D465F5ADFA9B52DA3067004B5D8179F758892975AD8149F135286320274500"));
				//net.SendAsyncHex(new NP_Hex("2B04DD040900E361E43733646A67638002EBB4039551734A961F65868934D833BCE366201AFC070118472B8C7113078C73FCE2AECA58CB928D7BC1467F9E0B367AA90099464F52674618CDB06A67E541CB92237B915D4DB6D181329C73B8E052F376553EB22AB98562B488389946F3ACE66860844B0908567E3B5AB2C38505C4B1CD051BDDC285C50C2098665FCE84D7E8DD7C9C4846DFE3A9DC79A744DD9205C9D5B88C5E1D928DDF68B678864D2270A9CF3B2A4F999614EF65E665BEC578A7096C748F2976A3B10114A32BB31810898F61C1A3CADF9DA552DD54497CBDD14CD9081F3399562D922CF55FCB1C1177FCAFF23FB0D18D62641A1D13C48E6474A961D56291D293EB9965196FFE97FA4B99D191218CC69C702943A3AA2322A5B6EB995B02D2587299C046970B916974EE610E24A3E79856654B94EE5ECBACA068BBE4E676CA8C3E3791FD2F2240720DABFE8B96B6AC63F67EEFC0200309902A09328DD68B63598C48D7495655C271A513178153486518D8E85A76ECC64C3C3F87115D0CC5687694749DAD5D65245C7A602DF3F5BF82ACF19594A5EB14866FAA8CD20CE1A939C9F9B9A931211999C50A014599658925A90AC1A94565A9450C7B58949074971DAE9C995451D3CA0CB2970539A746473330747C0C817A85118A194289771936803557C500ADEAC4B4CA8D0656C501ADEAC2B44A990656E103F5C10C0C53A44221CE60843BA38934533619E907E375C60CA0F41B350C6B669366CD346302D6BC07D64BBD98814AA26FD00186358AC0BCDC477B6BEA7C19189CE250C524D06A2A66010EA8ED7000CCB6608C2E06A14D9920F446268478009A3AD64CF9FF205CCCC4F47F252BEBFF060686AF0C0C8277204E84D4FD9FC129D5F6F07B8425887A8C01A3DC4106DEF8247182803BC006C335503103349EA94F0F485E01664C6878180A42E854A86AD64B3FC1F47258F9F69F58029C3AE56C8C183452181961510CA2374A020960A906176060F8C3E601771FB2975318FA04817CC60A4586C9BC30C19CE795799525A70F834B38260BBC41441BC03461CD2106A404A4E0C7C0B0A30312A4C03065807B829381856125A82E2C46D29DC2302919A464F653860EB8A7F6DCAAAC702F99720CEC29C683409157A90CA86073229AC016748109E914788A18C01420774018C9E30EC0A4EA5188C5E3B7801EFF9CC680EEF184B720257DC28C088F97DCA96C3029093935C83D2EB0E59D0C311EFF8BDDE3B117414ADC7F23C5B8ED87CAFB0125329706B9C71FC4275E6441F0717A9C1FBBC7D7EB82945CE063B0E3830986EFAC64B52D39B497D9D8B8D89EC98595C63EC00298362C0116C908FE8D4858FE6561B003B917C5671B18381896258138C8F193C2E004F65A321F833DDC6BC6DB2BE75995CCDC0B299AEC06C26B090601B8BC66CB80EE3526A0D79662F1DA7A7550A96B7715A9D465F5ADFA9B52DA3067004B5D8179F758892975AD8149F135286320274500"));
				//net.SendAsyncHex(new NP_Hex("EC04DD016400F62501070043616E6F70757300BC0422000000000000000000000076C3799962787C85030000803F040A00000000000000000000005B5B000088F154010000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B000089F154010000000000000100000001000000004600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00008AF154010000000000000100000001000000002300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007F530000941A55010000000000010100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B2322F530000000000000000000000000B0000000000000000000000000000000098530000EC2655010000000000010100000001000000009B0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000096332F530000000000000000000000000B00000000000000000000000000000000EF1700008DF154010000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000211800008EF154010000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007E4D0000425E00000000000000000000000000001802000000000000000000000000000003100800000100000000000000000000000000803F0000803F0000000000000000000000000000803F000000000000803F350200000000803FB10200000000803F0000000050000000000000000000803F0000000005691FFF05691FFF730202FFA90505FF800000F5000011DC000B00000000170000000000F323000000003DC3EF00000000000000000000060000000000000000000001000000000000000000000000000000000000000000000000000000004B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000050DC000010D60000FFFF000001028E2E000001D4460000020000000000003111000000000000650000000000000005D2F90000000000A71400000000000000FF00000000FF00000000FF00000000FF00000000FF00000000FF00000000FF00000000FF00000000FF01010000001E3C320028640101010000000000000101000000B119000000F625010000000001010000000000FC0648000000000000000000010000000000000000000000"));

			}


			//SCChatMessagePacket
			string name = net.CurrentAccount.Character.CharName; //角色名称
			//net.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, chatId, msg1, msg2));

			//ClientConnection.CurrentAccounts
			//群发消息
			foreach(KeyValuePair<int, Account> account in ClientConnection.CurrentAccounts)
			{
				if (account.Value.Connection != null)
				{
					account.Value.Connection.SendAsync(new NP_SCChatMessagePacket_0x00C6(net, chatId, name, msg));
				}
				
			}
		}

		public static void OnPacketReceive_0x01_CSListCharacter_0x001F(ClientConnection net, PacketReader reader)
		{
			//SC AiDebugPacket
			//            net.SendAsync(new NP_SCAiDebugPacket_0x01B8(net)); //net.SendAsyncHex(new NP_Hex("1C00DD01B8010500000001000000000000000000000073CF565300000000"));

			//SCUnitVisualOptionsPacket
			//NP_SCUnitVisualOptionsPacket_0x01C0.SCUnitVisualOptionsPacket(net); //net.SendAsyncHex(new NP_Hex("4000DD01C001FF091A000B004A757374746F636865636B10006368617261637465725F6F7074696F6E1300675F686964655F7475746F7269616C20310D0A14000000"));

			//SC UnitVisualOptionsPacket
			//NP_SCUnitVisualOptionsPacket_0x01C0.SCUnitVisualOptionsPacket(net); //net.SendAsyncHex(new NP_Hex("3B0EDD01C001FF091A000B004A757374746F636865636B0B006B65795F62696E64696E67130E7072696D6172790D0A202020206275696C74696E0D0A2020202020202020657363617065206F70656E5F636F6E6669670D0A20202020202020204354524C2D53484946542D3120676F646D6F64650D0A20202020202020204354524C2D53484946542D3220666C796D6F64650D0A2020202020202020746162206379636C655F686F7374696C655F666F72776172640D0A20202020202020204354524C2D746162206379636C655F667269656E646C795F666F72776172640D0A202020202020202053484946542D746162206379636C655F686F7374696C655F6261636B776172640D0A20202020202020204354524C2D53484946542D746162206379636C655F667269656E646C795F6261636B776172640D0A202020202020202071206D6F76656C6566740D0A20202020202020204354524C2D7120746F67676C655F73686F775F67756964655F646563616C0D0A202020202020202077206D6F7665666F72776172640D0A202020202020202065206D6F766572696768740D0A20202020202020204354524C2D6520746F67676C655F706F73740D0A20202020202020204354524C2D7220746F67676C655F726169645F6672616D650D0A202020202020202053484946542D7220746F67676C655F726169645F7465616D5F6D616E616765720D0A20202020202020204354524C2D53484946542D72207265706C795F6C6173745F776869737065720D0A2020202020202020414C542D53484946542D72207265706C795F6C6173745F7768697370657265640D0A202020202020202053484946542D7420746F67676C655F65787065646974696F6E5F6D616E6167656D656E740D0A20202020202020206920746F67676C655F6261670D0A20202020202020204354524C2D6920746F67676C655F676D5F636F6E736F6C650D0A20202020202020206F20746F67676C655F63726166745F626F6F6B0D0A20202020202020207020746F67676C655F636F6D6D6F6E5F6661726D5F696E666F0D0A2020202020202020656E746572206F70656E5F636861740D0A202020202020202061207475726E6C6566740D0A202020202020202073206D6F76656261636B0D0A202020202020202064207475726E72696768740D0A20202020202020206620646F5F696E746572616374696F6E5F310D0A20202020202020204354524C2D6620746F67676C655F666F7263655F61747461636B0D0A20202020202020206720646F5F696E746572616374696F6E5F320D0A20202020202020206820646F5F696E746572616374696F6E5F330D0A20202020202020206A20646F5F696E746572616374696F6E5F340D0A20202020202020206B20746F67676C655F7370656C6C626F6F6B0D0A20202020202020206C20746F67676C655F71756573740D0A20202020202020207A2061637469766174655F776561706F6E0D0A20202020202020207820646F776E0D0A20202020202020206320746F67676C655F6368617261637465720D0A20202020202020204354524C2D7620746F67676C655F6E616D657461670D0A202020202020202053484946542D7620746F67676C655F667269656E640D0A202020202020202053484946542D6220746F67676C655F636F6D6D65726369616C5F6D61696C0D0A20202020202020206E20746F67676C655F696E67616D6573686F700D0A20202020202020206D20746F67676C655F776F726C646D61700D0A202020202020202053484946542D6D20746F67676C655F63726166745F72657365617263680D0A20202020202020202E20746F67676C655F77616C6B0D0A20202020202020207370616365206A756D700D0A2020202020202020663120726F756E645F7461726765740D0A2020202020202020414C542D663520646F665F626F6B65685F636972636C650D0A2020202020202020414C542D663620646F665F626F6B65685F68657861676F6E0D0A2020202020202020414C542D663720646F665F626F6B65685F68656172740D0A2020202020202020414C542D663820646F665F626F6B65685F737461720D0A20202020202020206E756D6C6F636B206175746F72756E0D0A20202020202020206631322073637265656E73686F746D6F64650D0A20202020202020204354524C2D6631322073637265656E73686F7463616D6572610D0A2020202020202020686F6D652072696768745F63616D6572610D0A2020202020202020414C542D686F6D6520646F665F626F6B65685F6164645F73697A650D0A20202020202020204354524C2D686F6D6520646F665F6164645F646973740D0A202020202020202053484946542D757020616374696F6E5F6261725F706167655F707265760D0A2020202020202020706167657570206379636C655F63616D6572615F636F756E7465725F636C6F636B776973650D0A2020202020202020414C542D70616765757020646F665F626F6B65685F6164645F696E74656E736974790D0A20202020202020204354524C2D70616765757020646F665F6164645F72616E67650D0A2020202020202020656E64206261636B5F63616D6572610D0A2020202020202020414C542D656E6420646F665F626F6B65685F7375625F73697A650D0A20202020202020204354524C2D656E6420646F665F7375625F646973740D0A202020202020202053484946542D646F776E20616374696F6E5F6261725F706167655F6E6578740D0A202020202020202070616765646F776E206379636C655F63616D6572615F636C6F636B776973650D0A2020202020202020414C542D70616765646F776E20646F665F626F6B65685F7375625F696E74656E736974790D0A20202020202020204354524C2D70616765646F776E20646F665F7375625F72616E67650D0A2020202020202020696E736572742066726F6E745F63616D6572610D0A2020202020202020414C542D696E7365727420646F665F626F6B65685F746F67676C650D0A20202020202020204354524C2D696E7365727420646F665F746F67676C650D0A202020202020202064656C657465206C6566745F63616D6572610D0A20202020202020204354524C2D64656C65746520646F665F6175746F5F666F6375730D0A2020202020202020776865656C75702073637265656E73686F745F7A6F6F6D5F696E0D0A20202020202020204354524C2D776865656C7570206275696C6465725F7A6F6F6D5F696E0D0A202020202020202053484946542D776865656C7570206275696C6465725F726F746174655F6C6566745F6C617267650D0A2020202020202020414C542D776865656C7570206275696C6465725F726F746174655F6C6566745F736D616C6C0D0A2020202020202020776865656C646F776E2073637265656E73686F745F7A6F6F6D5F6F75740D0A20202020202020204354524C2D776865656C646F776E206275696C6465725F7A6F6F6D5F6F75740D0A202020202020202053484946542D776865656C646F776E206275696C6465725F726F746174655F72696768745F6C617267650D0A2020202020202020414C542D776865656C646F776E206275696C6465725F726F746174655F72696768745F736D616C6C0D0A20202020202020206D6F757365647820726F746174657961770D0A20202020202020206D6F757365647920726F7461746570697463680D0A20202020202020206D6F757365647A207A6F6F6D696E670D0A202020206275696C74696E5F6D756C74690D0A2020202020202020616374696F6E5F6261725F627574746F6E0D0A2020202020202020202020203120310D0A20202020202020202020202053484946542D312031330D0A2020202020202020202020203220320D0A20202020202020202020202053484946542D322031340D0A2020202020202020202020203320330D0A20202020202020202020202053484946542D332031350D0A2020202020202020202020203420340D0A20202020202020202020202053484946542D342031360D0A2020202020202020202020203520350D0A20202020202020202020202053484946542D352031370D0A2020202020202020202020203620360D0A20202020202020202020202053484946542D362031380D0A2020202020202020202020203720370D0A20202020202020202020202053484946542D372031390D0A2020202020202020202020203820380D0A20202020202020202020202053484946542D382032300D0A2020202020202020202020203920390D0A20202020202020202020202053484946542D392032310D0A202020202020202020202020302031300D0A20202020202020202020202053484946542D302032320D0A2020202020202020202020206D696E75732031310D0A20202020202020202020202053484946542D6D696E75732032330D0A202020202020202020202020657175616C732031320D0A20202020202020202020202053484946542D657175616C732032340D0A20202020202020206D6F64655F616374696F6E5F6261725F627574746F6E2028207220312C207420322C207920332C2075203420290D0A20202020202020207465616D5F746172676574202820663220312C20663320322C20663420332C206635203420290D0A20202020202020206F7665725F686561645F6D61726B6572202820663620312C20663720322C206638203320290D0A7365636F6E640D0A202020206275696C74696E0D0A20202020202020204354524C2D414C542D663120676F646D6F64650D0A2020202020202020414C542D53484946542D663120666C796D6F64650D0A20202020202020207570206D6F7665666F72776172640D0A20202020202020206C656674207475726E6C6566740D0A20202020202020207269676874207475726E72696768740D0A2020202020202020646F776E206D6F76656261636B0D0A20202020202020206D6F75736534206175746F72756E0D0A72656D6F7665640D0A140E0000"));

			//SC SCRaceCongestionPacket
			//net.SendAsync(new NP_SCRaceCongestionPacket_0x003A(net)); //net.SendAsyncHex(new NP_Hex("0D00DD013A00000000000000000000"));

			//SC CharacterListPacket
			CharacterListPacket(_clientVersion, net); //net.SendAsyncHex(new NP_Hex("8104DD0139000101FF091A000B004A757374746F636865636B010203C4010000CE010000B3000000650000000000000000000000000000000000000000005B5B00004618C1000000000000000100000001000000005500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005C5B00004718C1000000000000000100000001000000004600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B00000000000000000000000000000000000000005E5B00004818C1000000000000000100000001000000002300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000D61700004918C1000000000000000100000001000000009100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B0000000000000000000000000000000000000000EF1700004A18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000003A1800004B18C1000000000000000100000001000000008200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000B000000000000000000000000000000007F4D0000D85D00000000000000000000000000001B020000000000000000000000000000070B0B00000000A8B7CF03000000006090A603EFFC104303BE1000000400000000000000000000000000803F0000803F0000000000000000000000000000803FCF0100000000803FA60000000000803F000000008FC2353F0000000000000000000000000000803FE37B8BFFAFECEFFFAFECEFFF000000FF00000000800000EF00EF00EE0017D40000000000001000000000000000063BB900D800EE00D400281BEBE100E700F037230000000000640000000000000064000000F0000000000000002BD50000006400000000F9000000E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000036007F422F530000000000000C302B5300000000000000000C302B530000000000000000B4412F5300000000C200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001E00000000000000000000000000000000000000000000000000000000000000000000000000000000B33F2F5300000000"));
		}

		public static void OnPacketReceive_0x02_FinishState_0x0001(string clientVersion, ClientConnection net, PacketReader reader)
		{
			var state = reader.ReadLEInt32(); //считываем state
											  //--------------------------------------------------------------------------
											  //NP_ChangeState
			net.SendAsync(new NP_ChangeState_0x0000(state));
			//--------------------------------------------------------------------------
			switch (clientVersion)
			{
				case "1":
					if (state == 0)
					{
						//--------------------------------------------------------------------------
						//SetGameType
						net.SendAsync(new NP_SetGameType_0x000F());
						//--------------------------------------------------------------------------
						//SC InitialConfigPacket
						net.SendAsync(new NP_SCInitialConfigPacket_0x0005(net)); //net.SendAsyncHex(new NP_Hex("2B00DD0105000A0061612E6D61696C2E727507003E320F0F79003300000000000A003200000000000101010101"));
																				 //SC AiDebugPacket
																				 //net.SendAsyncHex(new NP_Hex("1C00 DD01 B801 01000000010000000000000000000000 73CF5653 00000000"));
																				 //                             1C00 DD01 B801 01000000010000000000000000000000 0C225A53 00000000
																				 //SC ChatSpamDelayPacket
						net.SendAsync(new NP_SCChatSpamDelayPacket_0x00CB(net)); //net.SendAsyncHex(new NP_Hex("1400DD01CB0000000000000000000000000000000000"));
					}
					break;
				case "3":
					if (state == 0)
					{
						//выводим один раз
						//пакет №1 DD05 S>A
						net.SendAsync(new NP_Packet_0x0094()); //1400DD05C2E7E3865627F6CF97087265899FE9242175
															   //--------------------------------------------------------------------------
															   //SetGameType
						net.SendAsync(new NP_SetGameType_0x000F());
						//--------------------------------------------------------------------------
						//пакеты для входа в Лобби
						//пакет №2 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x0034()); //5000DD057F20F4C282625271B0CB11257381D3E43840DBA6F90B2C06A99043486EEFCD4B6745F31F35E70901D0441D85AB78EE825322F4C494643405D5A5754517E7B7875627F7C797704010E0B0115081B0
													 //пакет №3 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x02C3()); //A900DD0574936530FFE0A119356592C1B87D0D80A6E0105A6BBA8A10367483C1AB3C4882A3F1145673BEC8196E6492D9EE3F4690ACF7111C72A0CA052A138BC0F02457CEEABA044766BEC3172173C9D3F536418AFEC91E347486C3E0254B9DACBC16416ABCCD13257981C7AB25579CB3B905596BBBC2052472C8C0F5224398A0E2041E62A0C7162B66909CF3265197ACF5175128B6D710217F92C5AB314B98B0B911236489DFEF51E71747
													 //пакет №4 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x00EC()); //2A00DD05B9656B03D2A2724212E3B3835323F4C494643405B5F1754516E6B6865727F7C797704010E0B08151
													 //пакет №5 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x0281()); //7700DD05F997B53000EEA3724212E2B4845524F4C595643505D7A6764616E7B7875767BED0A0704011E1B1815122F2C292623303D3A3744414E4B4855525F5C596663606D6A7774717E7B0805020F0C191613101D2A2724212E3B3835323F4C49465340AC6A5754566A4B3865727F7C781348DDCAC8F8B99F2
													 //пакет №6 DD05 S>A
						net.SendAsync(new NP_Packet_0x00BA()); //0900DD05BFB67E50104170
															   //пакет №7 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x018A()); //1C00DD054863A207D5AF754516E6B9895827F7C897704010E0B0815EC4F4
													 //пакет №8 DD05 S>A
						net.SendAsync(new NP_Packet_0x01CC()); //0E00DD05842F7EC797704010E0B08151
															   //пакет №9 DD05 S>A
						net.SendAsync(new NP_Packet_0x0030()); //0900DD052CB90D53114270
															   //пакет №10 DD05 S>A
						net.SendAsync(new NP_Packet_0x01AF()); //0E00DD054E2DB8C597704010E0B08151
															   //пакет №11 DD05 S>A
						net.SendAsync(
							new NP_Packet_0x02CF()); //2300DD0500E82E825223F4C494643405D5A5754516E6B6865727F7C797704010E0B0815142
													 //пакет №12 DD05 S>A
						net.SendAsync(new NP_Packet_0x029C()); //0A00DD05817C5812E0B08151
					}
					break;
				default:
					break;
			}
		}

		public static void OnPacketReceive_ClientE4FB(ClientConnection net, PacketReader reader)
		{
			var number1 = reader.ReadLEInt32();
			//net.SendAsync(new NP_ChangeState(0));
		}

		public static void OnPacketReceive_Client0D7C(ClientConnection net, PacketReader reader)
		{
			var number1 = reader.ReadLEInt32();
			//var number2 = reader.ReadLEInt32();
			//var number3 = reader.ReadLEInt32();
			//var number4 = reader.ReadLEInt32();
			//var number5 = reader.ReadLEInt32();
			//net.SendAsync(new NP_ChangeState(0));
		}
		public static void OnPacketReceive_ClientE17B(ClientConnection net, PacketReader reader)
		{
			////пакет для входа в Лобби - продолжение
			//пакет №13 DD05 S>A
			net.SendAsync(new NP_Packet_0x0272());   //0700DD050CBD7B5010
													 //пакет №14 DD05 S>A
			net.SendAsync(new NP_Packet_0x00EC_2()); //2A00DD05EA6F6B03D3A2724213E3B3835323F4C4946434053B833B2816E6B6865727F7C797704010E0B08151
													 //пакет №15 DD05 S>A
			net.SendAsync(new NP_Packet_0x008C());   //FE00DD0595F92296663707D7A7775020F0C090613101D1A1724212E2B2835323F3C494643404D5A5754515E6B6865626F7C7976737FED0A0704011E1B1815122F2C292623303D3A3734414E4B4845525F5C596663606D6A7774717E7C0906030FED1A1714111E2B2825222F3C393633304D4A4744415E5B5855526F6C696663707D7A7774010E0B0815121F1C192623202D2A3734313E3B4845424F4C595653505D6A6764616E7B7875727FED0A0704011E1B1815122F2C292623303D3A3744414E4B4855525F5C596663606D6A7774717E7B0805020F0C191613101D2A2724212E3B3835323F4C494643405D5A5754516E6B6865727F7C797704010E0B08151
													 //пакет №16 DD05 S>A
			net.SendAsync(new NP_Packet_0x014D());   //0F00DD050637C9C697704010E0B0815186
													 //var ii = ArcheAgeGameController.AuthorizedAccounts.FirstOrDefault(n => n.Value.AccountId == net.CurrentAccount.AccountId);
													 //список чаров
			if (net.CurrentAccount.CharactersCount > 0)
			{
				//пакет №17 DD05 S>A
				//net.SendAsync(new NP_0x05_CharacterListPacket_0x0079(net)); //0209DD051E05ACB68556F261C495603654B3CB183376E4B591B032F
				CharacterListPacket(_clientVersion, net);
				//net.SendAsync(new NP_CharacterListPacket_0x0079()); //0209DD051E05ACB68556F261C495603654B3CB183376E4B591B032F
				//эти пакеты нужны когда есть чары в лобби
				//пакет №18 DD05 S>A
				net.SendAsync(new NP_Packet_0x014F()); //2400DD0564F11F825223F4C495643405D55A754516E634B7D47DF7C797704010E0B081514272
													   //пакет №19 DD05 S>A
				net.SendAsync(new NP_Packet_0x0145());   //1D00DD052777B6070231744517E6BD86214285B4FE1F2E30D1BD8B5DC4F423
														 //пакет №20 DD05 S>A
				net.SendAsync(new NP_Packet_0x0145_2()); //1D00DD051C70B6070231744514E6BD86214285B4FE1F2E30D2BD8B5DC4F423
														 //пакет №21 DD05 S>A
				net.SendAsync(new NP_Packet_0x0145_3()); //1D00DD050D71B6074342744517E6BD86214285B4FE1F2E30D1BD8B5DC4F423
														 //пакет №22 DD05 S>A
				net.SendAsync(new NP_Packet_0x0145_4()); //1D00DD05FA72B6074342744514E6BD86214285B4FE1F2E30D2BD8B5DC4F423
			}
			else
			{
				//не забыть установить кол-во чаров в ArcheAgeLoginServer :: ArcheAgePackets.cs :: AcWorldList_0X08
				//пакет №17 DD05 S>A
				//net.SendAsync(new NP_Packet_CharList_empty_0x0079()); //0800DD05FEA1C9531140
				CharacterListPacket(_clientVersion, net);
				//пакет №18 DD05 S>A
				net.SendAsync(new NP_Packet_0x014F()); //2400DD0564F11F825223F4C495643405D55A754516E634B7D47DF7C797704010E0B081514272
			}
			//идет клиентский пакет 13000005393DB7A29CAA4C2365F02DB94C5B18BB50
			//идет клиентский пакет 1300000539297EE205DC192D2A33B7071BC23B38BC
			//идет клиентский пакет 1300000539B1D74AE4C48857E02BAB7E33AF496A8C
			//идет клиентский пакет 1300000539211BA0D0AC0DE28974E1158F1BE5BB86

			//net.SendAsync(new NP_Packet_quit_0x00A5());
		}
		public static void OnPacketReceive_Client0438(ClientConnection net, PacketReader reader)
		{
			//клиентский пакет на вход в мир 13000005 3804 2E8CFF98F0282A5A79DE98E9BE80B6
			//зашифрован - не ловится
		}
		public static void OnPacketReceive_ReloginRequest_0x0088(ClientConnection net, PacketReader reader)
		{
			//клиентский пакет на релогин Recv: 13 00 00 05 34 0E 6F 39 8E 0A E3 5C E5 B9 85 25 D3 3E B3 8A 74
			net.SendAsync(new NP_Packet_quit_0x01F1()); //Good-Bye
			net.SendAsync(new NP_SCReconnectAuthPacket__0x01E5(net)); //
		}

		///<summary>
		///Получили клиентский пакет Ping, отвечаем серверным пакетом Pong
		///</summary>
		///<param name="net"></param>
		///<param name="reader"></param>
		public static void OnPacketReceive_0x02_Ping_0x0012(ClientConnection net, PacketReader reader)
		{
			//Ping
			var tm = reader.ReadLEInt64(); //tm
			var when = reader.ReadLEInt64(); //when
			var local = reader.ReadLEInt32(); //local
			net.SendAsync(new NP_Pong_0x0013(tm, when, local));
		}

		///<summary>
		///Authenticate user login permissions I do not know how to use, discarded
		///</summary>
		///<param name="net"></param>
		///<param name="reader"></param>
		public static void OnPacketReceive_ClientAuthorized(ClientConnection net, PacketReader reader)
		{
			//B3 04 00 00 B3 04 00 00 8C 28 22 00 E7 F0 0C C6 FF FF FF FF 00 
			reader.Offset += 2;
			var protocol = reader.ReadLEInt64(); //Protocols?

			long accountId = reader.ReadLEUInt32(); //Account Id
			reader.Offset += 4;
			var sessionId = reader.ReadLEInt32(); //User Session Id
			var m_Authorized = ClientConnection.CurrentAccounts.FirstOrDefault(kv => kv.Value.Session == sessionId && kv.Value.AccountId == accountId).Value;
			if (m_Authorized == null)
			{
				net.Dispose();
				Log.Info("Account ID: {0} is not logged in, unable to continue.", net);
			}
			else
			{
				net.CurrentAccount = m_Authorized;
				net.SendAsync(new NP_ClientConnected2());
				net.SendAsync(new NP_Client02());
				//net.SendAsync(new NP_ClientConnected());
			}
		}

		///<summary>
		///Connect game server first package
		///</summary>
		///<param name="net"></param>
		///<param name="reader"></param>
		public static void OnPacketReceive_Client01(ClientConnection net, PacketReader reader)
		{
			net.SendAsyncHex(new NP_Hex("0700dd05f2bdb150102a00dd056f6fcc01d3a2724213e3b3e05321512c00dd0205d012452606e6b6865727f7c797704010e0b081512c00dd021300157f26060000000060bee1d96c0100000000058ef05d96663707d219375020f0b62d01007dd3e50ffe00dd058ef95d96663707d7a7775020f0c090613101d1a1724212e2b2835323f3c494643404d5a5754515e6b6865626f7c7976737fed0a0704011e1b1815122f2c292623303d3a3734414e4b4845525f5c596663606d6a7774717e7c0906030fed1a1714111e2b2825222f3c393633304d4a4744415e5b5855526f6c696663707d7a7774010e0b0815121f1c192623202d2a3734313e3b4845424f4c595653505d6a6764616e7b7875727fed0a0704011e1b1815122f2c292623303d3a3744414e4b4855525f5c596663606d6a7774717e7b0805020f0c191613101d2a2724212e3b3835323f4c494643405d5a5754516e6b680b08151860800dd0520b181510f00dd0552379ac797704010e0b08151860800dd0520a188501140"));
		}
		public static void Onpacket0201(ClientConnection net, PacketReader reader)
		{
			var b3 = reader.ReadByte();
			if (b3 == 0x0)
			{
				net.SendAsync(new NP_Client0200());//Also returns an error
				net.SendAsyncHex(new NP_Hex("1400dd05fee767865627f6cf97087265899fe9242175"));
				net.SendAsyncHex(new NP_Hex("1e00dd020f000f00735f7069726174655f69736c616e640000000000000000014d00dd05e1606b03c3a31536778cd1e4324092a4fb031865b9ca6f4768d0bf8f29288d0aa62032df76266a421005dc04e238f2c494643405d5a5754516e6b7875626f6c797704010e0b0815152f322a900dd05e1936731ffe0a119356592c1b87d0d80a6e0105a6bba8a10367483c1ab3c4882a3f1145673bec8196e6492d9ee3f4690acf7111c72a0ca052a138bc0f02457ceeaba044766bec3172173c9d3f536418afec91e347486c3e0254b9dacbc16416abccd13257981c7ab25579cb3b905596bbbc2052472c8c0f5224398a0e2041e62a0c7162b66909cf3265197acf5175128b6d710217f92c5ab314b98b0b911236489dfef51e717472a00dd050e65cc01d2a2724212e3b3835323f4c4946434053561754516e6b6865727f7c797704010e0b081517700dd057997103300eea3724212e2b4845524f4c595643505d7a6764616e7b7875767bed0a0704011e1b1815122f2c292623303d3a3744414e4b4855525f5c596663606d6a7774717e7b0805020f0c191613101d2a2724212e3b3835323f4c49465340ac6a5754566a4b3865727f7c781348ddcac8f8b99f20900dd05a9b6e5511041701c00dd05d0635d04d5af754516e6b9895827f7c897704010e0b0815ec4f40e00dd057a2fb0c797704010e0b081510900dd059db9ac531142700e00dd05282df0c797704010e0b081512300dd0523e85c835223f4c494643405d5a5754516e6b6865727f7c797704010e0b08151420a00dd058b7cf511e0b08151"));
			}
			else if (b3 == 0x01)
			{
				net.SendAsync(new NP_Client02002());
			}
			//net.SendAsync(new NP_Clientdd05bae9());
		}

		public static void Onpacket0212(ClientConnection net, PacketReader reader)
		{
			//reader.Offset += 8; //00 00 00 00 00 00 00 00  Undefined Data
			var number1 = reader.ReadLEInt32();
			var number2 = reader.ReadLEInt32();
			var number3 = reader.ReadLEInt32();
			var number4 = reader.ReadLEInt32();
			var number5 = reader.ReadLEInt32();
			net.SendAsync(new NP_Client0212(number1, number2, number3, number4, number5));
		}
		#endregion

		#region LOGIN<->GAME server Callbacks Implementation

		///<summary>
		///Логин сервер передал Гейм серверу пакет с информацией об подключаемом аккаунте
		///</summary>
		///<param name="clientVersion"></param>
		///<param name="net"></param>
		///<param name="reader"></param>
		private static void Handle_AccountInfoReceived(string clientVersion, LoginConnection net, PacketReader reader)
		{
			switch (clientVersion)
			{
				case "1":
					//Set Account Info
					var account = new Account
					{
						AccountId = reader.ReadLEUInt32(),
						Name = reader.ReadDynamicString(),
						//Password = reader.ReadDynamicString(),
						Token = reader.ReadDynamicString(),
						AccessLevel = reader.ReadByte(),
						Membership = reader.ReadByte(),
						LastIp = reader.ReadDynamicString(),
						LastEnteredTime = reader.ReadLEInt64(),
						CharactersCount = reader.ReadByte(),
						Session = reader.ReadLEInt32()
					};
					Log.Info("Prepare login account ID: {0}, Session(cookie): {1}", account.AccountId, account.Session);
					//Check if the account is online and force it to disconnect online
					var m_Authorized = ClientConnection.CurrentAccounts.FirstOrDefault(kv =>
						kv.Value.Session == account.Session && kv.Value.AccountId == account.AccountId).Value;
					if (m_Authorized != null)
					{
						//Already
						var acc = ClientConnection.CurrentAccounts[m_Authorized.Session];
						if (acc.Connection != null)
						{
							acc.Connection.Dispose(); //Disconenct  
							Log.Info("Account Name: {0} log in twice, old connection is forcibly disconnected", acc.Name);
						}
						else
						{
							//Исправление входа второго пользователя, вторичный логин
							ClientConnection.CurrentAccounts.Remove(m_Authorized.Session);
							Log.Info("Account Name: {0} double connection is forcibly disconnected", acc.Name);
							ClientConnection.CurrentAccounts.Add(account.Session, account);
							Log.Info("Account Name: {0}, Session(cookie): {1} authorized", account.Name, account.Session);
						}
					}
					else
					{
						ClientConnection.CurrentAccounts.Add(account.Session, account);
						Log.Info("Account Name: {0}, Session(cookie): {1} authorized", account.Name, account.Session);
					}
					break;
				case "3":
					/*
                        5400 0100
                        1AC7000000000000 61617465737400 616174657374616100 333165333466326237326439336262323564356632376265386139346334373800 01 01 3132372E302E302E3100 4329871565010000 02 2810B47A
                    */
					//Set Account Info
					account = new Account
					{
						AccountId = reader.ReadLEUInt32(),
						Name = reader.ReadDynamicString(),
						//Password = reader.ReadDynamicString(),
						Token = reader.ReadDynamicString(),
						AccessLevel = reader.ReadByte(),
						Membership = reader.ReadByte(),
						LastIp = reader.ReadDynamicString(),
						LastEnteredTime = reader.ReadLEInt64(),
						CharactersCount = reader.ReadByte(),
						Session = reader.ReadLEInt32()
					};
					Log.Info("Prepare login account ID: {0}, Session(cookie): {1}", account.AccountId, account.Session);
					//Check if the account is online and force it to disconnect online
					m_Authorized = ClientConnection.CurrentAccounts.FirstOrDefault(kv =>
						kv.Value.Session == account.Session && kv.Value.AccountId == account.AccountId).Value;
					if (m_Authorized != null)
					{
						//Already
						var acc = ClientConnection.CurrentAccounts[m_Authorized.Session];
						if (acc.Connection != null)
						{
							acc.Connection.Dispose(); //Disconenct  
							Log.Info("Account Name: {0} log in twice, old connection is forcibly disconnected",
								acc.Name);
						}
						else
						{
							//Исправление входа второго пользователя, вторичный логин
							ClientConnection.CurrentAccounts.Remove(m_Authorized.Session);
							Log.Info("Account Name: {0} double connection is forcibly disconnected", acc.Name);
							ClientConnection.CurrentAccounts.Add(account.Session, account);
							Log.Info("Account Name: {0}, Session(cookie): {1} authorized", account.Name,
								account.Session);
						}
					}
					else
					{
						ClientConnection.CurrentAccounts.Add(account.Session, account);
						Log.Info("Account Name: {0}, Session(cookie): {1} authorized", account.Name,
							account.Session);
					}
					break;
				default:
					break;
			}
		}

		private static void Handle_GameRegisterResult(LoginConnection con, PacketReader reader)
		{
			var result = reader.ReadBoolean();
			if (result)
			{
				Log.Info("LoginServer successfully installed");
			}
			else
			{
				Log.Info("Some problems are appear while installing LoginServer");
			}

			if (result)
			{
				_mCurrentLoginServer = con;
			}
		}
		#endregion

		private static void Register(short opcode, OnPacketReceive<LoginConnection> e)
		{
			_mLHandlers[opcode] = new PacketHandler0<LoginConnection>(opcode, e);
			_mMaintained++;
		}

		private static void Register(byte level, ushort opcode, OnPacketReceive<ClientConnection> e)
		{
			if (!_levels.ContainsKey(level))
			{
				var handlers = new PacketHandler0<ClientConnection>[0xFFFF];
				handlers[opcode] = new PacketHandler0<ClientConnection>(opcode, e);
				_levels.Add(level, handlers);
			}
			else
			{
				_levels[level][opcode] = new PacketHandler0<ClientConnection>(opcode, e);
			}
		}
	}
}
