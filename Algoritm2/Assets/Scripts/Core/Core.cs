using System.Collections.Generic;
using UnityEngine;
using DataBase;

namespace core
{
    public class Core : MonoBehaviour
    {
        internal void add_user_db(string login, string password, string role) //Добавление пользователя
        {
            BD_base bb = new BD_base();
            try
            {
                bb.add_user(login,password,role);
            }
            catch
            {
                Debug.Log("Ошибка добавления пользователя в Core");
            }
        }

        internal string enter_user_app(string login, string password) //Вход пользователя
        {
            BD_base bb = new BD_base();
            try
            {
                string role = bb.enter_app(login, password);
                return role;
            }
            catch
            {
                Debug.Log("Ошибка входа пользователя в Core");
            }
            return null;
        }

        internal List<string> users_admin_panel_login()
        {
            BD_base bb = new BD_base();
            try
            {
                return bb.users_login();
            }
            catch
            {
                Debug.Log("Ошибка вывода пользователей в админ панель Core");
            }
            return null;
        }
        
        internal List<string> users_admin_panel_role()
        {
            BD_base bb = new BD_base();
            try
            {
                return bb.users_role();
            }
            catch
            {
                Debug.Log("Ошибка вывода ролей в админ панель Core");
            }
            return null;
        }

        internal List<string> name_task_panel_teach()
        {
            BD_base bb = new BD_base();
            try
            {
                return bb.name_task();
            }
            catch
            {
                Debug.Log("Ошибка вывода названия задания Core");
            }
            return null;
        }
        
        internal List<string> text_task_panel_teach()
        {
            BD_base bb = new BD_base();
            try
            {
                return bb.text_task();
            }
            catch
            {
                Debug.Log("Ошибка вывода текста задания Core");
            }
            return null;
        }
    }
}

