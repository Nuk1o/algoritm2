using System;
using UnityEngine;

public class LineRenderUpdate : MonoBehaviour
{
    private GameObject _block1, _block2;
    private LineRenderer _line;

    public void LineRenderUpdate1(GameObject _firstBlock,GameObject _secondBlock)
    {
        Debug.Log(_firstBlock);
        Debug.Log(_secondBlock);
        _block1 = _firstBlock;
        _block2 = _secondBlock;
        _line = _block1.GetComponent<LineRenderer>();
    }
    
    private void FixedUpdate()
    {
        // if (_block1 != null || _block2 != null)
        // {
        //     _line.SetPosition(0,new Vector3(_block1.transform.position.x,_block1.transform.position.y,1));
        //     _line.SetPosition(1,new Vector3(_block2.transform.position.x,_block2.transform.position.y,1));
        // }
    }
}
