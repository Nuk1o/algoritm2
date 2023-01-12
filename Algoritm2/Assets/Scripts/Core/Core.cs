using System;
using System.IO;
using UnityEngine;
using DataBase;
using Rijndael256;

namespace core
{
    public class Core : MonoBehaviour
    {
        /*
         * Ядро программы
         */

        private void Start()
        {
            BD_base bb = new BD_base();
            bb.test_con();
            Debug.Log(set_pass("root"));
        }
        
        // Rijndael256
        public string set_pass(string plaintext)
        {
            string password = Environment.GetEnvironmentVariable("API_KEY_Rijndael");//Ключ шифрования
            // Шифрование данной строки
            string ciphertext = Rijndael.Encrypt(plaintext, password, KeySize.Aes256);
            return ciphertext;
        }

        public string get_pass(string ciphertext)
        {
            string password = Environment.GetEnvironmentVariable("API_KEY_Rijndael");//Ключ шифрования
            // Расшифровка строки
            string plaintext = Rijndael.Decrypt(ciphertext, password, KeySize.Aes256);
            return plaintext;
        }


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
                Debug.Log("Пароль в ядре: "+password);
                string role = bb.enter_app(login, password);
                return role;
            }
            catch
            {
                Debug.Log("Ошибка входа пользователя в Core");
            }

            return null;
        }
    }
}

