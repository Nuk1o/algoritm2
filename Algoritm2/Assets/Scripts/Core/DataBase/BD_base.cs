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
        public string login_user(string password)//����
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string com = string.Format("select role from a_users where password = '{0}'", password);
                cmd.CommandText = com;
                conn.Open();
                string role_bd = cmd.ExecuteScalar().ToString();
                conn.Close();
                Debug.Log(role_bd);
                return role_bd;
            }
            catch(Exception e)
            {
                Debug.Log(e);
                Debug.Log("������ �����");
            }
            return null;
        }


        public string login_usr(int id)//�����
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string com = string.Format("select login from a_users where id = '{0}'", id);
                cmd.CommandText = com;
                conn.Open();
                string login_str = cmd.ExecuteScalar().ToString();
                conn.Close();
                return login_str;
            }
            catch
            {
                Debug.Log("������");
            }
            return null;
        }

        public string role_usr(int id)//����
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string com = string.Format("select role from a_users where id = '{0}'", id);
                cmd.CommandText = com;
                conn.Open();
                string login_str = cmd.ExecuteScalar().ToString();
                conn.Close();
                return login_str;
            }
            catch
            {
                Debug.Log("������");
            }
            return null;
        }

        public int count_a_users()//���-�� �������������
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"select * from count_usr_view";
                conn.Open();
                cmd.ExecuteScalar();
                //Debug.Log("COUNT: "+cmd.ExecuteScalar());
                string count_usr = cmd.ExecuteScalar().ToString();
                conn.Close();
                int count_r = Convert.ToInt32(count_usr);
                return count_r;
            }
            catch
            {
                Debug.Log("������");
            }
            return 0;
        }

        public string role_usr_id(int id)//����
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                string com = string.Format("select role from a_users where id = '{0}'", id);
                cmd.CommandText = com;
                conn.Open();
                string login_str = cmd.ExecuteScalar().ToString();
                conn.Close();
                return login_str;
            }
            catch
            {
                Debug.Log("������");
            }
            return null;
        }


        public void registration_user(string login,string password)//����
        {
            try
            {
                MySqlConnection conn = BD_param.BD_con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into a_users(login,password,role) values(@lg,@pass,@role)";
                cmd.Parameters.AddWithValue("@lg",login);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", "student");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Debug.Log("������������ ���������������");
            }
            catch
            {
                Debug.Log("������ �����");
            }
        }
    }
}

