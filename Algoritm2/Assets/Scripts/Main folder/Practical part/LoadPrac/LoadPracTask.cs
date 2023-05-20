using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LoadPracTask : MonoBehaviour
{
    [SerializeField] TMP_Text _logo;
    [SerializeField] TMP_Text _text;
    public void LoadTask()
    {
        IQueryDatabase queryDatabase = new BDbase();
        List<string> _listTasks= queryDatabase.GetPracTask();
        int _count = _listTasks.Count;
        int rnd = Random.Range(0, _count);
        string _nameTask = _listTasks[rnd];
        string _textTask = queryDatabase.GetPracTextTask(_nameTask);
        _logo.text = _nameTask;
        _text.text = _textTask;
    }
}
