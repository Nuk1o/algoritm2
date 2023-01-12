using UnityEngine;
using core;
using TMPro;

public class Auth : MonoBehaviour
{
    [SerializeField] private GameObject _ui_auth;
    [SerializeField] private GameObject _ui_admin;
    [SerializeField] private GameObject _ui_teacher;
    [SerializeField] private GameObject _ui_student;
    [Space]
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;

    public void Enter_App()
    {
        core.Core _core = new Core();
        string password = _core.set_pass(_password.text);
        Debug.Log("Пароль при входе: "+password);
        string role = _core.enter_user_app(_login.text, password);
        switch (role)
        {
            case "admin":
                _ui_admin.SetActive(true);
                _ui_auth.SetActive(false);
                break;
            case "student":
                _ui_student.SetActive(true);
                _ui_auth.SetActive(false);
                break;
            case "teacher":
                _ui_teacher.SetActive(true);
                _ui_auth.SetActive(false);
                break;
        }
    }
}
