using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcheAgeGame.Properties;
using LocalCommons.Logging;
using MySql.Data.MySqlClient;

namespace ArcheAgeGame.ArcheAge.Database.Model
{
	class NPCPosture
	{
		//		id
		//npc_posture_set_id
		//anim_action_id
		//talk_anim
		//start_tod_time
		/// <summary>
		/// 姿势ID
		/// </summary>
		public uint ID { get; set; }
		/// <summary>
		/// NPC姿势集合ID
		/// </summary>
		public uint NPCPostureSetID { get; set; }
		/// <summary>
		/// 动画动作ID
		/// </summary>
		public uint AnimActionID { get; set; }
		/// <summary>
		/// 谈话动作
		/// </summary>
		public string TalkAnim { get; set; }
		/// <summary>
		/// 开始时间
		/// </summary>
		public uint StartTodTime { get; set; }

		/// <summary>
		/// 这是一个集合，姿势集合可能对应多个姿势并且每个姿势都有特定的时常
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public static List<NPCPosture> loadByID(uint ID)
		{
			//NPCPostures nPCPostures = new NPCPostures();
			List<NPCPosture> NPCPostures = new List<NPCPosture>();
			using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
			{
				try
				{
					conn.Open();
					//调整代码加载NPC所有信息
					var command = new MySqlCommand("SELECT *  FROM `npc_postures` WHERE `id`=@aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = ID;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						NPCPosture NPCPosture = new NPCPosture();
						NPCPosture.ID = reader.GetUInt32("id"); //ID
						NPCPosture.NPCPostureSetID = reader.GetUInt32("npc_posture_set_id");
						NPCPosture.AnimActionID = reader.GetUInt32("anim_action_id");
						NPCPosture.TalkAnim = reader.GetString("talk_anim");
						NPCPosture.StartTodTime = reader.GetUInt32("start_tod_time");
						NPCPostures.Add(NPCPosture);
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
			return NPCPostures; 
		}
	}
}
