using MySql.Data.MySqlClient;
using System;
using System.IO;
using UnityEngine;

namespace DataBase
{
    public class BD_param
    {
        public static MySqlConnection BD_con()
        {
            var dotenv = Path.Combine(Application.dataPath, "root.env");
            DotEnv.Load(dotenv);
            string ds = Environment.GetEnvironmentVariable("DATAS");
            string port = Environment.GetEnvironmentVariable("PORT");
            string usr = Environment.GetEnvironmentVariable("USR");
            string pass = Environment.GetEnvironmentVariable("PASS");
            string db = Environment.GetEnvironmentVariable("DB");
            return BD_connection.BD_con(ds,port,usr,pass,db);
        }
    }
}


