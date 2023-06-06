using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SaveBlock : MonoBehaviour
{
    [SerializeField] private ArrayBlocks _arrayBlocks;
    [SerializeField] private EdgeCollider2D _edgeCollider2D;
    public List<GameObject> ListGOParent = new List<GameObject>();
    public List<GameObject> ListGO = new List<GameObject>();
    private int idCollider = 0;
    public void LineCreate(GameObject _gameObject)
    {
        try
        {
            if (ListGOParent.Count%2==0)
            {
                GameObject _block1 = ListGOParent[^2];
                GameObject _block2 = ListGOParent[^1];
                GameObject _arrow1 = ListGO[^2];
                GameObject _arrow2 = ListGO[^1];
                GameObject _line = _block1.transform.GetChild(5).gameObject;
                LineCheck(_line,_block1,_block2,_arrow1,_arrow2);
            }
        }
        catch
        {
            
        }
    }

    public void RemoveGO(GameObject _block)
    {
        Debug.Log(_block);
        ListGOParent.Remove(_block);
    }

    private void LineCheck(GameObject _line, GameObject _block1, GameObject _block2, GameObject _arrow1, GameObject _arrow2)
    {
        try
        {
            LineRenderer _line1 = _line.GetComponent<LineRenderer>();
            LineRenderUpdate _lineRenderUpdate = _line.AddComponent<LineRenderUpdate>();
            _line1.startWidth = 0.05f;
            _line1.endWidth = 0.05f;
            
            Vector3 _posBlock1 = _block1.transform.position;
            Vector3 _posBlock2 = _block2.transform.position;
            Vector3 _posArrow1 = _arrow1.transform.position;
            Vector3 _posArrow2 = _arrow2.transform.position;

            if (_block1.gameObject.name == _block2.gameObject.name)
            {
                if ((_posArrow1.y < _posArrow2.y || _posArrow1.y > _posArrow2.y)&& _posArrow1.x == _posArrow2.x) //top down && down top
                {
                    float _blockOffset = BlockOffset(_block1);
                    LineCreate(_line1, 4,_blockOffset,_posBlock1,_posBlock2,_arrow1,_arrow2);
                }
                else if ((_posArrow1.x > _posArrow2.x || _posArrow1.x < _posArrow2.x)&& _posArrow1.y == _posArrow2.y) //right left && left right
                {
                    float _blockOffset = BlockOffset(_block1);
                    LineCreate(_line1,4,_blockOffset,_posBlock1,_posBlock2,_arrow1,_arrow2);
                }
            }
            else
            {
                LineCreate(_line1,4,0,_posBlock1,_posBlock2,_arrow1,_arrow2);
            }
            
            BlocksListClass _blocksList = new BlocksListClass(_block1, _block2);
            Debug.Log(_blocksList.block1);
            Debug.Log(_blocksList.block2);
            _arrayBlocks._listBlocks.Add(_blocksList);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void LineCreate(LineRenderer _line, int _lineCount, float _blockOffset, Vector3 _posBlock1, Vector3 _posBlock2, GameObject _arrow1, GameObject _arrow2)
    {
        Vector3 _pos1,_pos2,_pos3,_pos4 = Vector3.zero;
        Vector3 _posArrow1 = _arrow1.transform.position;
        Vector3 _posArrow2 = _arrow2.transform.position;
        _line.positionCount = _lineCount;

        LineRenderUpdate _lineRenderUpdate = _line.gameObject.GetComponent<LineRenderUpdate>(); 
        
        switch (_lineCount)
        {
            case 4:
                _pos1 = new Vector3(_posArrow1.x,_posArrow1.y,1);
                if (_posArrow1.x>=_posArrow2.x)
                {
                    _pos2 = new Vector3(_posArrow1.x + _blockOffset,_posArrow1.y,1);
                    _pos3 = new Vector3(_posArrow2.x + _blockOffset,_posArrow2.y,1);
                }
                else if (_posArrow1.y == _posArrow2.y)
                {
                    _pos2 = new Vector3(_posArrow1.x,_posArrow1.y + _blockOffset/2,1);
                    _pos3 = new Vector3(_posArrow2.x,_posArrow2.y + _blockOffset/2,1);
                }
                else
                {
                    _pos2 = new Vector3(_posArrow1.x - _blockOffset,_posArrow1.y,1);
                    _pos3 = new Vector3(_posArrow2.x - _blockOffset,_posArrow2.y,1);
                }
                
                if (_blockOffset == 0)
                {
                    if (_arrow1.name == "right"||_arrow1.name=="left"&&_arrow2.name=="right"||_arrow2.name=="left")
                    {
                        _pos2 = new Vector3((_posArrow1.x+_posArrow2.x)/2, _posArrow1.y,1);
                        _pos3 = new Vector3((_posArrow1.x+_posArrow2.x)/2 , _posArrow2.y,1);                        
                    }
                    else
                    {
                        _pos2 = new Vector3(_posArrow1.x, (_posArrow1.y + _posArrow2.y)/2,1);
                        _pos3 = new Vector3(_posArrow2.x, (_posArrow1.y + _posArrow2.y)/2,1);
                    }
                }
                
                _pos4 = new Vector3(_posArrow2.x,_posArrow2.y,1);
                
                _line.SetPosition(0,_pos1);
                _line.SetPosition(1,_pos2);
                _line.SetPosition(2,_pos3);
                _line.SetPosition(3,_pos4);

                EdgeCollider2D _newEdgeCollider2D = Instantiate(_edgeCollider2D, Vector3.zero,quaternion.identity);
                idCollider++;
                _newEdgeCollider2D.gameObject.name = $"EdgeCollider {idCollider}";
                if (gameObject.TryGetComponent(out iColliderStorage _colliderStorage))
                {
                    _colliderStorage.AddCollider(_newEdgeCollider2D);
                }
                
                _lineRenderUpdate.LineRenderUpdate1(_arrow1,_arrow2, _blockOffset,_newEdgeCollider2D);
                break;
            default:
                Debug.Log("LineCreate Error");
                break;
        }
    }

    public float BlockOffset(GameObject _block)
    {
        float _blockOffset = 0;
        switch (_block.tag)
        {
            case "DataBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "PreparationBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "PredefinedProccessBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "ProcessBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "DecisionBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "ConnectorBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            case "TerminatorBlock":
                _blockOffset = 1.2f;
                return _blockOffset;
            default:
                Debug.Log("BlockOffset Error");
                break;
        }
        return 0;
    }
}
