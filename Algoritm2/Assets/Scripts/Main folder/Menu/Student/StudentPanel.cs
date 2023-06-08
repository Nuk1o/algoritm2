using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/*
 *  Скрипт панели студента
 *  Student panel script
 */
public class StudentPanel : MonoBehaviour
{
    [SerializeField] private Slider _theorySlider;
    [SerializeField] private Slider _pracSlider;
    private IQueryDatabase queryDatabase;
    private SafePlayerPrefs _safePlayerPrefs;
    private void Start()
    {
        _theorySlider.maxValue = 4;
        _pracSlider.maxValue = 10;
        queryDatabase = new BDbase();
        _safePlayerPrefs = new SafePlayerPrefs();
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateTable());
    }

    private void SelectData() //Вывод задания в таблицу
    {
        try
        {
            if (_safePlayerPrefs.HasBeenEdited("first", "LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));
                try
                {
                    int amoutTheory = Convert.ToInt32(queryDatabase.GetAmountTheory(idUser));
                    _theorySlider.value = amoutTheory;
                    
                    int amoutTask = Convert.ToInt32(queryDatabase.GetAmountTask(idUser));
                    _pracSlider.value = amoutTask;
                }
                catch
                {
                    Debug.Log("OnBecameVisible error studentPanel");
                }
            }
        }
        catch
        {
            Debug.Log("StudentPanel error");
        }
    }

    IEnumerator UpdateTable()
    {
        while (true)
        {
            SelectData();
            yield return new WaitForSeconds(5);
        }
    }
}
