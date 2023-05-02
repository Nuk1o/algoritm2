using System;
using DataBase;
using UnityEngine;
using UnityEngine.UI;

public class StudentPanel : MonoBehaviour
{
    [SerializeField] private Slider _theorySlider;
    [SerializeField] private Slider _pracSlider;
    private BDbase _bDbase;
    private void Start()
    {
        _bDbase = new BDbase();
        _theorySlider.maxValue = 5;
        _pracSlider.maxValue = 5;
    }

    private void FixedUpdate()
    {
        SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
        if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
        {
            string loginUser = PlayerPrefs.GetString("LoginUser");
            int idUser = Convert.ToInt32(_bDbase.get_id_user(loginUser));
            try
            {
                int amout = Convert.ToInt32(_bDbase.get_amount_theory(idUser));
                _theorySlider.value = amout;
            }
            catch
            {
                Debug.Log("OnBecameVisible error studentPanel");
            }
        }
    }
}
