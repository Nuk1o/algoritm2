using UnityEngine;

public class LineRenderBuild : MonoBehaviour
{
    [SerializeField] private SaveBlock _saveBlock;
    public void AddToArray(GameObject _gameObject)
    {
        _saveBlock.ListGOParent.Add(gameObject.transform.parent.gameObject);
        _saveBlock.ListGO.Add(_gameObject);
        _saveBlock.LineCreate(_gameObject);
    }
}
