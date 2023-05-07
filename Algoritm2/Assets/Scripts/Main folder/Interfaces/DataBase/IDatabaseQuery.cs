using System.Collections.Generic;

interface IDatabaseQuery
{
    public object QueryBD(string query);
    public List<string> ListQuery(string query);
    public string StrQuery(string query);
}