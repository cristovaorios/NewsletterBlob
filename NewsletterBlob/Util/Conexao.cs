using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Util
{
    public class Conexao
    {
        private MySqlConnection _conn;
        public Conexao()
        {
            string strconexao = "server=localhost;userid=root;password=;database=db_blobnews";

            _conn = new MySqlConnection(strconexao);
            _conn.Open();
        }

        public MySqlConnection Conn { get => _conn; set => _conn = value; }
    }
}
