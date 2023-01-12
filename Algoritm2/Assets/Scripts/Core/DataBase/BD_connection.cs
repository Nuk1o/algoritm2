using MySql.Data.MySqlClient;

namespace DataBase
{
    public class BD_connection
    {
        public static MySqlConnection BD_con(string ds, string port, string usr, string pass, string db)
        {
            string con_str = "Data Source =" + ds + ";port=" + port + ";user=" + usr + ";password=" + pass + ";database=" + db;
            MySqlConnection con = new MySqlConnection(con_str);
            return con;
        }
    }
}


