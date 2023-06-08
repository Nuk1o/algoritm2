using System;
using System.Text;
using UnityEngine;
using TMPro;
/*
 *  Скрипт регистрации
 *  Registration script
 */
public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField _login;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_Dropdown _role;

    public void add_user()
    {
        try
        {
            var salt = new byte[] { 0x000, 0x001, 0x002, 0x003, 0x004, 0x005, 0x006, 0x007, 0x008, 0x009, 0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015 };
            var iv = new byte[] { 0x0016, 0x0017, 0x0018, 0x0019, 0x0020, 0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 0x0026, 0x0027, 0x0028, 0x0029, 0x0030, 0x0031 };

            IQueryDatabase queryDatabase = new BDbase();
            string login_user = _login.text;
            string password_user = _password.text;
            var encrypted = PassEncryption.Encrypt(Encoding.UTF8.GetBytes(login_user), password_user, salt, iv);
            var decrypted = PassEncryption.Decrypt(encrypted, password_user, salt, iv);
            
            string login_s = Encoding.UTF8.GetString(decrypted);
            string pass_s = Convert.ToBase64String(encrypted);
            
            
            string role = "student";
            if (_role.value == 0)
            {
                role = "teacher";
                queryDatabase.AddUser(login_s,pass_s,role);
                int idUser = Convert.ToInt32(queryDatabase.GetIdUser(login_s));
                queryDatabase.AddTeacher(idUser,login_s);
            }
            else
            {
                queryDatabase.AddUser(login_s, pass_s, role);
                int idUser = Convert.ToInt32(queryDatabase.GetIdUser(login_s));
                queryDatabase.AddStudent(idUser);
            }
        }
        catch
        {
            Debug.Log("Ошибка в добавлении пользователя!");
        }
    }
}
