using ArcheAgeLogin.ArcheAge;
using ArcheAgeLogin.ArcheAge.Holders;
using ArcheAgeLogin.ArcheAge.Network;
using ArcheAgeLogin.Properties;
using LocalCommons;
using LocalCommons.Logging;
using LocalCommons.Network;
using LocalCommons.Utilities;
using LocalCommons.Utilities.Commands;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ArcheAgeLogin.ArcheAge.Database;
using ArcheAgeLogin.ArcheAge.Utilites;
using ArcheAgeLogin.ArcheAge.Utilites.Configuration;
using LocalCommons.UID;


namespace ArcheAgeLogin
{
    public class LoginServer : Server
    {
        public static readonly LoginServer Instance = new LoginServer();

        /// <summary>
        /// Configuration.
        /// </summary>
        public LoginConf Conf { get; private set; }

        /// <summary>
        /// Login server's database.
        /// </summary>
        public LoginDb Database { get; private set; }

        /// <summary>
        /// Login's console commands.
        /// </summary>
        public ConsoleCommands ConsoleCommands { get; private set; }
		
		public static UInt32UidFactory CharcterUid; //UID для персонажа
		public static UInt32UidFactory AccountUid; //UID для аккаунта

	    public string ServerClientVersion = "3";

		/// <summary>
		/// Starts the server.
		/// </summary>
		public override void Run()
        {
	        this.SelectVersion();

			base.Run();

            CliUtil.WriteHeader("Login", ConsoleColor.DarkGray);
            CliUtil.LoadingTitle();
           
	        // Data
			this.LoadData(DataToLoad.Jobs | DataToLoad.Maps | DataToLoad.Barracks | DataToLoad.Servers | DataToLoad.Items | DataToLoad.Exp, true);

	        // Conf
	        this.LoadConf(this.Conf = new LoginConf());

			// Database
			this.InitDatabase(this.Database = new LoginDb(), this.Conf);

            // Check if there are any updates
            this.CheckDatabaseUpdates();

            // Packet handlers
            //LoginPacketHandler.Instance.RegisterMethods();

            // Get server data
            const int serverId = 1;
            var serverData = this.Data.ServerDb.FindLogin(serverId);
            if (serverData == null)
            {
                Log.Error("Server data not found. ({0})", serverId);
                CliUtil.Exit(1);
            }

            // Ready
            CliUtil.RunningTitle();
			//Log.Status("Server ready, listening on {0}.", mgr.Address);

			//--------------- Init Commons ----------------------
			Logger.Init(); //Load Logger
			//LocalCommons.Main.InitializeStruct(args);
			AccountUid = new UInt32UidFactory(AccountHolder.MaxAccountUid()); //генерим UID для аккаунтов
	        CharcterUid = new UInt32UidFactory(CharacterHolder.MaxCharacterUid()); //генерим UID для персонажей
	        var mCurrent = Settings.Default;

			//------------- Controllers -------------------------
	        Logger.Section("Controllers");
	        ArcheAgeGameController.LoadAvailableArcheAgeGames();

			//--------------- MySQL ---------------------------
	        Logger.Section("MySQL");
	        AccountHolder.LoadAccountData();

			//----------------Network ---------------------------
			Logger.Section("Network");

			// Server
			//var mgr = new ConnectionManager<LoginConnection>(serverData.Port);
			//mgr.Start();

	        PacketList.Initialize(this.ServerClientVersion);
			new AsyncListener(mCurrent.Main_IP, mCurrent.Game_Port, typeof(GameConnection)); //Waiting For ArcheAgeGame Connections
	        new AsyncListener(mCurrent.Main_IP, mCurrent.ArcheAge_Port, typeof(ArcheAgeConnection)); //Waiting For ArcheAge Connections


			// Commands
			this.ConsoleCommands = new LoginConsoleCommands();
            this.ConsoleCommands.Wait();
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

		private void CheckDatabaseUpdates()
        {
            Log.Info("Checking for updates...");

            var files = Directory.GetFiles("sql");
            foreach (var filePath in files.Where(file => Path.GetExtension(file).ToLower() == ".sql"))
                this.RunUpdate(Path.GetFileName(filePath));
        }

        private void RunUpdate(string updateFile)
        {
            if (Instance.Database.CheckUpdate(updateFile))
                return;

            Log.Info("Update '{0}' found, executing...", updateFile);

            Instance.Database.RunUpdate(updateFile);
        }
    }
}
