using System;
using System.Collections.Generic;
using UnityEngine;
using DataBase;

namespace core
{
    public class Core : MonoBehaviour
    {
        internal void add_user_db(string login, string password, string role) //Добавление пользователя
        {
            BDbase bb = new BDbase();
            bb.add_user(login,password,role);
        }

        internal void add_teacher(string login)
        {
            BDbase _bDbase = new BDbase();
            int idUser = Convert.ToInt32(_bDbase.get_id_user(login));
            _bDbase.add_teacher(idUser,login);
        }
        
        internal void add_student(string login)
        {
            BDbase _bDbase = new BDbase();
            int idUser = Convert.ToInt32(_bDbase.get_id_user(login));
            _bDbase.add_student(idUser);
        }

        internal string enter_user_app(string login, string password) //Вход пользователя
        {
            BDbase bb = new BDbase();
            string role = bb.enter_app(login, password);
            return role;
        }

        internal List<string> users_admin_panel_login()
        {
            BDbase bb = new BDbase();
            return bb.users_login();
        }
        
        internal List<string> users_admin_panel_role()
        {
            BDbase bb = new BDbase();
            return bb.users_role();
        }

        internal List<string> name_task_panel_teach()
        {
            BDbase bb = new BDbase();
            return bb.name_task();
        }
        
        internal List<string> text_task_panel_teach()
        {
            BDbase bb = new BDbase();
            return bb.text_task();
        }
    }
}

