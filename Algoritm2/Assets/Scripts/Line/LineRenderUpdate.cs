using System;
using UnityEngine;
using UnityEngine.UI;

public class LineRenderUpdate : MonoBehaviour
{
    private GameObject _block1, _block2;
    private LineRenderer _line;
    private bool _redyUpdate = false;
    
    SaveBlock _saveBlock;

    public void LineRenderUpdate1(GameObject _firstBlock,GameObject _secondBlock)
    {
        Debug.Log(_firstBlock);
        Debug.Log(_secondBlock);
        gameObject.AddComponent<Button>();
        _block1 = _firstBlock;
        _block2 = _secondBlock;
        _redyUpdate = true;
    }

    private void FixedUpdate()
    {
        if (_redyUpdate)
        {
            try
            {
                _line = GetComponent<LineRenderer>();
                if (_block1 != null || _block2 != null)
                {
                    _line.SetPosition(0,new Vector3(_block1.transform.position.x,_block1.transform.position.y,1));
                    _line.SetPosition(1,new Vector3(_block2.transform.position.x,_block2.transform.position.y,1));
                }
            }
            catch
            {
                _line.SetPosition(0,Vector3.zero);
                _line.SetPosition(1,Vector3.zero);
            }
            
        }
    }
}
