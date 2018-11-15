using LocalCommons.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using ArcheAgeGame.ArcheAge.Structuring;
using ArcheAgeGame.Properties;

namespace ArcheAgeGame.ArcheAge.Holders
{
    public class AccountHolder
    {
        private static List<Account> _mDbAccounts;

        /// <summary>
        /// Loaded List of Accounts.
        /// </summary>
        public static List<Account> AccountList
        {
            get { return _mDbAccounts; }
        }

        /// <summary>
        /// Gets Account By Name With LINQ Or Return Null.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Account GetAccount(string name)
        {
            return _mDbAccounts.FirstOrDefault(acc => acc.Name == name);
        }


        /// <summary>
        /// Возвращает максимальный использованный ID
        /// </summary>
        /// <returns></returns>
        public static uint MaxAccountUid()
        {
            uint uid = 0;
            using (var conn = new MySqlConnection(Settings.Default.DataBaseConnectionString))
            {
                try
                {
                    conn.Open();
                    var command = new MySqlCommand("SELECT * FROM `accounts`", conn);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var account = new Account();
                        account.AccountId = reader.GetUInt32("accountid");
                        if (uid < account.AccountId)
                        {
                            uid = (uint) account.AccountId;
                        }
                    }
                    command.Dispose();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Log.Info("Error: {0}", ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            return uid;
        }

        ///// <summary>
        ///// Fully Load Account Data From Current MySql DataBase.
        ///// </summary>
        //public static void LoadAccountData()
        //{
        //    _mDbAccounts = new List<Account>();
        //    var con = new MySqlConnection(Settings.Default.DataBaseConnectionString);
        //    try
        //    {
        //        con.Open();
        //        var command = new MySqlCommand("SELECT * FROM `accounts`", con);
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var account = new Account();
        //            var character = new Character();

        //            account.AccessLevel = reader.GetByte("mainaccess");
        //            account.AccountId = reader.GetUInt32("accountid");
        //            account.Name = reader.GetString("name");
        //            account.Token = reader.GetString("token");
        //            account.LastEnteredTime = reader.GetInt64("last_online");
        //            account.LastIp = reader.GetString("last_ip");
        //            account.Membership = reader.GetByte("useraccess");
        //            account.CharactersCount = reader.GetByte("characters");
        //            account.Session = reader.GetInt32("cookie");
        //            account.Character = character; //заполним пустыми данными

        //            _mDbAccounts.Add(account);
        //        }
        //        command.Dispose();
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        if (e.Message.IndexOf("using password: YES") >= 0)
        //        {
        //            Log.Info("Error: Incorrect username or password");
        //        }
        //        else if (e.Message.IndexOf("Unable to connect to any of the specified MySQL hosts") >= 0)
        //        {
        //            Log.Info("Error: Unable to connect to database");
        //        }
        //        else
        //        {
        //            Log.Info("Error: Unknown error");
        //        }
        //        //Console.ReadKey();
        //        //Message = "Authentication to host '127.0.0.1' for user 'root' using method 'mysql_native_password' failed with message: Access denied for user 'root'@'localhost' (using password: YES)"
        //    }
        //    finally
        //    {
        //        con.Close();
        //        Log.Info("Load to {0} accounts", _mDbAccounts.Count);
        //    }
        //}

        /// <summary>
        /// Inserts Or Update Existing Account Into your current Login Server MySql DataBase.
        /// </summary>
        /// <param name="account">Your Account Which you want Insert(If Not Exist) Or Update(If Exist)</param>
        public static void InsertOrUpdate(Account account)
        {
            var con = new MySqlConnection(Settings.Default.DataBaseConnectionString);
            try
            {
                con.Open();
                MySqlCommand command = null;
                if (_mDbAccounts.Contains(account))
                {
                    command = new MySqlCommand(
                        "UPDATE `accounts` SET `accountid` = @accountid, `name` = @name, `token` = @token, `mainaccess` = @mainaccess," +
                        " `useraccess` = @useraccess, `last_ip` = @lastip, `last_online` = @lastonline, `cookie` = @cookie, `characters` = @characters" +
                        " WHERE `accountid` = @aid",
                        con);

                    //command.Parameters.Add("@accountid", MySqlDbType.UInt32).Value = account.AccountId;
                }
                else
                {
                    command = new MySqlCommand(
                        "INSERT INTO `accounts`(accountid, name, token,  mainaccess, useraccess, last_ip, last_online, characters, cookie)" +
                        "VALUES(@accountid, @name, @token, @mainaccess, @useraccess, @lastip, @lastonline, @characters, @cookie)",
                        con);

                    //command.Parameters.Add("@accountid", MySqlDbType.UInt32).Value = Program.AccountUid.Next();  //incr index key
                }
                var parameters = command.Parameters;

                parameters.Add("@accountid", MySqlDbType.String).Value = account.AccountId;
                parameters.Add("@name", MySqlDbType.String).Value = account.Name;
                parameters.Add("@token", MySqlDbType.String).Value = account.Token;
                parameters.Add("@mainaccess", MySqlDbType.Byte).Value = account.AccessLevel;
                parameters.Add("@useraccess", MySqlDbType.Byte).Value = account.Membership;
                parameters.Add("@lastip", MySqlDbType.String).Value = account.LastIp;
                parameters.Add("@lastonline", MySqlDbType.Int64).Value = account.LastEnteredTime;
                parameters.Add("@characters", MySqlDbType.Byte).Value = account.CharactersCount;
                parameters.Add("@cookie", MySqlDbType.Int32).Value = account.Session;

                if (_mDbAccounts.Contains(account))
                {
                    parameters.Add("@aid", MySqlDbType.UInt32).Value = account.AccountId;
                }

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                Log.Info("Cannot InsertOrUpdate template for " + account.Name + ": {0}", e);
            }
            finally
            {
                _mDbAccounts.Add(account);
                con.Close();
            }
        }
    }
}
