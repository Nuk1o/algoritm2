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
         * Скрипт для работы с бд а так же для дальнейших манипуляций
         */

        private void Start()
        {
            BD_base bb = new BD_base();
            bb.test_con();
        }
        
        // Rijndael256
        public string set_pass(string plaintext)
        {
            string password = Environment.GetEnvironmentVariable("API_KEY_Rijndael");//Ключ шифрования
            // Шифрование данной строки
            string ciphertext = Rijndael.Encrypt(plaintext, password, KeySize.Aes256);
            Debug.Log(ciphertext);

            // Расшифровка строки
            //plaintext = Rijndael.Decrypt(ciphertext, password, KeySize.Aes256);
            return ciphertext;
        }

        public string get_pass(string ciphertext)
        {
            string password = Environment.GetEnvironmentVariable("API_KEY_Rijndael");//Ключ шифрования
            // Расшифровка строки
            string plaintext = Rijndael.Decrypt(ciphertext, password, KeySize.Aes256);
            return plaintext;
        }
    }
}

