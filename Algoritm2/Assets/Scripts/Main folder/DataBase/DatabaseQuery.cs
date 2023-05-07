using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseQuery : IDatabaseQuery
{
    public List<string> ListQuery(string query)
    {
        List<string> _list = new List<string>();
        IDatabaseParameters databaseConnection = new BDparam();
        MySqlConnection mySqlConnection = databaseConnection.BDConnnection();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = mySqlConnection;
        cmd.CommandText = query;
        mySqlConnection.Open();
        using (var reader = cmd.ExecuteReader())
        {
            int i = 0;
            while (reader.Read())
            {
                _list.Add(reader.GetString(0));
                i++;
            }
        }
        mySqlConnection.Close();
        Debug.Log(_list.Count);
        return _list;
    }

    public object QueryBD(string query)
    {
        IDatabaseParameters databaseConnection = new BDparam();
        MySqlConnection mySqlConnection = databaseConnection.BDConnnection();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = mySqlConnection;
        if (query != "")
        {
            cmd.CommandText = query;
            mySqlConnection.Open();
            object DataFromBD = cmd.ExecuteScalar();
            mySqlConnection.Close();
            if (DataFromBD != null)
            {
                return DataFromBD;
            }
        }
        else
        {
            mySqlConnection.Open();
            Debug.Log("Подключились " + mySqlConnection.Database);
            Debug.Log(mySqlConnection.State);
            mySqlConnection.Close();
        }
        return null;
    }

    public string StrQuery(string query)
    {
        IDatabaseParameters databaseConnection = new BDparam();
        MySqlConnection mySqlConnection = databaseConnection.BDConnnection();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = mySqlConnection;
        cmd.CommandText = query;
        mySqlConnection.Open();
        object objStr = cmd.ExecuteScalar();
        mySqlConnection.Close();
        Debug.Log(objStr.ToString());
        return objStr.ToString();
    }
}
