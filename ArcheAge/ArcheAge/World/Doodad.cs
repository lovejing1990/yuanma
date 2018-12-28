// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using AAEmu.Commons.Const;
using AAEmu.Commons.Data.Database;
using AAEmu.Commons.Utils;
using AAEmu.Commons.World;
using AAEmu.Game.Core.Network.Game;
using System;
using AAEmu.Commons.Data;

namespace AAEmu.Game.Core.World
{
    public class Doodad  : IEntity
    {
        /// <summary>
        /// Index in world collection?
        /// </summary>
        public uint Handle { get; private set; }

	    /// <summary>
	    /// Creates new NPC.
	    /// </summary>
	    public Doodad(int id, NpcType type)
	    {
		    this.Handle = GameNetwork.Instance.World.CreateHandle();

		    this.Id = id;
		    this.NpcType = type;
		    this.Level = 1;
		    this.Sdr = 1;
		    this.Hp = this.MaxHp = 100;
		    this.DisappearTime = DateTime.MaxValue;

		    this.LoadData();
	    }

        private Map _map = Map.Limbo;
        /// <summary>
        /// The map the monster is currently on.
        /// </summary>
        public Map Map
        {
	        get => _map;
	        set => _map = value ?? Map.Limbo;
        }

	    /// <summary>
	    /// What kind of NPC the monster is.
	    /// </summary>
	    public NpcType NpcType { get; set; }

		public int Id { get; set; }  //в базе doodad_almighties: id
	    public int GrowthTime { get; set; }  //в базе doodad_almighties: growth_time
	    public int KindId { get; set; }  //в базе doodad_almighties: model_kind_id
	    
	    public int TemplateId { get; set; } //в базе npcs: npc_template_id
	    public string Name { get; set; } = ""; //в базе doodad_almighties: name
	    public string Model { get; set; } = ""; //в базе doodad_almighties: model
	    public byte Race { get; set; } //в базе npcs: char_race_id
	    public byte Gender { get; set; }
		public byte RaceGender { get { return (byte)((0x10 * this.Gender) + this.Race); } }

		public int FactionId { get; set; } //в базе npcs: faction_id
		public int StartingZoneId { get; set; }
	    public int ModelRef { get; set; } //в базе npcs: model_id
		public Uint24 LiveObjectId { get; set; }
	    public int TargetObjectId { get; set; }

	    public int[] Type { get; set; } = new int[18];
	    public float[] Weight { get; set; } = new float[18];
	    public float Scale { get; set; } //в базе npcs: scale
		public float Rotate { get; set; }
	    public float MoveX { get; set; }
	    public float MoveY { get; set; }
	    public int Lip { get; set; }
	    public int LeftPupil { get; set; }
	    public int RightPupil { get; set; }
	    public int Eyebrow { get; set; }
	    public int Decor { get; set; }
	    public string Modifiers { get; set; }
	    public byte[] Ability { get; set; } = new byte[3];

	    public byte Ext { get; set; } = (byte)2;
	    public int Body { get; set; }
	    public int X { get; set; }
	    public int Y { get; set; }
	    public int Z { get; set; }
	    public sbyte RotZ { get; set; }

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

		//Posture by YanLongli
	    public int PostureSet { get; set; }



		/// <summary>
		/// Name of dialog function to call on trigger,
		/// leave empty for no dialog hotkey display.
		/// </summary>
		public string DialogName { get; set; }

        /// <summary>
        /// Warp identifier?
        /// </summary>
        /// <remarks>
        /// Purpose unknown, doesn't seem to affect anything.
        /// Examples: WS_KLAPEDA_HIGHLANDER, WS_SIAULST1_KLAPEDA
        /// </remarks>
        public string WarpName { get; set; }

        /// <summary>
        /// Returns true if WarpName is not empty.
        /// </summary>
        public bool IsWarp { get { return !string.IsNullOrWhiteSpace(this.WarpName); } }

        /// <summary>
        /// Location to warp to.
        /// </summary>
        public Location WarpLocation { get; set; }

        /// <summary>
        /// Level.
        /// </summary>
        public int Level { get; set; } //в базе npcs: level

		/// <summary>
		/// Monster's position.
		/// </summary>
		public Position Position { get; set; } = new Position(0, 0, 0);
	    /// <summary>
	    /// Character's rotation.
	    /// </summary>
	    public Direction Heading { get; set; } = new Direction(0, 0, 0);

        /// <summary>
        /// Monster's direction.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// AoE Defense Ratio
        /// </summary>
        public int Sdr { get; set; }
		
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
	    /// Maximum MP.
	    /// </summary>
	    public int MaxMp { get; set; } = 0x0ffffff;

        /// <summary>
        /// Health points.
        /// </summary>
        public int Hp
        {
            get => _hp;
	        private set => _hp = Math2.Clamp(0, this.MaxHp, value);
        }
        private int _hp = 0x0ffffff; //TODO

        /// <summary>
        /// Maximum health points.
        /// </summary>
        public int MaxHp { get; private set; } = 0x0ffffff;

        /// <summary>
        /// Physical defense.
        /// </summary>
        public int Defense
        {
            get => _defense;
	        private set => _defense = Math.Max(0, value);
        }
        private int _defense;

        /// <summary>
        /// At this time the monster will be removed from the map.
        /// </summary>
        public DateTime DisappearTime { get; set; }

        /// <summary>
        /// Datas entry for this monster.
        /// </summary>
        public DoodadData Data { get; private set; }

        /// <summary>
        /// Loads data from data files.
        /// </summary>
        private void LoadData()
        {
            if (this.Id == 0)
            {
                throw new InvalidOperationException("Id wasn't set before calling LoadData.");
            }

			this.Data = AaData.DoodadDb.Find(this.Id);
            if (this.Data == null)
            {
                throw new NullReferenceException("No data found for '" + this.Id + "'.");
            }

			//this.Hp = this.MaxHp = this.Data.Hp;
			//this.Defense = this.Data.Defense;
        }

        /*
                /// <summary>
                /// Makes monster take damage and kills it if the HP reach 0.
                /// </summary>
                /// <param name="damage"></param>
                /// <param name="from"></param>
                public void TakeDamage(int damage, Character from)
                {
                    Hp -= damage;

                    // In earlier clients ZC_HIT_INFO was used, newer ones seem to
                    // use SKILL, and this doesn't create a double hit effect like
                    // the other.
                    Send.ZC_SKILL_HIT_INFO(from, this, damage);

                    if (Hp == 0)
                        Kill(from);
                }

                /// <summary>
                /// Kills monster.
                /// </summary>
                /// <param name="killer"></param>
                public void Kill(Character killer)
                {
                    var expRate = ChannelServer.Instance.Conf.World.ExpRate / 100;
                    var classExpRate = ChannelServer.Instance.Conf.World.ClassExpRate / 100;

                    var exp = 0;
                    var classExp = 0;

                    if (Datas.Exp > 0)
                        exp = (int)Math.Max(1, Datas.Exp * expRate);
                    if (Datas.ClassExp > 0)
                        classExp = (int)Math.Max(1, Datas.ClassExp * classExpRate);

                    DisappearTime = DateTime.Now.AddSeconds(2);
                    killer.GiveExp(exp, classExp, this);

                    Send.ZC_DEAD(this);
                }
        */
    }
}
