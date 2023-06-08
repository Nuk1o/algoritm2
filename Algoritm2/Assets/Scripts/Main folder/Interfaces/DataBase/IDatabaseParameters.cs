using MySql.Data.MySqlClient;
/*
 *  Интерфейс параметров базы данных
 *  Database parameters interface
 */
interface IDatabaseParameters
{
    public MySqlConnection BDConnnection();
}