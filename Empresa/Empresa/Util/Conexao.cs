using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class Conexao
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;

        //Construtor
        public Conexao()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "tds06n.mysql.dbaas.com.br";
            database = "tds06n";
            user = "tds06n";
            password = "tds06n@2401";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Executar SQL
        public int execute(String sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                return cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }

        //Executar Consulta
        public MySqlDataReader executeQuery(String sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                return cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           

        }
    }
}
