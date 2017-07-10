using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AdvanceFileSystem
{
    public class Connection
    {
        private static MySqlConnection Conn;

        /*#region Queries

        private static String SelectAccount = "SELECT * FROM users WHERE username = @username and password = @password;";

        #endregion*/

        //هذا الفنكشن بيتحقق اذا في اتصال بيرجع الاتصال الحالي واذا ما في بسوي واحد جديد
        public static MySqlConnection Connect()
        {
            if (Conn == null)
            {
                Conn = new MySqlConnection("Server=127.0.0.1;Uid=root;Pwd=;Database=graduation;");
                try
                {
                    Conn.Open();
                }
                catch
                {
                    throw new Exception(Extra.Errors.ConnectionError);
                }
            }
            return Conn;
        }

        
        public static MySqlDataReader ExecuteReader(string query)
        {
            Connect();
            return CreateCommand(query).ExecuteReader();
        }

        public static int ExecuteNonQuery(string query)
        {
            Connect();
            return CreateCommand(query).ExecuteNonQuery();
        }

        public static MySqlCommand CreateCommand()
        {
            Connect();
            return Conn.CreateCommand();
        }

        public static MySqlCommand CreateCommand(string query)
        {
            Connect();
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = query;
            return cmd;
        }
    }
}
