using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrayBlocks : MonoBehaviour
{
    [SerializeField] private Button _buttonOk;
    [SerializeField] private TMP_Text _txtLogo;
    [SerializeField] private TMP_Text _txtTask;
    [SerializeField] private bool _isStudent;
    [SerializeField] private TMP_Text _txtResult;
    public List<BlocksListClass> _listBlocks = new List<BlocksListClass>();
    private List<string> _saveList = new List<string>();
    private bool _isSave = false;
    private TMP_Text _tmpText1;
    private TMP_Text _tmpText2;
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
                _tmpText1 = VARIABLE.block1.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                _tmpText2 = VARIABLE.block2.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
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
            IQueryDatabase queryDatabase = new BDbase();
            if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idTeach = Convert.ToInt32(queryDatabase.GetIdTeach(loginUser));                
                Debug.Log(algoritm);
                using SHA256 hash = SHA256.Create();
                string _hash = GetHash(hash, algoritm);
                Debug.Log(_hash);
                string logo = _txtLogo.text.Trim().ToLower();
                string textTask = _txtTask.text.Trim().ToLower();
                try
                {
                    queryDatabase.AddTaskTeacher(idTeach, logo, textTask, _hash);
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
                _tmpText1 = VARIABLE.block1.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                _tmpText2 = VARIABLE.block2.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
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
            Debug.Log("Проверил работу");
            IQueryDatabase queryDatabase = new BDbase();
            using SHA256 hash = SHA256.Create();
            string _hash = GetHash(hash, algoritm);
            Debug.Log(_hash);
            try
            {
                string algoritmPrac = queryDatabase.GetAlgoritmPrac(_txtLogo.text);
                Debug.Log(algoritmPrac);
                if (_txtResult != null)
                {
                    if (_hash == algoritmPrac)
                    {
                        _txtResult.text = "Верно";
                        _txtResult.color = Color.green;
                    }
                    else
                    {
                        _txtResult.text = "Неверно";
                        _txtResult.color = Color.red;
                    }
                }
            }
            catch
            {
                Debug.Log("Ошибка алгоритма возможно пустой");
            }
            
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