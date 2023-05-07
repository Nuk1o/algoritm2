using MySql.Data.MySqlClient;

interface IDatabaseParameters
{
    public MySqlConnection BDConnnection();
}