// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace LocalCommons.Data.Database
{
	[Serializable]
	public class DoodadData
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public string Name { get; set; }
		//public int Level { get; set; }
		//public int Exp { get; set; }
		//public int ClassExp { get; set; }
		//public int Hp { get; set; }
		//public int Defense { get; set; }
	}

	/// <inheritdoc />
	/// <summary>
	/// Monster database, indexed by monster id.
	/// </summary>
	public class DoodadDb : DatabaseJsonIndexed<int, DoodadData>
	{
		public DoodadData Find(string name)
		{
			name = name.ToLower();
			return this.Entries.FirstOrDefault(a => a.Value.Name.ToLower() == name).Value;
		}

		public List<DoodadData> FindAll(string name)
		{
			name = name.ToLower();
			return this.Entries.FindAll(a => a.Value.Name.ToLower().Contains(name));
		}

		protected override void ReadEntry(JObject entry)
		{
			//entry.AssertNotMissing("doodadId", "className", "name", "level", "exp", "classExp", "hp", "defense");
			entry.AssertNotMissing("doodadId", "className", "name");

			var info = new DoodadData
			{
				Id = entry.ReadInt("doodadId"),
				ClassName = entry.ReadString("className"),
				Name = entry.ReadString("name"),
				//Level = entry.ReadInt("level"),
				//Exp = entry.ReadInt("exp"),
				//ClassExp = entry.ReadInt("classExp"),
				//Hp = entry.ReadInt("hp"),
				//Defense = entry.ReadInt("defense")
			};

			this.Entries[info.Id] = info;
		}
	}
}
