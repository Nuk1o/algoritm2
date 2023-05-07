using System;
using UnityEngine;
using UnityEngine.UI;

public class StudentPanel : MonoBehaviour
{
    [SerializeField] private Slider _theorySlider;
    [SerializeField] private Slider _pracSlider;
    private IQueryDatabase queryDatabase;
    private void Start()
    {
        _theorySlider.maxValue = 5;
        _pracSlider.maxValue = 5;
        queryDatabase = new BDbase();
    }

    private void FixedUpdate()
    {
        SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
        if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
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
}
