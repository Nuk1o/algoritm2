using UnityEngine;
using DataBase;
using System.Collections.Generic;
using TMPro;

public class LoadPracTask : MonoBehaviour
{
    private BDbase bDbase;
    [SerializeField] TMP_Text _logo;
    [SerializeField] TMP_Text _text;
    private void Start()
    {
        bDbase = new BDbase();
    }

    public void LoadTask()
    {
        bDbase = new BDbase();
        List<string> _listTasks=bDbase.get_prac_task();

        int _count = _listTasks.Count;

        string _nameTask = _listTasks[1];
        string _textTask = bDbase.get_prac_text_task(_nameTask); //Текст задачи

        _logo.text = _nameTask;
        _text.text = _textTask;

        /*foreach(var val in _listTasks)
        {
            Debug.Log(val);
            string _query = bDbase.get_prac_text_task(val);
            string _algoritm = bDbase.get_algoritm_prac(val);
            Debug.Log(_query);
            Debug.Log(_algoritm);
        }*/


    }
}
