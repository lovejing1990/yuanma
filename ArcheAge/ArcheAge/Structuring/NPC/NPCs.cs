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
		/// </summary>
		public static List<NPC> OnlineNPCList = new List<NPC>();

		/// <summary>
		/// 通过 ID 获取NPC
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static NPC GetNPCByID(UInt32 ID)
		{
			//NPC NPC = new NPC();

			NPC NPC = LoadedNPCList.Find(npc => npc.ID == ID);

			//判断NPC是否已加载到内存中
			if (NPC != null)
			{
				return NPC;
			}
			else
			{
				using (MySqlConnection conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
				{
					try
					{
						conn.Open();
						MySqlCommand command = new MySqlCommand("SELECT *  FROM `npcs` WHERE `id`=@id", conn);
						command.Parameters.Add("@id", MySqlDbType.Int32).Value = ID;
						MySqlDataReader reader = command.ExecuteReader();
						while (reader.Read())
						{
							NPC = new NPC();
							NPC.ID = (Uint24)reader.GetUInt32("id");//ID
							NPC.Level = reader.GetByte("level");
							NPC.ModelID = reader.GetUInt32("npc_template_id");
							NPC.FactionId = reader.GetUInt32("faction_id");
							NPC.Scale = reader.GetUInt32("scale");
							//写入加载的NPC
							NPCs.LoadedNPCList.Add(NPC);

						}
						command.Dispose();
					}
					catch (Exception ex)
					{
						Log.Info("Error: Load NPC {0}", ex.Message);
					}
					finally
					{
						conn.Close();
					}
				}
			}


			return NPC;
		}
		/// <summary>
		/// 一定范围内的NPC
		/// </summary>
		/// <param name="X">X坐标</param>
		/// <param name="Y">Y坐标</param>
		/// <param name="RangeX">X半径范围</param>
		/// <param name="RangeY">Y半径范围</param>
		/// <param name="Limit">限制查询记录数目</param>
		public static List<NPC> RangeNPCs(float X, float Y, float RangeX = 100, float RangeY = 100, int Limit = 0)
		{
			List<NPC> NPCList = new List<NPC>();

			using (MySqlConnection conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
			{
				try
				{
					conn.Open();
					string limit = "";
					if (Limit > 0)
					{
						limit = " limit @limit";
					}
					// BUG 此处未考虑到同一NPC在多处分身。如 野兽 为多个不同的分布
					MySqlCommand command = new MySqlCommand("SELECT *  FROM `npc_map_data` WHERE `X`>=@Xmin and `X`<= @Xmax and `Y`>=@Ymin and `Y`<=@Ymax" + limit+" group by id", conn);
					command.Parameters.Add("@Xmin", MySqlDbType.Float).Value = X - RangeX / 2;
					command.Parameters.Add("@Xmax", MySqlDbType.Float).Value = X + RangeX / 2;
					command.Parameters.Add("@Ymin", MySqlDbType.Float).Value = Y - RangeX / 2;
					command.Parameters.Add("@Ymax", MySqlDbType.Float).Value = Y + RangeX / 2;

					if (Limit > 0)
					{
						command.Parameters.Add("@limit", MySqlDbType.Int32).Value = Limit; ;
					}


					MySqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						NPC NPC = NPCs.GetNPCByID(reader.GetUInt32("id"));
						if (NPC == null)
						{
							continue;
						}
						//初始化坐标
						Position postition = new Position(reader.GetFloat("X"), reader.GetFloat("Y"), reader.GetFloat("Z"));
						//写入NPC坐标
						NPC.Position = postition;
						NPCList.Add(NPC);
					}
					command.Dispose();
				}
				catch (Exception ex)
				{
					Log.Info("Error: RangeNPCs NPC NPCs {0}", ex.Message);
				}
				finally
				{
					conn.Close();
				}
			}
			return NPCList;
		}
	}
}
