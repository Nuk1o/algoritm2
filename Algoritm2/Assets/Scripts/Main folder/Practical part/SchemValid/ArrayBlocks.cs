using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*
 *  Сохранение массива блоков
 *  Saving an array of blocks
 */
public class ArrayBlocks : MonoBehaviour
{
    [SerializeField] private Button _buttonOk;
    [SerializeField] private TMP_Text _txtLogo;
    [SerializeField] private TMP_Text _txtTask;
    [SerializeField] private bool _isStudent;
    [SerializeField] private TMP_Text _txtResult;
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

            if (gameObject.transform.TryGetComponent(out BlockStorage _blockStorage))
            {
                foreach (var gameObjectBlock in _blockStorage.GetArray())
                {
                    _tmpText1 = gameObjectBlock.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                    _saveList.Add(_tmpText1.text.ToLower().Trim());
                    Debug.Log($"TEXT BLOCK: {_tmpText1.text}");
                }
            }
            string algoritm = "";
            foreach (var VARIABLE in _saveList)
            {
                algoritm += VARIABLE.ToString();
            }
            Debug.Log(algoritm);
            SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
            IQueryDatabase queryDatabase = new BDbase();
            if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idTeach = Convert.ToInt32(queryDatabase.GetIdTeach(loginUser));                
                Debug.Log(algoritm);
                using SHA256 hash = SHA256.Create();
                string _hash = GetHash(hash, algoritm);
                string logo = _txtLogo.text.Trim().ToLower();
                string textTask = _txtTask.text.Trim().ToLower();
                logo = logo.Replace(" ", "_");
                textTask = textTask.Replace(" ", "_");
                try
                {
                    queryDatabase.AddTaskTeacher(idTeach, logo, textTask, _hash);
                }
                catch
                {
                    Debug.Log("saveAll error");
                }
            }
            if (gameObject.TryGetComponent(out iColliderStorage _colliderStorage))
            {
                _colliderStorage.DelAllCollider();
            }
        }
    }

    public void CheckPracStudent()
    {
        if (!_isSave)
        {
            _isSave = true;            
            
            if (gameObject.transform.TryGetComponent(out BlockStorage _blockStorage))
            {
                Debug.Log("TRUE"+_blockStorage.GetArray().Count);
                
                foreach (var gameObjectBlock in _blockStorage.GetArray())
                {
                    Debug.Log(gameObjectBlock.transform.childCount);
                    _tmpText1 = gameObjectBlock.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
                    _saveList.Add(_tmpText1.text.ToLower().Trim());
                    Debug.Log($"TEXT BLOCK: {_tmpText1.text}");
                }
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
            Debug.Log($"ALGORITM TEXT {algoritm}");
            IQueryDatabase queryDatabase = new BDbase();
            using SHA256 hash = SHA256.Create();
            string _hash = GetHash(hash, algoritm);
            Debug.Log(_hash);
            try
            {
                string logoText = _txtLogo.text;
                logoText = logoText.Replace(" ", "_");
                string algoritmPrac = queryDatabase.GetAlgoritmPrac(logoText);
                Debug.Log(algoritmPrac);
                if (_txtResult != null)
                {
                    if (_hash == algoritmPrac)
                    {
                        _txtResult.text = "Верно";
                        _txtResult.color = Color.green;
                        if (_safePlayerPrefs.HasBeenEdited("first", "LoginUser"))
                        {
                            string loginUser = PlayerPrefs.GetString("LoginUser");
                            int idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));
                            int amount = Convert.ToInt32(queryDatabase.GetAmountTask(idUser));
                            queryDatabase.StudentAddAmountTask(idUser, amount + 1);
                        }
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
            if (gameObject.TryGetComponent(out iColliderStorage _colliderStorage))
            {
                _colliderStorage.DelAllCollider();
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