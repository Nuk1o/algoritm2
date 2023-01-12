using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core;
using TMPro;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_Dropdown _role;

    public void add_user()
    {
        try
        {
            core.Core _core = new Core();
            string login_user = _login.text;
            string password_user = _core.set_pass(_password.text);
            string role = "student";
            if (_role.value == 0)
            {
                role = "teacher";
                _core.add_user_db(login_user,password_user,role);
            }
            else
            {
                _core.add_user_db(login_user,password_user,role);
            }
        }
        catch
        {
            Debug.Log("Ошибка в добавлении пользователя!");
        }
        
    }
}
