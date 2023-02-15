using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineRenderCore : MonoBehaviour, IPointerClickHandler
{
    private static readonly LineRenderCore instance = new LineRenderCore();

    private List<GameObject> _blocks ;

    private void Start()
    {
        _blocks = new List<GameObject>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Нажал на кнопку: {eventData.pointerPress.name}");
        Debug.Log(eventData.pointerPress.gameObject.transform.parent.gameObject);
        GameObject _btn = eventData.pointerPress.gameObject.transform.parent.gameObject;
        _blocks.Add(_btn);
        Debug.Log(_blocks.Count);
    }
    public static LineRenderCore GetInstance()
    {
        return instance;
    }
}
