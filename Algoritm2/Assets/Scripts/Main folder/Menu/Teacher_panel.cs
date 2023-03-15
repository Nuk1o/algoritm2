using System.Collections.Generic;
using TMPro;
using UnityEngine;
using core;
using Unity.Mathematics;

public class Teacher_panel : MonoBehaviour
{
    [SerializeField] private GameObject _row;
    [SerializeField] private GameObject _parent;
    private Component[] tmp_texts;

    private void Start()
    {
        core.Core _core = new Core();
        
        List<string> _name_task_bd = new List<string>();
        List<string> _text_task_bd = new List<string>();

        _name_task_bd = _core.name_task_panel_teach();
        _text_task_bd = _core.text_task_panel_teach();

        Debug.Log(_name_task_bd[0]);
        Debug.Log(_text_task_bd[0]);
        
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
            _text.text = _text_task_bd[_count_R];
        }
    }
}
