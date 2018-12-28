using System;
using System.Collections.Generic;
using ArcheAgeGame.Properties;
using LocalCommons.Logging;
using LocalCommons.Utilities;
using LocalCommons.World;
using MySql.Data.MySqlClient;

namespace ArcheAgeGame.ArcheAge.Structuring.NPC
{
	class NPCs
	{
		/// <summary>
		/// 已经加载到内存的NPC列表
		/// </summary>
		public static List<NPC> LoadedNPCList = new List<NPC>();

		/// <summary>
		/// 已在线的NPC列表
		/// notic
		///		加入之前必须写入LiveObjectID
		///		LiveObjectID must be written before joining.
		/// </summary>
		public static List<NPC> OnlineNPCList = new List<NPC>();

		//Для проверки поля на Null значения
		public static T CheckNull<T>(object obj)
		{
			return obj == DBNull.Value ? default(T) : (T)obj;
		}

		public static void LoadMonsterData0(NPC npc, uint id)
		{
			LoadMonsterData(npc, id); //считываем id, name, char_race_id, level, npc_template_id, model_id, faction_id, scale, equip_cloths_id, equip_weapons_id, total_custom_id
			//LoadMonsterData1(npc, id); //считываем X,Y,Z, rotZ

			var rnd = new Random(Environment.TickCount);
			var rotz = (sbyte)rnd.Next(0, 255);
			npc.Direction = new Direction(0, 0, rotz);

			LoadMonsterClothsData(npc, npc.NewbieClothPackId); //считываем что одето на герое/NPC
			if (npc.TotalCustomId != 0 && npc.ModelId < 21)
			{
				LoadMonsterCustomData2(npc, npc.ModelId); //считываем body, face, gender, race, hair_id, hair_color_id, scin_color_id, modifiers
				LoadMonsterCustomData(npc, npc.TotalCustomId); //считываем более правильные hair_id, hair_color_id, scin_color_id
			}
			else
			{
				LoadMonsterCustomData2(npc, npc.ModelId); //считываем body, face, gender, race, hair_id, hair_color_id, scin_color_id
				LoadMonsterData3(npc, npc.PreviewBodyPackId); //считываем hair_color_id, face_id, hair_id, skin_color_id
			}

			switch (npc.ModelId)
			{
				case 10:
				case 11:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
					break;
				default:
					//this.LoadMonsterData3(npc, npc.PreviewBodyPackId); //считываем данные
					npc.HairColorId = 0;
					npc.FaceId = 14799;
					npc.HairId = 0;
					npc.SkinColorId = 0;
					npc.Body = 14693;
					break;
					//this.LoadMonsterData_3(npc, npc.ModelRef); //считываем данные

			}
		}

