using MySql.Data.MySqlClient;
using UnityEngine;
using System;

namespace DataBase
{ 
    public class BD_base
    {
        public void test_con()
        {
            MySqlConnection conn = BD_param.BD_con();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            Debug.Log("Подключились "+conn.Database);
            Debug.Log(conn.State);
            conn.Close();
        }

        internal void add_user(string login,string password,string role)
        {
            MySqlConnection con = BD_param.BD_con();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @$"call create_user_db('{login}','{password}','{role}')";
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Debug.Log("Ошибка добавления пользователя BD_base");
            }
            con.Close();
        }

        internal string enter_app(string login, string password)
        {
            try
            {
                MySqlConnection con = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @$"call enter_app_db('{login}','{password}')";
                con.Open();
                var role = cmd.ExecuteScalar();
                string role_r = role.ToString();
                Debug.Log(role_r);
                con.Close();
                return role_r;
            }
            catch
            {
                Debug.Log("Ошибка получения роли");
            }

            return null;
        }
    }
}

