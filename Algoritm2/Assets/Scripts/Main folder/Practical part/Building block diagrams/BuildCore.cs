using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 *  Скрипт построение блок-схемы
 *  Block diagram construction script
 */
public class BuildCore : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _textBlock;
    [SerializeField] private GameObject _inputField;
    [SerializeField] private SaveBlock _saveBlock;
    
    private RectTransform _rectTransform;
    private Vector3 _startBlockPosition;
    private bool _spawnBlock = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startBlockPosition = _rectTransform.gameObject.transform.position;
        Debug.Log($"Начальная позиция: {_startBlockPosition}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.clickCount == 2 && eventData.button == PointerEventData.InputButton.Left)
        {
            EneterTextBlock eneterTextBlock = new EneterTextBlock(_textBlock);
            InputTextBlock inputTextBlock = new InputTextBlock(_inputField);
            inputTextBlock.SaveInputText(eneterTextBlock);
        }
        if (eventData.button == PointerEventData.InputButton.Right&&_spawnBlock)
        {
            try
            {
                _saveBlock.RemoveGO(gameObject);
                Destroy(gameObject);
            }
            catch
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!_spawnBlock)
        {
            Instantiate(gameObject, _startBlockPosition, quaternion.identity, _parent.transform);
            gameObject.AddComponent<PointingBlock>();
        }
        _spawnBlock = true;
        gameObject.AddComponent<CheckInsertionBlock>();
    }
}

class InputTextBlock
{
    public GameObject InputFieldTable;
    private GameObject _BGInputFieldTable;
    private TMP_Text _textLogoTable;
    private TMP_InputField _tmpInputField;
    private Button _buttonOk;
    public EneterTextBlock EneterTextBlock;

    public InputTextBlock(GameObject inputFieldTable)
    {
        InputFieldTable = inputFieldTable;
        InputFieldTable.SetActive(true);
        _BGInputFieldTable = InputFieldTable.transform.GetChild(0).gameObject;
        _textLogoTable = _BGInputFieldTable.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        _tmpInputField = _BGInputFieldTable.transform.GetChild(3).gameObject.GetComponent<TMP_InputField>();
        _buttonOk = _BGInputFieldTable.transform.GetChild(2).gameObject.GetComponent<Button>();
    }

    public void SaveInputText(EneterTextBlock eneterTextBlock)
    {
        _tmpInputField.text = "";
        Debug.Log("Ввод текста в блок");
        _buttonOk.onClick.AddListener(delegate { TextSaveButton(eneterTextBlock, _tmpInputField);});
    }

    private void TextSaveButton(EneterTextBlock eneterTextBlock, TMP_InputField tmpInputField)
    {
        if (eneterTextBlock.TextBlock.text=="")
        {
            eneterTextBlock.TextBlock.text = tmpInputField.text;
            Debug.Log("Save TXT " +eneterTextBlock.TextBlock.text);
            InputFieldTable.SetActive(false);            
        }
    }
}

class EneterTextBlock
{
    public TMP_Text TextBlock;

    public EneterTextBlock(TMP_Text textBlock)
    {
        TextBlock = textBlock;
        textBlock.gameObject.SetActive(true);
        TextBlock.text = "";
    }
}