using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using LocalCommons.Database;
using LocalCommons.Logging;
using LocalCommons.Utilities;
using MySql.Data.MySqlClient;

namespace ArcheAgeLogin.ArcheAge.Database
{
    public class LoginDb : ArcheageDb
    {
        /// <summary>
        /// Checks whether the SQL update file has already been applied.
        /// </summary>
        /// <param name="updateFile"></param>
        /// <returns></returns>
        public bool CheckUpdate(string updateFile)
        {
            using (var conn = this.GetConnection())
            using (var mc = new MySqlCommand("SELECT * FROM `updates` WHERE `path` = @path", conn))
            {
                mc.Parameters.AddWithValue("@path", updateFile);

                using (var reader = mc.ExecuteReader())
                    return reader.Read();
            }
        }

        /// <summary>
        /// Executes SQL update file.
        /// </summary>
        /// <param name="updateFile"></param>
        public void RunUpdate(string updateFile)
        {

			string[] result = Regex.Split(File.ReadAllText(Path.Combine("sql", updateFile)), @"([^\\];)");
			try
			{
				using (var conn = this.GetConnection())
				{

					//stop autocommit
					using (var cmd = conn.CreateCommand())
					{
						cmd.CommandText = "SET AUTOCOMMIT = 0";
						cmd.ExecuteNonQuery();
					}

					// Run update
					using (var cmd = new MySqlCommand(File.ReadAllText(Path.Combine("sql", updateFile)), conn))
					{
						Log.Info("GameServer need to connect only after loading all SQL! We are waiting for a long download of large SQL files!");
						cmd.CommandTimeout = 3600; //ждем долгой загрузки больших SQL файлов. Обычно, это значение - десятки секунд.
						cmd.ExecuteNonQuery();
					}
					//cmd.ExecuteNonQuery();
					//}

					// Log update
					using (var cmd = new InsertCommand("INSERT INTO `updates` {0}", conn))
					{
						cmd.Set("path", updateFile);
						cmd.Execute();
					}

					// recovery autocommit
					using (var cmd = conn.CreateCommand())
					{
						cmd.CommandText = "SET AUTOCOMMIT = 1";
						cmd.ExecuteNonQuery();
					}

					Log.Info("Successfully applied '{0}'.", updateFile);
				}
			}
			catch (Exception ex)
			{
				using (var conn = this.GetConnection())
				{
					MySqlTransaction transaction = conn.BeginTransaction();

					// recovery autocommit
					using (var cmd = conn.CreateCommand())
					{
						cmd.CommandText = "SET AUTOCOMMIT = 1";
						cmd.ExecuteNonQuery();
					}
				}

				Log.Error("RunUpdate: Failed to run '{0}': {1}", updateFile, ex.Message);
				CliUtil.Exit(1);
			}
        }
        /// <summary>
        /// Deletes character.
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public bool DeleteCharacter(long characterId)
        {
            using (var conn = this.GetConnection())
            using (var mc = new MySqlCommand("DELETE FROM `characters` WHERE `characterId` = @characterId", conn))
            {
                mc.Parameters.AddWithValue("@characterId", characterId);

                return mc.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Changes the given account's auth level.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool ChangeAuth(string accountName, int level)
        {
            using (var conn = this.GetConnection())
            using (var cmd = new UpdateCommand("UPDATE `accounts` SET {0} WHERE `name` = @accountName", conn))
            {
                cmd.AddParameter("@accountName", accountName);
                cmd.Set("mainaccess", level);
	            //cmd.Set("useraccess", level);

				return (cmd.Execute() > 0);
            }
        }

        /// <summary>
        /// Changes the given account's password.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="password"></param>
        public void SetAccountPassword(string accountName, string password)
        {
            var md5 = MD5.Create();
            var hashedPassword = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");

            using (var conn = this.GetConnection())
            using (var mc = new MySqlCommand("UPDATE `accounts` SET `token` = @password WHERE `name` = @accountName", conn))
            {
                mc.Parameters.AddWithValue("@accountName", accountName);
                mc.Parameters.AddWithValue("@password", hashedPassword);

                mc.ExecuteNonQuery();
            }
        }
    }
}
