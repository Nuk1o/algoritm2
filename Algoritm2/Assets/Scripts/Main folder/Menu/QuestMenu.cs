using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*
 *  Скрипт вызова вопросительного меню
 *  Question-menu call script
 */
public class QuestMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu_quest;
    [SerializeField] private TMP_Text _quest_txt;
    [SerializeField] private string _Enter_txt;
    [SerializeField] private Button _btn_cancle, _btn_ok;
    [Space]
    [SerializeField] private GameObject _menu1;
    [SerializeField] private GameObject _menu2;
    [Space]
    [SerializeField] private GameObject _table;
    [Space]
    [SerializeField] private bool _isDestroy;

    private void Start()
    {
        _menu_quest.SetActive(false);
    }

    public void quest()
    {
        _menu_quest.SetActive(true);
        _quest_txt.text = _Enter_txt;
        if (_table!=null)
        {
            _table.SetActive(false);
        }
        _btn_ok.onClick.AddListener(delegate { Start_quest(_menu1,_menu2,_menu_quest,_isDestroy); });
        _btn_cancle.onClick.AddListener(delegate { Close_quest(_menu_quest); });
    }

    private void Start_quest(GameObject _menu1,GameObject _menu2,GameObject _menu_quest,bool _isDestroy)
    {
        _menu1.SetActive(false);
        _menu2.SetActive(true);
        _menu_quest.SetActive(false);
        if (_isDestroy)
        {
            Destroy(_menu1);
        }
    }

    private void Close_quest(GameObject _menu_quest)
    {
        _menu_quest.SetActive(false);
        if (_table!=null)
        {
            _table.SetActive(true);
        }
    }
}
