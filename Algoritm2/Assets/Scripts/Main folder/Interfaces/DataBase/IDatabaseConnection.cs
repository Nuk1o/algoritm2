using MySql.Data.MySqlClient;

interface IDatabaseConnection
{
    public MySqlConnection BD_con(string ds, string port, string usr, string pass, string db);
}