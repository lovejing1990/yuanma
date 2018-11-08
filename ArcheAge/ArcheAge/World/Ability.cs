// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using LocalCommons.Const;
using LocalCommons.World.ObjectProperties;

namespace ArcheAgeGame.ArcheAge.World
{
	/// <summary>
	/// A character's ability.
	/// </summary>
	public class Ability : IPropertyObject
	{
		/// <summary>
		/// The ability's object id.
		/// </summary>
		public long ObjectId { get; }

		/// <summary>
		/// The ability's properties.
		/// </summary>
		public LocalCommons.World.ObjectProperties.Properties Properties { get; } = new LocalCommons.World.ObjectProperties.Properties();

		/// <summary>
		/// The ability's id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The ability's level.
		/// </summary>
		public int Level { get; set; } = 1;

		/// <summary>
		/// Whether the ability is active.
		/// </summary>
		public bool Active { get; set; } = true;

		/// <summary>
		/// Creates new instance.
		/// </summary>
		public Ability(int abilityId, int level)
		{
			// It seems like abilities and session objects use the same
			// id pool on officials, so we'll do the same for now.
			this.ObjectId = ArcheAgeGame.Instance.World.CreateSessionObjectId();

			this.Id = abilityId;
			this.Level = level;

			this.Properties.Add(new RefFloatProperty(PropertyId.Ability.Level, () => this.Level));
			this.Properties.Add(new RefFloatProperty(PropertyId.Ability.ActiveState, () => this.Active ? 1 : 0));
		}
	}
}
