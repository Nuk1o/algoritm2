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
            bb.add_user(login,password,role);
        }

        internal string enter_user_app(string login, string password) //Вход пользователя
        {
            BD_base bb = new BD_base();
            string role = bb.enter_app(login, password);
            return role;
        }

        internal List<string> users_admin_panel_login()
        {
            BD_base bb = new BD_base();
            return bb.users_login();
        }
        
        internal List<string> users_admin_panel_role()
        {
            BD_base bb = new BD_base();
            return bb.users_role();
        }

        internal List<string> name_task_panel_teach()
        {
            BD_base bb = new BD_base();
            return bb.name_task();
        }
        
        internal List<string> text_task_panel_teach()
        {
            BD_base bb = new BD_base();
            return bb.text_task();
        }
    }
}

