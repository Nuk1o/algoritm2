using MySql.Data.MySqlClient;
using System;
using System.IO;
using UnityEngine;

public class BDparam : IDatabaseParameters
{
    public MySqlConnection BDConnnection()
    {
        var dotenv = Path.Combine(Application.dataPath, "root.env");
        DotEnv.Load(dotenv);
        string ds = Environment.GetEnvironmentVariable("DATAS");
        string port = Environment.GetEnvironmentVariable("PORT");
        string usr = Environment.GetEnvironmentVariable("USR");
        string pass = Environment.GetEnvironmentVariable("PASS");
        string db = Environment.GetEnvironmentVariable("DB");
        IDatabaseConnection databaseConnection = new BDconnection();
        MySqlConnection mySqlConnection = databaseConnection.BD_con(ds, port, usr, pass, db);
        return mySqlConnection;
    }
}


