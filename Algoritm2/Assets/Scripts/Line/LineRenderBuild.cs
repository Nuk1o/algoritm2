using UnityEngine;

public class LineRenderBuild : MonoBehaviour
{
    [SerializeField] private SaveBlock _saveBlock;
    public void AddToArray(GameObject _gameObject)
    {
        _saveBlock.ListGOParent.Add(gameObject.transform.parent.gameObject);
        _saveBlock.ListGO.Add(_gameObject);
        Debug.Log(gameObject.transform.parent.gameObject);
        Debug.Log(_saveBlock.ListGOParent.Count);
        Debug.Log($"До переноса: {_gameObject.name}");
        _saveBlock.LineCreate(_gameObject);
    }
}
