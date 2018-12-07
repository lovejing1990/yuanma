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
	/// <summary>
	/// NPC 动作集合Model
	/// </summary>
	class NPCPostureSets
	{
		/// <summary>
		/// ID
		/// </summary>
		public uint ID { get; set; }
		/// <summary>
		/// 名称 Name
		/// </summary>
		public string Name { set; get; }
		/// <summary>
		/// 动画id
		/// </summary>
		public uint QuestAnimActionID { set; get; }
		/// <summary>
		/// 注释说明
		/// </summary>
		public string Comment { set; get; }

		public List<NPCPosture> NPCPostures;


		/// <summary>
		/// 加载NPC姿势合集
		/// </summary>
		/// <returns></returns>
		public static NPCPostureSets loadPosturesSetByID(uint ID)
		{
			NPCPostureSets posturesSet = new NPCPostureSets();
			using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
			{
				try
				{
					conn.Open();
					//调整代码加载NPC所有信息
					var command = new MySqlCommand("SELECT *  FROM `npc_posture_sets` WHERE `id`=@aid", conn);
					command.Parameters.Add("@aid", MySqlDbType.Int32).Value = ID;
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						posturesSet.ID = reader.GetUInt32("id"); //ID
						posturesSet.Name = reader.GetString("name");
						posturesSet.QuestAnimActionID = reader.GetUInt32("quest_anim_action_id");
						posturesSet.Comment = reader.GetString("comment");
						posturesSet.NPCPostures = NPCPosture.loadByID(posturesSet.ID);
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
			return posturesSet;
		}
	}
}
