using System;
using System.IO;
using UnityEngine;
using DataBase;

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
}
