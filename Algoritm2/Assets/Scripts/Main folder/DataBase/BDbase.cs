using System;
using MySql.Data.MySqlClient;
using UnityEngine;
using System.Collections.Generic;

namespace DataBase
{
    public class BDbase
    {
        internal void add_user(string login, string password, string role)
        {
            try
            {
                DatabaseQuery databaseQuery = new DatabaseQuery();
                object queryBD = databaseQuery.QueryBD($"call create_user_db('{login}','{password}','{role}')");
                Debug.Log(queryBD);
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
                DatabaseQuery databaseQuery = new DatabaseQuery();
                object queryBD = databaseQuery.QueryBD($"call enter_app_db('{login}','{password}')");
                Debug.Log(queryBD);
                return queryBD.ToString();
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
                List<string> _list = new List<string>();
                DatabaseQuery databaseQuery = new DatabaseQuery();
                _list = databaseQuery.ListQuery("select * from select_logins_from_users");
                return _list;
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
                List<string> _list = new List<string>();
                DatabaseQuery databaseQuery = new DatabaseQuery();
                _list = databaseQuery.ListQuery("select * from select_role_from_users");
                return _list;
            }
            catch
            {
                Debug.Log("Ошибка list role, base");
            }
            return null;
        }

        internal List<string> name_task()
        {
            try
            {
                List<string> _list = new List<string>();
                DatabaseQuery databaseQuery = new DatabaseQuery();
                _list = databaseQuery.ListQuery("select name_task from select_name_task_text_task_from_task");
                return _list;
            }
            catch
            {
                Debug.Log("Ошибка name task, base");
            }
            return null;
        }

        internal List<string> text_task()
        {
            try
            {
                List<string> _list = new List<string>();
                DatabaseQuery databaseQuery = new DatabaseQuery();
                _list = databaseQuery.ListQuery("select text_task from select_name_task_text_task_from_task");
                return _list;
            }
            catch
            {
                Debug.Log("Ошибка text task, base");
            }
            return null;
        }

        internal string student_add_amount_task(int idUser, int amout)
        {
            try
            {
                DatabaseQuery databaseQuery = new DatabaseQuery();
                object queryBD = databaseQuery.QueryBD($"add_amount_task_student('{idUser}','{amout}')");
                Debug.Log(queryBD);
            }
            catch
            {
                Debug.Log("Ошибка student_add_amount_task");
            }

            return null;
        }
        internal List<string> get_id_user(string login)
        {
            try
            {
                List<string> _list = new List<string>();
                DatabaseQuery databaseQuery = new DatabaseQuery();
                _list = databaseQuery.ListQuery($"Call get_id_user('{login}')");
                return _list;
            }
            catch
            {
                Debug.Log("Ошибка get_id_user");
            }
            return null;
        }

        internal string get_amount_theory(int idUser)
        {
            try
            {
                DatabaseQuery databaseQuery = new DatabaseQuery();
                string query = databaseQuery.strQuery($"Call get_amount_theory('{idUser}')");
                return query;
            }
            catch
            {
                Debug.Log("Ошибка get_amount_theory");
            }

            return null;
        }

    }

    public class DatabaseQuery
    {
        public object QueryBD(string query)
        {
            MySqlConnection con = BDparam.BD_con();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            if (query!="")
            {
                cmd.CommandText = query;
                con.Open();
                object DataFromBD = cmd.ExecuteScalar();
                con.Close();
                if (DataFromBD != null)
                {
                    return DataFromBD;
                }
            }
            else
            {
                con.Open();
                Debug.Log("Подключились " + con.Database);
                Debug.Log(con.State);
                con.Close();
            }
            return null;
        }

        public List<string> ListQuery(string query)
        {
            List<string> _list = new List<string>();
            MySqlConnection con = BDparam.BD_con();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    _list.Add(reader.GetString(0));
                    i++;
                }
            }
            con.Close();
            Debug.Log(_list.Count);
            return _list;
        }

        public string strQuery(string query)
        {
            MySqlConnection con = BDparam.BD_con();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            con.Open();
            object objStr = cmd.ExecuteScalar();
            con.Close();
            Debug.Log(objStr.ToString());
            return objStr.ToString();
        }
    }
}
