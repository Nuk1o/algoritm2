using MySql.Data.MySqlClient;
using UnityEngine;
using System;
using System.Collections.Generic;

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
            try
            {
                MySqlConnection con = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @$"call create_user_db('{login}','{password}','{role}')";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch 
            {
                Debug.Log("Ошибка добавления пользователя BD_base");
            }
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

        internal List<string> users_login()
        {
            try
            {
                List<string> _login_list = new List<string>();
                MySqlConnection con = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from select_logins_from_users";
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        _login_list.Add(reader.GetString(0));
                        i++;
                    }
                }
                con.Close();
                Debug.Log(_login_list.Count);
                return _login_list;
            }
            catch
            {
                Debug.Log("Ошибка list login, base");
            }
            return null;
        }
        
        internal List<string> users_role()
        {
            try
            {
                List<string> _login_list = new List<string>();
                MySqlConnection con = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from select_role_from_users";
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        _login_list.Add(reader.GetString(0));
                        i++;
                    }
                }
                con.Close();
                Debug.Log(_login_list.Count);
                return _login_list;
            }
            catch
            {
                Debug.Log("Ошибка list role, base");
            }
            return null;
        }
    }
}
