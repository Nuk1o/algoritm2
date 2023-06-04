using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Mathematics;

public class TeacherPanel : MonoBehaviour
{
    [SerializeField] private GameObject _row;
    [SerializeField] private GameObject _parent;
    private Component[] tmp_texts;

    private void OnEnable()
    {
        StartCoroutine(UpdateTableTask());
    }

    private void SelectTasks()
    {
        IQueryDatabase queryDatabase = new BDbase();

        List<string> _name_task_bd = new List<string>();
        _name_task_bd = queryDatabase.NameTask();
        int _count_R = _name_task_bd.Count;

        while (_count_R != 0)
        {
            GameObject _new_row = Instantiate(_row,Vector3.zero, quaternion.identity,_parent.transform);
            tmp_texts = _new_row.GetComponentsInChildren<TMP_Text>();
            _count_R--;
            GameObject _go1 = tmp_texts[0].gameObject;
            GameObject _go2 = tmp_texts[1].gameObject;
            TMP_Text _name = _go1.GetComponent<TMP_Text>();
            TMP_Text _text = _go2.GetComponent<TMP_Text>();
            _name.text = _name_task_bd[_count_R];
            _text.text = queryDatabase.GetPracTextTask(_name_task_bd[_count_R]);
            
        }
    }

    IEnumerator UpdateTableTask()
    {
        while (true)
        {
            if (_parent.transform.childCount>1)
            {
                for (int j = 1; j < _parent.transform.childCount; j++)
                {
                    Debug.Log(_parent.transform.GetChild(j));
                    Destroy(_parent.transform.GetChild(j).gameObject);
                }
            }
            SelectTasks();
            yield return new WaitForSeconds(2);
        }
    }
}
