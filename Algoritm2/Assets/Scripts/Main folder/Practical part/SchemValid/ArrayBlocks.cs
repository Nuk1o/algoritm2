using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DataBase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrayBlocks : MonoBehaviour
{
    [SerializeField] private Button _buttonOk;
    [SerializeField] private TMP_Text _txtLogo;
    [SerializeField] private TMP_Text _txtTask;
    [SerializeField] private bool _isStudent;
    public List<BlocksListClass> _listBlocks = new List<BlocksListClass>();
    private List<string> _saveList = new List<string>();
    private bool _isSave = false;
    private void Update()
    {
        if (_isStudent)
        {
            _buttonOk.onClick.AddListener(delegate { CheckPracStudent(); });
        }
        else
        {
            _buttonOk.onClick.AddListener(delegate { saveAll(); });
        }
    }

    public void saveAll()
    {
        if (!_isSave)
        {
            _isSave = true;
            foreach (var VARIABLE in _listBlocks)
            {
                TMP_Text _tmpText1 = VARIABLE.block1.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                TMP_Text _tmpText2 = VARIABLE.block2.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                Debug.Log($"Алгоритм: {_tmpText1.text}");
                Debug.Log($"Алгоритм: {_tmpText2.text}");
                _saveList.Add(_tmpText1.text.ToLower().Trim());
                _saveList.Add(_tmpText2.text.ToLower().Trim());
            }
            string algoritm = "";
            foreach (var VARIABLE in _saveList)
            {
                Debug.Log("Save "+VARIABLE);
                algoritm += VARIABLE.ToString();
            }
            Debug.Log(_txtLogo.text);
            Debug.Log(_txtTask.text);
            SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
            BDbase _bDbase = new BDbase();
            if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idTeach = Convert.ToInt32(_bDbase.get_id_teach(loginUser));
                Debug.Log(algoritm);
                using SHA256 hash = SHA256.Create();
                string _hash = GetHash(hash, algoritm);
                Debug.Log(_hash);
                string logo = _txtLogo.text.Trim().ToLower();
                string textTask = _txtTask.text.Trim().ToLower();
                try
                {
                    _bDbase.add_task_teacher(idTeach, logo, textTask, _hash);
                }
                catch
                {
                    Debug.Log("Ошибка сверху");
                }
            }
        }
    }

    public void CheckPracStudent()
    {
        if (!_isSave)
        {
            _isSave = true;
            foreach (var VARIABLE in _listBlocks)
            {
                TMP_Text _tmpText1 = VARIABLE.block1.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                TMP_Text _tmpText2 = VARIABLE.block2.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                Debug.Log($"Алгоритм: {_tmpText1.text}");
                Debug.Log($"Алгоритм: {_tmpText2.text}");
                _saveList.Add(_tmpText1.text.ToLower().Trim());
                _saveList.Add(_tmpText2.text.ToLower().Trim());
            }
            string algoritm = "";
            foreach (var VARIABLE in _saveList)
            {
                Debug.Log("Save "+VARIABLE);
                algoritm += VARIABLE.ToString();
            }
            Debug.Log(_txtLogo.text);
            Debug.Log(_txtTask.text);
            SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
            BDbase _bDbase = new BDbase();
            
            Debug.Log("Проверил работу");
            
            //Получить результат задачи из бд и сравнить её с выполненым заданием студента
        }
    }
    private string GetHash(SHA256 hash, string input)
    {
        byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}

public class BlocksListClass
{
    public GameObject block1 { get; }
    public GameObject block2 { get; }

    public BlocksListClass(GameObject Fblock, GameObject Sblock)
    {
        block1 = Fblock;
        block2 = Sblock;
    }
}