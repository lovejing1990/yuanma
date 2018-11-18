using LocalCommons.Database;
using LocalCommons.Logging;
using MySql.Data.MySqlClient;
using System;
using System.IO;

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
            using (var conn = GetConnection())
            using (var mc = new MySqlCommand("SELECT * FROM `updates` WHERE `path` = @path", conn))
            {
                mc.Parameters.AddWithValue("@path", updateFile);

                using (var reader = mc.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        /// <summary>
        /// Executes SQL update file.
        /// </summary>
        /// <param name="updateFile"></param>
        public void RunUpdate(string updateFile)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    // Run update
                    using (var cmd = new MySqlCommand(File.ReadAllText(Path.Combine("sql", updateFile)), conn))
                    {
                        Logger.Trace("We are waiting for a long download of large SQL files!\nIt is necessary to wait for loading of SQL and only then to start GameServer!\nAdditional: Set parameter max_allowed_packet=16M in c:\\ProgramData\\MySQL\\MySQL Server 8.0\\my.ini");
                        cmd.CommandTimeout = 3600; //ждем долгой загрузки больших SQL файлов. Обычно, это значение 30 секунд.
                        cmd.ExecuteNonQuery();
                    }

                    // Log update
                    using (var cmd = new InsertCommand("INSERT INTO `updates` {0}", conn))
                    {
                        cmd.Set("path", updateFile);
                        cmd.Execute();
                    }

                    Logger.Trace("Successfully applied '{0}'.", updateFile);
                }
            }
            catch (Exception ex)
            {
                Logger.Trace("RunUpdate: Failed to run '{0}': {1}", updateFile, ex.Message);
                Program.Shutdown();
            }
        }
    }
}
