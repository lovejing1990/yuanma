// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
namespace ArcheAgeGame.ArcheAge.World
{
	/// <summary>
	/// A session object, duh.
	/// </summary>
	/// <remarks>
	/// The exact purpose of those objects is unknown right now,
	/// but apparently they hold some properties of importance.
	/// </remarks>
	public class SessionObject : IPropertyObject
	{
		/// <summary>
		/// The object's unique, global id.
		/// </summary>
		public long ObjectId { get; } = ArcheAgeGame.Instance.World.CreateSessionObjectId();

		/// <summary>
		/// The object's id.
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// The object's properties.
		/// </summary>
		public LocalCommons.World.ObjectProperties.Properties Properties { get; } = new LocalCommons.World.ObjectProperties.Properties();

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="id"></param>
		public SessionObject(int id)
		{
			this.Id = id;
		}
	}
}
