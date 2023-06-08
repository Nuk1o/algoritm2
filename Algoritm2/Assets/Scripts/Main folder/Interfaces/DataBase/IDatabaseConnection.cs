using MySql.Data.MySqlClient;
/*
 *  Интерфейс подключения к базе данных
 *  Database connection interface
 */
interface IDatabaseConnection
{
    public MySqlConnection BD_con(string ds, string port, string usr, string pass, string db);
}