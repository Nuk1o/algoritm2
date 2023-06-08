using System;
using System.Text;
using UnityEngine;
using TMPro;
/*
 *  Скрипт авторизации
 *  Authorization script
 */
public class Auth : MonoBehaviour
{
    [SerializeField] private GameObject _ui_auth;
    [SerializeField] private GameObject _ui_admin;
    [SerializeField] private GameObject _ui_teacher;
    [SerializeField] private GameObject _ui_student;
    [SerializeField] private GameObject _wrongPass;
    [Space]
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;

    public void EnterApp()
    {
        var salt = new byte[] { 0x000, 0x001, 0x002, 0x003, 0x004, 0x005, 0x006, 0x007, 0x008, 0x009, 0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015 };
        var iv = new byte[] { 0x0016, 0x0017, 0x0018, 0x0019, 0x0020, 0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 0x0026, 0x0027, 0x0028, 0x0029, 0x0030, 0x0031 };
        
        IQueryDatabase queryDatabase = new BDbase();
        string password = _password.text;
        
        var encrypted = PassEncryption.Encrypt(Encoding.UTF8.GetBytes(_login.text), password, salt, iv);
        var decrypted = PassEncryption.Decrypt(encrypted, password, salt, iv);
            
        string login_s = Encoding.UTF8.GetString(decrypted);
        string pass_s = Convert.ToBase64String(encrypted);
        
       //Debug.Log("Пароль при входе: "+pass_s);
        string role = queryDatabase.EnterApp(login_s,pass_s);
        //Debug.Log($"Роль в авторизации {role}");
        if (role == null)
        {
            _wrongPass.SetActive(true);
        }
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
        SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
        PlayerPrefs.SetString("LoginUser",login_s);
        _safePlayerPrefs.Save("first","LoginUser");
    }
}
