using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;
using ArcheAgeLogin.ArcheAge.Network;
using ArcheAgeLogin.ArcheAge.Structuring;
using LocalCommons.Logging;

namespace ArcheAgeLogin.ArcheAge
{
	/// <summary>
	/// Controller For Game Servers And Authorized Accounts
	/// Contains All Current Game Servers Info and Current Authroized Accounts.
	/// </summary>
	public static class ArcheAgeGameController
	{
		public static Dictionary<long, Account> AuthorizedAccounts { get; } = new Dictionary<long, Account>();

		public static Dictionary<byte, ArcheAgeGame> CurrentArcheAgeGames { get; } = new Dictionary<byte, ArcheAgeGame>();

		public static bool RegisterArcheAgeGame(byte id, string password, GameConnection con, short port, string ip)
		{
			if (!CurrentArcheAgeGames.ContainsKey(id))
			{
				Log.Info("Game Server ID: {0} is not defined, please check", id);
				return false;
			}

			var template = CurrentArcheAgeGames[id]; //Checking Containing By Packet

			if (con.CurrentInfo != null) //Fully Checking.
			{
				con.CurrentInfo = null;
			}

			if (template.password != password) //Checking Password
			{
				Log.Info("Game Server ID: {0} bad password", id);
				return false;
			}

			var server = CurrentArcheAgeGames[id];
			server.CurrentConnection = con;
			server.IPAddress = ip;
			server.Port = port;
			con.CurrentInfo = server;
			//Update
			CurrentArcheAgeGames.Remove(id);
			CurrentArcheAgeGames.Add(id, server);
			Log.Info("Game Server ID: {0} registered", id);
			return true;
		}
		public static bool DisconnecteArcheAgeGame(byte id)
		{
			var server = CurrentArcheAgeGames[id];
			server.CurrentConnection = null;
			CurrentArcheAgeGames.Remove(id);
			CurrentArcheAgeGames.Add(id, server);
			return true;
		}

		public static void LoadAvailableArcheAgeGames()
		{
			var ser = new XmlSerializer(typeof(ArcheAgeGameTemplate));
			var template = (ArcheAgeGameTemplate)ser.Deserialize(new FileStream(@"system/data/Servers.xml", FileMode.Open));
			for (var i = 0; i < template.xmlservers.Count; i++)
			{
				var game = template.xmlservers[i];
				game.CurrentAuthorized = new List<long>();
				CurrentArcheAgeGames.Add(game.Id, game);
			}

			Log.Info("Loading from Servers.xml {0} servers", CurrentArcheAgeGames.Count);
		}
	}

	#region Classes For Server Info Deserialization.

	[Serializable]
	[XmlType(AnonymousType = true)]
	[XmlRoot(ElementName = "servers", Namespace = "", IsNullable = false)]
	public class ArcheAgeGameTemplate
	{
		[XmlElement("server", Form = XmlSchemaForm.Unqualified)]
		public List<ArcheAgeGame> xmlservers;
	}

	[Serializable]
	[XmlType(Namespace = "", AnonymousType = true)]
	public class ArcheAgeGame
	{
		[XmlAttribute]
		public byte Id;

		[XmlIgnore]
		public string IPAddress;

		[XmlIgnore]
		public short Port;

		[XmlIgnore]
		public List<long> CurrentAuthorized;

		[XmlIgnore]
		public GameConnection CurrentConnection;

		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public short MaxPlayers;

		[XmlAttribute]
		public string password;

		public bool IsOnline()
		{
			return this.CurrentConnection != null;
		}
	}

	#endregion
}
