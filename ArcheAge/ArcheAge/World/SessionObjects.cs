// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using System.Collections.Generic;
using System.Linq;

namespace ArcheAgeGame.ArcheAge.World
{
	/// <summary>
	/// Session object collection.
	/// </summary>
	public class SessionObjects
	{
		private Dictionary<int, SessionObject> _objects = new Dictionary<int, SessionObject>();

		/// <summary>
		/// Adds given session object to collection.
		/// </summary>
		/// <param name="obj"></param>
		public void Add(SessionObject obj)
		{
			lock (this._objects)
				this._objects[obj.Id] = obj;
		}

		/// <summary>
		/// Removes session object with given id, returns false if it
		/// didn't exist.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public bool Remove(int sessionObjectId)
		{
			lock (this._objects)
				return this._objects.Remove(sessionObjectId);
		}

		/// <summary>
		/// Returns session object with given id, or null if it didn't
		/// exist.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public SessionObject Get(int sessionObjectId)
		{
			lock (this._objects)
			{
				this._objects.TryGetValue(sessionObjectId, out var obj);
				return obj;
			}
		}

		/// <summary>
		/// Returns session object with given id. If it doesn't exist,
		/// it's created.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public SessionObject GetOrCreate(int sessionObjectId)
		{
			lock (this._objects)
			{
				if (!this._objects.TryGetValue(sessionObjectId, out var obj))
					obj = new SessionObject(sessionObjectId);
				return obj;
			}
		}

		/// <summary>
		/// Returns a list with all session objects.
		/// </summary>
		/// <returns></returns>
		public SessionObject[] GetList()
		{
			lock (this._objects)
				return this._objects.Values.ToArray();
		}
	}
}
