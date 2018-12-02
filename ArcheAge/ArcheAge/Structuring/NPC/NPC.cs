using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalCommons.Utilities;
using LocalCommons.World;

namespace ArcheAgeGame.ArcheAge.Structuring.NPC
{
	public class NPC
	{
		/// <summary>
		/// Online Object ID
		/// </summary>
		public Uint24 LiveObjectID { get; set; }
		public int TargetObjectId { get; set; }

		/// <summary>
		/// NPC ID
		/// </summary>
		public uint ID { get; set; }
		public int TemplateId { get; set; } //в базе npcs: npc_template_id

		public string Name { get; set; } = ""; //в базе npcs: name
		public byte Race { get; set; } //в базе npcs: char_race_id
		public byte Gender { get; set; }
		public byte RaceGender { get { return (byte)((0x10 * this.Gender) + this.Race); } }

		/// <summary>
		/// Model ID
		/// </summary>
		public uint ModelId { get; set; }
		//public int ModelRef { get; set; } //в базе npcs: model_id

		/// <summary>
		/// Type Default 1
		/// </summary>
		public byte Type { get; set; } = 1;

		/// <summary>
		/// 坐标 X Y Z
		/// Monster's position.
		/// </summary>
		public Position Position { get; set; } = new Position(0, 0, 0);

		/// <summary>
		/// Monster's rotation.
		/// </summary>
		public Direction Direction { get; set; } = new Direction(0, 0, 0);
		/// <summary>
		/// Gets or set MP, clamped between 0 and MaxMp.
		/// </summary>
		public int Mp
		{
			get => _mp;
			set => _mp = Math2.Clamp(0, this.MaxMp, value);
		}

		private int _mp = 0x0ffffff; //TODO
		
		/// <summary>
		/// Maximum HP.
		/// </summary>
		public int MaxMp { get; set; }

		/// <summary>
		/// Health points.
		/// </summary>
		public int Hp
		{
			get { return this._hp; }
			private set { this._hp = Math2.Clamp(0, this.MaxHp, value); }
		}
		private int _hp = 0x0ffffff; //TODO

		/// <summary>
		/// Maximum health points.
		/// </summary>
		public int MaxHp { get; private set; }


		/// <summary>
		/// scale 中文不知道
		/// </summary>
		public float Scale { get; set; }

		/// <summary>
		/// Level
		/// </summary>
		public byte Level { get; set; }

		/// <summary>
		/// bc 未知
		/// </summary>
		public Uint24 BC { get; set; }

		public UInt32 FactionId { get; set; }

		/// <summary>
		/// Что одето
		/// </summary>
		public int EsHead { get; set; }
		public int EsNeck { get; set; }
		public int EsChest { get; set; }
		public int EsWaist { get; set; }
		public int EsLegs { get; set; }
		public int ES_HANDS { get; set; }
		public int EsFeet { get; set; }
		public int EsArms { get; set; }
		public int EsBack { get; set; }
		public int EsEar1 { get; set; }
		public int EsEar2 { get; set; }
		public int EsFinger1 { get; set; }
		public int EsFinger2 { get; set; }
		public int EsUndershirt { get; set; }
		public int EsUnderpants { get; set; }
		public int ES_MAINHAND { get; set; }
		public int ES_OFFHAND { get; set; }
		public int ES_RANGED { get; set; }
		public int ES_MUSICAL { get; set; }
		public int EsBackpack { get; set; }
		public int EsCosplay { get; set; }

		public int NewbieClothPackId { get; set; }
		public int NewbieWeaponPackId { get; set; }

		public int Lip { get; set; }
		public int LeftPupil { get; set; }
		public int RightPupil { get; set; }
		public int Eyebrow { get; set; }
		public int Decor { get; set; }
		public string Modifiers { get; set; }
		public int PreviewBodyPackId { get; set; }  //в базе characters: preview_body_pack_id
		public int HairColorId { get; set; }  //в базе equip_pack_body_parts: hair_color_id
		public int FaceId { get; set; }  //в базе equip_pack_body_parts: face_id
		public int HairId { get; set; }  //в базе equip_pack_body_parts: hair_id
		public int SkinColorId { get; set; }  //в базе equip_pack_body_parts: skin_color_id
		public int TotalCustomId { get; set; }  //в базе npcs: total_custom_id
		public int Body { get; set; }
		/// <summary>
		/// NPC动作集合
		/// </summary>
		public uint PostureSet { get; set; }

	}
}
