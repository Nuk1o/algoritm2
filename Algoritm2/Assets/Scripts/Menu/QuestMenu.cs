using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu_quest;//Меню с вопросом
    [SerializeField] private TMP_Text _quest_txt;//Текст вопроса на отобразившимся меню
    [SerializeField] private string _Enter_txt;//Введите текст вопроса
    [SerializeField] private Button _btn_cancle, _btn_ok;//Кнопки да и отмена
    [Space]
    [SerializeField] private GameObject _menu1;//Меню на котором мы находимся
    [SerializeField] private GameObject _menu2;//Меню которое нужно включить
    [Space]
    [SerializeField] private GameObject _table;

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
        _btn_ok.onClick.AddListener(delegate { Start_quest(_menu1,_menu2,_menu_quest); });
        _btn_cancle.onClick.AddListener(delegate { Close_quest(_menu_quest); });
    }

    private void Start_quest(GameObject _menu1,GameObject _menu2,GameObject _menu_quest)
    {
        _menu1.SetActive(false);
        _menu2.SetActive(true);
        _menu_quest.SetActive(false);
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
