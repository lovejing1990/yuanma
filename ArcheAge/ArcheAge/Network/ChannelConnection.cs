// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using ArcheAgeGame.ArcheAge.Database;
using ArcheAgeGame.ArcheAge.Scripting;
using ArcheAgeGame.ArcheAge.World;
using LocalCommons.Network;

namespace ArcheAgeGame.ArcheAge.Network
{
	public class ChannelConnection : Connection
	{
		/// <summary>
		/// Account associated with this connection.
		/// </summary>
		public Account Account { get; set; }

		/// <summary>
		/// Gets or set connection's script state.
		/// </summary>
		public ScriptState ScriptState { get; private set; }

		/// <summary>
		/// Active character.
		/// </summary>
		public Character SelectedCharacter { get; set; }

		/// <summary>
		/// Instantiates new channel connection.
		/// </summary>
		public ChannelConnection()
			: base()
		{
			this.ScriptState = new ScriptState(this);
		}

		/// <summary>
		/// Handles channel packets.
		/// </summary>
		/// <param name="packet"></param>
		protected override void HandlePacket(Packet packet)
		{
			ChannelPacketHandler.Instance.Handle(this, packet);
		}

		/// <summary>
		/// Cleans up connection, incl. account and characters.
		/// </summary>
		protected override void CleanUp()
		{
			this.Account.Save();

			if (this.SelectedCharacter != null)
			{
				this.SelectedCharacter.Map.RemoveCharacter(this.SelectedCharacter);
				ArcheAgeGame.Instance.Database.SaveCharacter(this.SelectedCharacter);
			}

			this.ScriptState.Reset();
		}
	}
}
