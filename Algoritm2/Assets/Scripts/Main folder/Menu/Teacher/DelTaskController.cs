using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*
 *  Скрипт удаления задачи
 *  Task deletion script
 */
public class DelTaskController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _delDropdown;
    [SerializeField] private Button _buttonDel;
    [SerializeField] private GameObject _infoMenu;
    [Header("QuestMenu")]
    [SerializeField] private GameObject _questMenu;
    [SerializeField] private TMP_Text _textQuest;
    [SerializeField] private Button _okBtn;
    [SerializeField] private Button _noBtn;

    private void Start()
    {
        _buttonDel.onClick.AddListener(delegate { SettingsQuest(); });
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateList());
    }

    private void SettingsQuest()
    {
        _questMenu.SetActive(true);
        _textQuest.text = "Вы действительно хотите удалить задачу";
        _okBtn.onClick.AddListener(delegate { DelTask(); });
        _noBtn.onClick.AddListener(delegate { CloseQuestMenu(); });
    }

    private void CloseQuestMenu()
    {
        _questMenu.SetActive(false);
    }

    private void DelTask()
    {
        _questMenu.SetActive(false);
        IQueryDatabase queryDatabase = new BDbase();
        int val = _delDropdown.value;
        string name_task = _delDropdown.options[val].text;
        Debug.Log(name_task);
        var _query = queryDatabase.DeleteTask(name_task);
        if (_query == null)
        {
            _infoMenu.SetActive(true);
        }
    }

    private void SelectTasks()
    {
        IQueryDatabase queryDatabase = new BDbase();
        SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
        if (_safePlayerPrefs.HasBeenEdited("first", "LoginUser"))
        {
            string loginUser = PlayerPrefs.GetString("LoginUser");
            int _idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));
            int _idTeach = Convert.ToInt32(queryDatabase.GetIdTeacher(_idUser));
            try
            {
                List<string> _listTasks = queryDatabase.GetNameTextTeacher(_idTeach);
                foreach (var task in _listTasks)
                {
                    _delDropdown.options.Add(new TMP_Dropdown.OptionData(task));
                }
            }
            catch
            {
                Debug.Log("Error SelectTasks");
            }
        }
        
    }

    IEnumerator UpdateList()
    {
        while (true)
        {
            _delDropdown.options.Clear();
            SelectTasks();
            yield return new WaitForSeconds(2);
        }
    }
}
