// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder
using LocalCommons.Utilities.Configuration;

namespace LocalCommons.Utilities.Configuration.Files
{
	/// <summary>
	/// Represents web.conf
	/// </summary>
	public class WebConfFile : ConfFile
	{
		public int Port { get; protected set; }

		public void Load()
		{
			this.Require("system/conf/web.conf");

			this.Port = this.GetInt("port", 80);
		}
	}
}
