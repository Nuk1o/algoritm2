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
        InputTextTask _inputTextTask = new InputTextTask(_tmpInputField,_btn_ok,_btn_cancle);
        TextSaveTask _textSaveTask = new TextSaveTask(_tmpText);
        _inputTextTask.SaveInputText(_textSaveTask);
        _btn_ok.onClick.AddListener(delegate { CloseMenuTask();});
        _btn_cancle.onClick.AddListener(delegate { CloseMenuTask();});
    }

    private void CloseMenuTask()
    {
        _taskMenu.SetActive(false);
    }
}

class InputTextTask
{
    private TMP_InputField _tmpInputField;//Input Field
    private Button _buttonOk,_buttonCancel;//Buttons
    public TextSaveTask _TextSaveTask;

    public InputTextTask(TMP_InputField _inputField,Button _buttonOk1,Button _buttonCancel1)
    {
        _tmpInputField = _inputField;
        _buttonOk = _buttonOk1;
        _buttonCancel = _buttonCancel1;
        _buttonCancel.onClick.AddListener(delegate {  });
    }

    public void SaveInputText(TextSaveTask _TextSaveTask)
    {
        _tmpInputField.text = "";
        _buttonOk.onClick.AddListener(delegate { TextSaveButton(_TextSaveTask, _tmpInputField);});
    }

    private void TextSaveButton(TextSaveTask _TextSaveTask, TMP_InputField tmpInputField)
    {
        if (_TextSaveTask.TextBlock.text=="")
        {
            _TextSaveTask.TextBlock.text = tmpInputField.text;
        }
    }
}

class TextSaveTask
{
    public TMP_Text TextBlock;

    public TextSaveTask(TMP_Text textBlock)
    {
        TextBlock = textBlock;
        TextBlock.text = "";
    }
}
