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

        /*
         * 
         * انسوهم مؤقتا
        public static int Execute(string query)
        {
            Connect();
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = query;
            return cmd.ExecuteNonQuery();
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
            cmd.Prepare();
            return cmd;
        }

        public static bool CheckAccount(string username,string password)
        {
            Connect();
            MySqlCommand cmd = CreateCommand(SelectAccount);

            password = Extra.Encrypt.MD5(password);
            
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader _Reader = cmd.ExecuteReader();
            bool HasRows = _Reader.HasRows;
            _Reader.Close();
            return HasRows;
        }
        */
    }
}
