using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AdvanceFileSystem.Models;

namespace AdvanceFileSystem
{
    public class Connection
    {
        private static MySqlConnection Conn;

        #region Queries

        private static String SelectAccount = "SELECT * FROM users WHERE username = @username and password = @password;";
        private static string InsertCitizenQuery = "INSERT INTO `citizens`(`id`,`full_name`,`birthdate`,`address_id`,`street`,`pobox`) VALUES('{0}','{1}','{2}','{3}','{4}','{5}');";
        private static string UpdateCitizenQuery = "UPDATE `citizens` SET full_name = @FullName, `birthdate` = @BirthDate, `address_id` = @AddressId, `street` = @Street, `pobox` = @PoBox WHERE `id` = @Id;";

        #endregion

        //هذا الفنكشن بيتحقق اذا في اتصال بيرجع الاتصال الحالي واذا ما في بسوي واحد جديد
        public static MySqlConnection Connect()
        {
            if (Conn == null)
            {
                Conn = new MySqlConnection("Server=127.0.0.1;Uid=root;Pwd=;Database=graduation;;CHARSET=utf8");
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

        public static int UpdateAddress(Address add)
        {
            return ExecuteNonQuery("UPDATE address SET `address` = '" + add.Name + "' WHERE `id` = '" + add.Id + "';");
        }

        public static List<Address> GetAddresses()
        {
            List<Address> adds = new List<Address>();
            MySqlDataReader _Reader = ExecuteReader("Select * from address");
            while (_Reader.Read())
            {
                adds.Add(new Address()
                {
                    Id = _Reader.GetInt16("id"),
                    Name = _Reader.GetString("address")
                });
            }
            _Reader.Close();
            return adds;
        }

        public static bool CitizenExisits(int cardId)
        {
            MySqlDataReader Reader = Connection.ExecuteReader("SELECT * FROM citizens WHERE id = '" + cardId + "';");
            if (Reader.HasRows)
            {
                Reader.Close();
                return true;
            }else
            {
                Reader.Close();
                return false;
            }
        }

        public static int InsertCitizen(Citizen cit)
        {
            if (CitizenExisits(cit.Id))
            {
                throw new Exception("There is a citizen with this card id");
            }
            return Connection.ExecuteNonQuery(
                string.Format(InsertCitizenQuery,
                cit.Id,
                cit.FullName,
                cit.BirthDate.ToString("yyyy-MM-dd"),
                cit.AddressId,
                cit.Street,
                cit.PoBox));
        }

        public static long InsertAddress(string address)
        {
            MySqlCommand cmd = CreateCommand("INSERT INTO address (address) VALUES('" + address + "');");
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public static int UpdateCitizen(Citizen cit)
        {
            MySqlCommand cmd = CreateCommand(UpdateCitizenQuery);
            cmd.Parameters.AddWithValue("@FullName", cit.FullName);
            cmd.Parameters.AddWithValue("@BirthDate", cit.BirthDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@AddressId", cit.AddressId);
            cmd.Parameters.AddWithValue("@Street", cit.Street);
            cmd.Parameters.AddWithValue("@PoBox", cit.PoBox);
            cmd.Parameters.AddWithValue("@Id", cit.Id);
            cmd.Prepare();

            return cmd.ExecuteNonQuery();
        }

        public static List<Citizen> GetCitizens()
        {
            MySqlDataReader Reader = ExecuteReader("SELECT `citizens`.`id`,`full_name`,`birthdate`,`address_id`,`street`,`pobox`,`address` FROM citizens LEFT JOIN address ON citizens.address_id = address.id");
            List<Citizen> cits = new List<Citizen>();
            while (Reader.Read())
            {
                Citizen c = new Citizen();
                c.AddressId = Reader.GetInt16("address_id");
                c.Address = new Address()
                {
                    Id = Reader.GetInt16("address_id"),
                    Name = Reader.GetString("address")
                };
                c.Id = Reader.GetInt32("id");
                c.FullName = Reader.GetString("full_name");
                c.Street = Reader.GetString("street");
                c.PoBox = Reader.GetString("pobox");
                c.BirthDate = Reader.GetDateTime("birthdate");
                cits.Add(c);
            }
            Reader.Close();
            return cits;
        }
    }
}
