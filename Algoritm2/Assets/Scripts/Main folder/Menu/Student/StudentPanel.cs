using System;
using UnityEngine;
using UnityEngine.UI;

public class StudentPanel : MonoBehaviour
{
    [SerializeField] private Slider _theorySlider;
    [SerializeField] private Slider _pracSlider;
    private IQueryDatabase queryDatabase;
    private SafePlayerPrefs _safePlayerPrefs;
    private void Start()
    {
        _theorySlider.maxValue = 5;
        _pracSlider.maxValue = 5;
        queryDatabase = new BDbase();
        _safePlayerPrefs = new SafePlayerPrefs();
    }

    private void FixedUpdate()
    {
        try
        {
            if (_safePlayerPrefs.HasBeenEdited("first", "LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));
                try
                {
                    int amout = Convert.ToInt32(queryDatabase.GetAmountTheory(idUser));
                    _theorySlider.value = amout;
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
}
