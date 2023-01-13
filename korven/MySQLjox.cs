using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient; // referens dll --- C:\Program Files (x86)\MySQL\Connector NET 8.0\Assemblies\v4.5.2\MySql.Data.dll

namespace korven
{
    class MySQLjox
    {
        //public static string ConnectionStringMySQL = $"Server={server};uid={};pwd={};database={}";

        string server = "127.0.0.1";

        public static string ConnectionStringMySQL = string.Empty;

        public static DataTable SQLFind(string query)
        {
            var dt = new DataTable();
            using (var mySQLConnection = new MySqlConnection(ConnectionStringMySQL))
            {
                var mySQLDataAdapter = new MySqlDataAdapter();

                try
                {
                        mySQLConnection.Open();
                        var Command = new MySqlCommand(query, mySQLConnection);
                        mySQLDataAdapter.SelectCommand = Command;
                        mySQLDataAdapter.Fill(dt);
                        mySQLDataAdapter.Update(dt);
                        mySQLConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }

        public static void RunQuery(string SQLInput)
        {
            try
            {
                using (var mySQLConnection = new MySqlConnection(ConnectionStringMySQL))
                {
                    mySQLConnection.Open();

                    var Command = new MySqlCommand(SQLInput, mySQLConnection);
                    Command.ExecuteNonQuery();

                    mySQLConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
