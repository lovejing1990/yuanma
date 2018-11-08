using System;
using System.Net;
using System.Net.Sockets;
using ArcheAgeGame.ArcheAge.Database;
using ArcheAgeGame.ArcheAge.Holders;
using ArcheAgeGame.ArcheAge.Network;
using ArcheAgeGame.ArcheAge.Network.Connections;
using ArcheAgeGame.ArcheAge.Scripting;
using ArcheAgeGame.ArcheAge.Utilites;
using ArcheAgeGame.ArcheAge.World;
using ArcheAgeGame.Properties;
using LocalCommons;
using LocalCommons.Logging;
using LocalCommons.Network;
using LocalCommons.UID;
using LocalCommons.Utilities;
using LocalCommons.Utilities.Commands;
using LocalCommons.Utilities.Configuration;

namespace ArcheAgeGame
{
	public class ArcheAgeGame : Server
	{
		public static readonly ArcheAgeGame Instance = new ArcheAgeGame();

		/// <summary>
		/// Configuration.
		/// </summary>
		public Conf Conf { get; private set; }

		/// <summary>
		/// Game server's database.
		/// </summary>
		public GameDb Database { get; private set; }

		/// <summary>
		/// Channel's console commands.
		/// </summary>
		public ConsoleCommands ConsoleCommands { get; private set; }

		/// <summary>
		/// GM commands.
		/// </summary>
		public GmCommands GmCommands { get; private set; }

		/// <summary>
		/// The world~
		/// </summary>
		public WorldManager World { get; private set; }

		/// <summary>
		/// Channel's script manager.
		/// </summary>
		public ScriptManager ScriptManager { get; private set; }

		/// <summary>
		/// Connection acceptor and manager.
		/// </summary>
		public ConnectionManager<ChannelConnection> ConnectionManager { get; private set; }

		public static UInt32UidFactory CharcterUid; //UID для персонажа
		public static UInt32UidFactory AccountUid; //UID для аккаунта
		public static UInt32UidFactory ObjectUid; //UID для вещей
		public static UInt24UidFactory LiveObjectUid; //UID для перемещений по карте

		public string ServerClientVersion = "3";

		/// <summary>
		/// Starts the server.
		/// </summary>
		public override void Run()
		{
			this.SelectVersion();

			base.Run();

			CliUtil.WriteHeader("Game", ConsoleColor.DarkGreen);
			CliUtil.LoadingTitle();

			// Conf
			this.LoadConf(this.Conf = new Conf());

			// Database
			this.InitDatabase(this.Database = new GameDb(), this.Conf);

			// Data
			this.LoadData(DataToLoad.All, true);

			// GM Commands
			this.GmCommands = new GmCommands();

			// Packet handlers
			//ChannelPacketHandler.Instance.RegisterMethods();

			// World
			Log.Info("Initializing world...");
			this.World.Initialize();
			Log.Info("  done loading {0} maps.", this.World.Count);

			// Script manager
			this.ScriptManager.Initialize();
			this.ScriptManager.Load();

			// Get channel data
			const int serverId = 1;
			var serverData = this.Data.ServerDb.FindChannel(serverId);
			if (serverData == null)
			{
				Log.Error("Server data not found. ({0})", serverId);
				CliUtil.Exit(1);
			}

			// Ready
			CliUtil.RunningTitle();
			//Log.Status("Server ready, listening on {0}.", this.ConnectionManager.Address);

			//----- Initialize Commons --------------------------------
			//Logger.Init(); //Load Logger
			//LocalCommons.Main.InitializeStruct(args); //Initializing LocalCommons.dll
			AccountUid = new UInt32UidFactory(AccountHolder.MaxAccountUid());      //генерим UID для аккаунтов
			uint uid = CharacterHolder.MaxCharacterUid();
			CharcterUid = new UInt32UidFactory(uid); //генерим UID для персонажей
													 //ObjectUid = new UInt32UidFactory(CharacterHolder.MaxObjectUid()); //генерим UID для вещей
			ObjectUid = new UInt32UidFactory(); //TODO: тест, пока начинаем с нуля
			LiveObjectUid = new UInt24UidFactory(uid); //TODO: генерим UID как для персонажей
			var mCurrent = Settings.Default;

			//------ Network ------------------------------------------
			//Logger.Section("Network");
			// Server
			//this.ConnectionManager = new ConnectionManager<ChannelConnection>(serverData.Port);
			//this.ConnectionManager.Start();

			DelegateList.Initialize(this.ServerClientVersion);
			InstallLoginServer();
			new AsyncListener(mCurrent.ArcheAge_IP, mCurrent.ArcheAge_Port, typeof(ClientConnection)); //Waiting For ArcheAge Connections

			// Commands
			this.ConsoleCommands = new ConsoleCommands();
			this.ConsoleCommands.Wait();
		}

		/// <summary>
		/// Creates new channel server.
		/// </summary>
		private ArcheAgeGame()
		{
			this.World = new WorldManager();
			this.ScriptManager = new ScriptManager();
		}

		private void SelectVersion()
		{
			Log.Info("Select Client Version: Default 3");
			Log.Info("1:   1.0");
			Log.Info("3:   3.0");
			Log.Info("4:   4.0");
			//0 is manually selected
			if (Settings.Default.ServerClientVersion == "0")
			{
				this.ServerClientVersion = Console.ReadLine();
				if (this.ServerClientVersion == "")
				{
					//The default is 3
					this.ServerClientVersion = "3";
				}
			}
			else
			{
				Log.Info("AutoSelectServerClientVersion:" + Settings.Default.ServerClientVersion);
				this.ServerClientVersion = Settings.Default.ServerClientVersion;
			}
		}

		private static void InstallLoginServer()
		{
			while (true)
			{
				var point = new IPEndPoint(IPAddress.Parse(Settings.Default.LoginServer_IP), Settings.Default.LoginServer_Port);
				var con = new Socket(point.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					con.Connect(point);
				}
				catch (Exception)
				{
					//throw exp;
					Logger.Trace("Unable to connect to login server, retry after 1 second");
				}

				if (con.Connected)
				{
					new LoginConnection(con);
				}
				else
				{
					continue;
				}

				break;
			}
		}
	}
}
