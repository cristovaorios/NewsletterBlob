using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Util
{
    public class ConnectionFactory
    {
        private static string host = "localhost";
        private static string user = "root";
        private static string password = "";
        private static string database = "db_blobnews";

        public static MySqlConnection Conexao()
        {
            MySqlConnection con = null;

            string strconexao = $"server={host};userid={user};password={password};database={database}";
            try
            {
                con = new MySqlConnection(strconexao);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return con;
        }
    }
}
