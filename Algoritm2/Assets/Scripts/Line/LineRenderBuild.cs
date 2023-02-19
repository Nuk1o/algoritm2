using UnityEngine;

public class LineRenderBuild : MonoBehaviour
{
    private SaveBlock _saveBlock = new SaveBlock();
    public void AddToArray(SaveBlock _refSaveBlock)
    {
        _saveBlock = _refSaveBlock;
        _saveBlock.ListGOParent.Add(gameObject.transform.parent.gameObject);
        Debug.Log(gameObject.transform.parent.gameObject);
        Debug.Log(_saveBlock.ListGOParent.Count);
        _saveBlock.LineCreate();
    }
}