			public static void LoadMonsterData(NPC npc, uint id)
		{
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `npcs` WHERE `id` = @aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = id;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						npc.ID = reader.GetUInt32("id");
						npc.Name = reader.GetString("name");
						npc.Race = (byte)reader.GetInt32("char_race_id");
						npc.Level = (byte)reader.GetInt32("level");
						npc.TemplateId = reader.GetInt32("npc_template_id");
						npc.ModelId = reader.GetUInt32("model_id");
						npc.FactionId = reader.GetUInt32("faction_id");
						npc.Scale = reader.GetFloat("scale");
						npc.NewbieClothPackId = CheckNull<int>(reader["equip_cloths_id"]);
						npc.NewbieWeaponPackId = CheckNull<int>(reader["equip_weapons_id"]);
						npc.TotalCustomId = CheckNull<int>(reader["total_custom_id"]);
						//npc.NewbieClothPackId = reader.GetInt32("equip_cloths_id");
						//npc.NewbieWeaponPackId = reader.GetInt32("equip_weapons_id");
						//npc.TotalCustomId = reader.GetInt32("total_custom_id");
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void LoadMonsterData1(NPC npc, uint id)
		{
			var rnd = new Random(Environment.TickCount);
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `npc_map_data` WHERE `id` = @aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = id;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						var x = reader.GetFloat("x");
						var y = reader.GetFloat("y");
						var z = reader.GetFloat("z");
						npc.Position = new Position(x, y, z);
						var rotz = (sbyte)rnd.Next(0, 255);
						npc.Direction = new Direction(0, 0, rotz);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void LoadMonsterClothsData(NPC npc, int newbieClothPackId)
		{
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `equip_pack_cloths` WHERE `id` = @aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = newbieClothPackId;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						npc.EsHead = reader.GetInt32("headgear_id");  //голова/головной убор
						npc.EsNeck = reader.GetInt32("necklace_id"); //шея/ожерелье
						npc.EsChest = reader.GetInt32("shirt_id");  //грудь/рубашка
						npc.EsWaist = reader.GetInt32("belt_id"); // пояс/ремень
						npc.EsLegs = reader.GetInt32("pants_id");   //ноги/штаны
						npc.ES_HANDS = reader.GetInt32("glove_id"); //кисти/перчатки
						npc.EsFeet = reader.GetInt32("shoes_id");   //ступни/обувь
						npc.EsArms = reader.GetInt32("bracelet_id"); // руки/браслет
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void LoadMonsterCustomData2(NPC npc, uint modelId)
		{
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `charactermodel` WHERE `model_id` = @amodel_id", conn);
					command.Parameters.Add("@amodel_id", MySqlDbType.Int32).Value = modelId;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						npc.FaceId = reader.GetInt32("face");
						npc.Body = reader.GetInt32("body");
						npc.Gender = (byte)reader.GetInt32("gender");
						npc.Race = (byte)reader.GetInt32("race");

						npc.HairColorId = reader.GetInt32("hair_color_id");
						npc.HairId = reader.GetInt32("hair_id");
						npc.SkinColorId = reader.GetInt32("skin_color_id");
						npc.Modifiers = reader.GetString("modifiers");
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void LoadMonsterCustomData(NPC npc, int totalCustomId)
		{
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `total_character_customs` WHERE `id` = @aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = totalCustomId;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						npc.HairColorId = reader.GetInt32("hair_color_id");
						npc.HairId = reader.GetInt32("hair_id");
						npc.SkinColorId = reader.GetInt32("skin_color_id");
						npc.Decor = reader.GetInt32("deco_color");
						npc.Eyebrow = reader.GetInt32("eyebrow_color");
						npc.LeftPupil = reader.GetInt32("left_pupil_color");
						npc.Lip = reader.GetInt32("lip_color");
						npc.RightPupil = reader.GetInt32("right_pupil_color");
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public static void LoadMonsterData3(NPC npc, int previewBodyPackId)
		{
			try
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					conn.Open();
					var command = new MySqlCommand("SELECT * FROM `equip_pack_body_parts` WHERE `id` = @aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = previewBodyPackId;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						if (previewBodyPackId > 364)
						{
							switch (npc.Gender)
							{
								case 1:
									npc.FaceId = 14799;
									npc.Body = 14693;
									break;
								case 2:
									npc.FaceId = 19839;
									npc.Body = 539;
									break;
							}
						}
						else
						{
							npc.HairColorId = reader.GetInt32("hair_color_id");
							npc.FaceId = reader.GetInt32("face_id");
							npc.HairId = reader.GetInt32("hair_id");
							npc.SkinColorId = reader.GetInt32("skin_color_id");
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		/// <summary>
		/// 通过 ID 获取NPC
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static NPC GetNpcbyId(uint id)
		{
			var npc = new NPC();

			npc = LoadedNPCList.Find(a => a.ID == id);

			//判断NPC是否已加载到内存中
			if (npc != null)
			{
				return npc;
			}
			else
			{
				using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					try
					{
						conn.Open();
						//调整代码加载NPC所有信息
						var command = new MySqlCommand("SELECT *  FROM `npcs` WHERE `id`=@aid", conn);
						command.Parameters.Add("@aid", MySqlDbType.Int32).Value = id;
						var reader = command.ExecuteReader();
						while (reader.Read())
						{
							npc = new NPC();
							npc.ID = reader.GetUInt32("id"); //ID
							npc.Level = (byte)reader.GetInt32("level");
							npc.ModelId = reader.GetUInt32("model_id");
							npc.FactionId = reader.GetUInt32("faction_id");
							npc.Scale = reader.GetFloat("scale");
							npc.PostureSet = reader.GetUInt32("npc_posture_set_id");//获取NPC动作集合
							//写入加载的NPC
							//NPCs.LoadedNPCList.Add(npc); //取消写入列表 在无法解决对象引用之前
						}
						command.Dispose();
					}
					catch (Exception ex)
					{
						Log.Exception(ex, "Error: Load NPC");
					}
					finally
					{
						conn.Close();
					}
				}
			}
			return npc;
		}

		/// <summary>
		/// 一定范围内的NPC
		/// </summary>
		/// <param name="x">X坐标</param>
		/// <param name="y">Y坐标</param>
		/// <param name="rangeX">X半径范围</param>
		/// <param name="rangeY">Y半径范围</param>
		/// <param name="limit">限制查询记录数目</param>
		public static List<NPC> RangeNPCs(float x, float y, float rangeX = 250, float rangeY = 250, int limit = 0)
		{
			var npcList = new List<NPC>();

			using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
			{
				try
				{
					conn.Open();
					var lim = "";
					if (limit > 0)
					{
						lim = " limit @limit";
					}
					// BUG 此处未考虑到同一NPC在多处分身。如 野兽 为多个不同的分布
					// BUG не считает здесь, что тот же NPC находится в нескольких местах. Такие, как звери для множества разных распределений
					var command = new MySqlCommand("SELECT *  FROM `npc_map_data` WHERE `X`>=@xmin and `x`<= @xmax and `y`>=@ymin and `y`<=@ymax" + lim, conn);
					command.Parameters.Add("@xmin", MySqlDbType.Float).Value = x - rangeX / 2;
					command.Parameters.Add("@xmax", MySqlDbType.Float).Value = x + rangeX / 2;
					command.Parameters.Add("@ymin", MySqlDbType.Float).Value = y - rangeY / 2;
					command.Parameters.Add("@ymax", MySqlDbType.Float).Value = y + rangeY / 2;
					if (limit > 0)
					{
						command.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
					}
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						//初始化坐标
						var postition = new Position(reader.GetFloat("X"), reader.GetFloat("Y"),
							reader.GetFloat("Z"));
						var npc = GetOnlineNpcbyIdAndPostition(reader.GetUInt32("id"), postition);
						if (npc == null)
						{
							continue;
						}
						//写入NPC坐标
						//NPC.Position = postition;
						npcList.Add(npc);
					}
					command.Dispose();
				}
				catch (Exception ex)
				{
					Log.Exception(ex, "Error: RangeNPCs NPC NPCs");
				}
				finally
				{
					conn.Close();
				}
			}

			return npcList;
		}

		/// <summary>
		/// 获取在线NPC 通过ID和Postition 坐标
		/// </summary>
		/// <param name="id"></param>
		/// <param name="position"></param>
		/// <returns></returns>
		public static NPC GetOnlineNpcbyIdAndPostition(Uint24 id, Position position)
		{
			var npc = OnlineNPCList.Find(n => n.ID == id && n.Position == position);

			//判断NPC是否已加载到内存中
			if (npc == null)
			{
				//如果不存在查询NPC模板
				npc = GetNpcbyId(id);
				if (npc != null)
				{
					npc.Position = position;
					npc.LiveObjectID = ArcheAgeGame.LiveObjectUid.Next();
					//将NPC写入在线列表
					OnlineNPCList.Add(npc);
				}
			}
			return npc;
		}

	}
}

