using ArcheAgeLogin.ArcheAge.Holders;
using ArcheAgeLogin.Properties;
using LocalCommons.Logging;
using LocalCommons.UID;
using LocalCommons.Utilities;
using System;
using System.Diagnostics;
using ArcheAgeLogin.ArcheAge;
using ArcheAgeLogin.ArcheAge.Network;
using LocalCommons.Network;

namespace ArcheAgeLogin
{
    /// <summary>
    /// Main Class For Program Entering.
    /// </summary>
    class Program
    {
	    static void Main(string[] args)
	    {
		    try
		    {
			    LoginServer.Instance.Run();
		    }
		    catch (Exception ex)
		    {
			    Log.Error("Error on startup: {0}, {1}", ex.GetType().Name, ex.Message);
			    CliUtil.Exit(1, true);
		    }
	    }
    }
}
