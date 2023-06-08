using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
/*
 *  Unit тесты
 *  Unit tests
 */
public class TestProgramm
{
    [Test]
    public void AuthorizationTest()//Тест авторизации
    {
        var salt = new byte[] { 0x000, 0x001, 0x002, 0x003, 0x004, 0x005, 0x006, 0x007, 0x008, 0x009, 0x0010, 0x0011, 0x0012, 0x0013, 0x0014, 0x0015 };
        var iv = new byte[] { 0x0016, 0x0017, 0x0018, 0x0019, 0x0020, 0x0021, 0x0022, 0x0023, 0x0024, 0x0025, 0x0026, 0x0027, 0x0028, 0x0029, 0x0030, 0x0031 };
        
        IQueryDatabase queryDatabase = new BDbase();
        string _login = "Teach";
        string _password = "teach";
        var encrypted = PassEncryption.Encrypt(Encoding.UTF8.GetBytes(_login), _password, salt, iv);
        var decrypted = PassEncryption.Decrypt(encrypted, _password, salt, iv);
        string login_s = Encoding.UTF8.GetString(decrypted);
        string pass_s = Convert.ToBase64String(encrypted);
        string role = queryDatabase.EnterApp(login_s,pass_s);
        if (role == null)
        {
            Debug.Log("Wrong Password");
        }
        switch (role)
        {
            case "admin":
                Debug.Log("Open admin window");
                break;
            case "student":
                Debug.Log("Open student window");
                break;
            case "teacher":
                Debug.Log("Open teacher window");
                break;
        }
    }

    [Test]
    public void StudentWindowTest()//Тест окна студента
    {
        IQueryDatabase queryDatabase = new BDbase();
        string loginUser = "Student";
        int idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));
        try
        {
            int amoutTheory = Convert.ToInt32(queryDatabase.GetAmountTheory(idUser));
            int amoutTask = Convert.ToInt32(queryDatabase.GetAmountTask(idUser));
            Assert.Pass($"Успешно {amoutTheory}, {amoutTask}");
        }
        catch
        {
            Debug.Log("OnBecameVisible error studentPanel");
        }
    }
}
