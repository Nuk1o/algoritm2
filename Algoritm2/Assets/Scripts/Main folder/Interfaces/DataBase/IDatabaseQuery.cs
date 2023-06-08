using System.Collections.Generic;
/*
 *  Интерфейс методов запросов к базе данных
 *  Interface of database query methods
 */
interface IDatabaseQuery
{
    public object QueryBD(string query);
    public List<string> ListQuery(string query);
    public string StrQuery(string query);
}