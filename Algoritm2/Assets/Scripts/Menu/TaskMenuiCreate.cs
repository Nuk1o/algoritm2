using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskMenuiCreate : MonoBehaviour
{
    [SerializeField] private GameObject _taskMenu;
    [SerializeField] private TMP_InputField _tmpInputField;
    [SerializeField] private Button _btn_cancle, _btn_ok;

    private void Start()
    {
        _taskMenu.SetActive(false);
    }

    public void OpenTaskMenu(TMP_Text _tmpText)
    {
        _taskMenu.SetActive(true);
        _tmpInputField.text = "";
        _btn_ok.onClick.AddListener(delegate { this.SaveText(_tmpText,_tmpInputField,_taskMenu); });
        _btn_cancle.onClick.AddListener(delegate { this.CloseMenu(_taskMenu); });
    }

    private void SaveText(TMP_Text _text,TMP_InputField _inputField,GameObject _menu)
    {
        _text.text = _inputField.text;
        _menu.SetActive(false);
    }

    private void CloseMenu(GameObject _menu)
    {
        _menu.SetActive(false);
    }
}
