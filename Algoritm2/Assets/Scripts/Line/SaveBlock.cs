using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveBlock : MonoBehaviour
{
    public List<GameObject> ListGOParent = new List<GameObject>();
    public List<GameObject> ListGO = new List<GameObject>();

    public void LineCreate(GameObject _gameObject)
    {
        Debug.Log($"После переноса: {_gameObject.name}");
        try
        {
            if (ListGOParent.Count%2==0)
            {
                GameObject _block1 = ListGOParent[^2];
                GameObject _block2 = ListGOParent[^1];
                GameObject _arrow1 = ListGO[^2];
                GameObject _arrow2 = ListGO[^1];
                GameObject _line = _block1.transform.GetChild(5).gameObject;
                LineRenderer _line1 = _line.GetComponent<LineRenderer>();
                LineRenderUpdate _lineRenderUpdate = _line.AddComponent<LineRenderUpdate>();
                _lineRenderUpdate.LineRenderUpdate1(_arrow1,_arrow2);
                _line1.startWidth = 0.05f;
                _line1.endWidth = 0.05f;
                _line1.positionCount = 2;
                Vector3 _pos1 = new Vector3(_arrow1.transform.position.x,_arrow1.transform.position.y,1);
                Vector3 _pos2 = new Vector3(_arrow2.transform.position.x,_arrow2.transform.position.y,1);
                _line1.SetPosition(0,_pos1);
                _line1.SetPosition(1,_pos2);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void removeGO(GameObject _block)
    {
        Debug.Log(_block);
        ListGOParent.Remove(_block);
    }
}
