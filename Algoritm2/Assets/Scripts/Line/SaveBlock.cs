using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveBlock : MonoBehaviour
{
    public List<GameObject> ListGOParent = new List<GameObject>();

    public void LineCreate()
    {
        try
        {
            if (ListGOParent.Count%2==0)
            {
                GameObject _block1 = ListGOParent[^2];
                GameObject _block2 = ListGOParent[^1];
                GameObject _line = _block1.transform.GetChild(5).gameObject;
                LineRenderer _line1 = _line.GetComponent<LineRenderer>();
                LineRenderUpdate _lineRenderUpdate = _line.AddComponent<LineRenderUpdate>();
                _lineRenderUpdate.LineRenderUpdate1(_block1,_block2);
                _line1.startWidth = 0.05f;
                _line1.endWidth = 0.05f;
                _line1.positionCount = 2;
                Vector3 _pos1 = new Vector3(_block1.transform.position.x,_block1.transform.position.y,1);
                Vector3 _pos2 = new Vector3(_block2.transform.position.x,_block2.transform.position.y,1);
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
