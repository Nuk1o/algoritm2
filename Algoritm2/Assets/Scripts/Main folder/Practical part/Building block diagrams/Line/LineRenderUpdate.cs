using System;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderUpdate : MonoBehaviour
{
    private LineRenderer _line;
    private EdgeCollider2D _edgeCollider2D;
    private bool _redyUpdate = false;
    private Vector3 _pos1,_pos2,_pos3,_pos4 = Vector3.zero;
    private Vector3 _posArrow1, _posArrow2;
    private GameObject _arrow1GO, _arrow2GO;

    private float _blockOffsetNew;

    SaveBlock _saveBlock;

    public void LineRenderUpdate1(GameObject _arrow1, GameObject _arrow2,float _blockOffset, EdgeCollider2D _newEdgeCollider2D)
    {
        _arrow1GO = _arrow1;
        _arrow2GO = _arrow2;
        _redyUpdate = true;
        _blockOffsetNew = _blockOffset;
        _edgeCollider2D = _newEdgeCollider2D;
        _line.positionCount = 4;
    }

    private void FixedUpdate()
    {
        if (_redyUpdate)
        {
            try
            {
                _line = GetComponent<LineRenderer>();
                _posArrow1= _arrow1GO.transform.position;
                _posArrow2 = _arrow2GO.transform.position;
                _pos1 = new Vector3(_posArrow1.x,_posArrow1.y,1);
                if (_posArrow1.x>=_posArrow2.x)
                {
                    _pos2 = new Vector3(_posArrow1.x + _blockOffsetNew,_posArrow1.y,1);
                    _pos3 = new Vector3(_posArrow2.x + _blockOffsetNew,_posArrow2.y,1);
                }
                else if (_posArrow1.y == _posArrow2.y)
                {
                    _pos2 = new Vector3(_posArrow1.x,_posArrow1.y + _blockOffsetNew/2,1);
                    _pos3 = new Vector3(_posArrow2.x,_posArrow2.y + _blockOffsetNew/2,1);
                }
                else
                {
                    _pos2 = new Vector3(_posArrow1.x - _blockOffsetNew,_posArrow1.y,1);
                    _pos3 = new Vector3(_posArrow2.x - _blockOffsetNew,_posArrow2.y,1);
                }
                
                if (_blockOffsetNew == 0)
                {
                    if ((_arrow1GO.name == "right"||_arrow1GO.name=="left")&&(_arrow2GO.name=="right"||_arrow2GO.name=="left"))
                    {
                        _pos2 = new Vector3((_posArrow1.x+_posArrow2.x)+1.5f, _posArrow1.y,1);
                        _pos3 = new Vector3((_posArrow1.x+_posArrow2.x)+1.5f , _posArrow2.y,1);                        
                    }
                    else
                    {
                        _pos2 = new Vector3(_posArrow1.x, (_posArrow1.y + _posArrow2.y)/2,1);
                        _pos3 = new Vector3(_posArrow2.x, (_posArrow1.y + _posArrow2.y)/2,1);
                    }
                }
                _pos4 = new Vector3(_posArrow2.x,_posArrow2.y,1);
                

                if (_arrow1GO.name == "right" || _arrow1GO.name == "left")
                {
                    if (_arrow2GO.name == "top")
                    {
                        _pos2 = new Vector3(_posArrow2.x, _posArrow1.y, 1);
                        _pos3 = new Vector3(_posArrow2.x, _posArrow1.y, 1);
                    }
                }
                else if (_arrow2GO.name == "right" || _arrow2GO.name == "left")
                {
                    if (_arrow1GO.name == "top")
                    {
                        _pos2 = new Vector3(_posArrow1.x, _posArrow2.y, 1);
                        _pos3 = new Vector3(_posArrow1.x, _posArrow2.y, 1);
                    }
                }
                else
                {
                    Vector3 _roundPos2 = _pos2;
                    Vector3 _roundPos3 = _pos3;
                    if (Equals(Math.Round(_roundPos2.x*5, 0),Math.Round(_roundPos3.x*5, 0)))
                    {
                        _pos2.x = _pos1.x;
                        _pos3.x = _pos1.x;
                        _pos4.x = _pos1.x;
                    }
                }
                
                _line.SetPosition(0,_pos1);
                _line.SetPosition(1,_pos2);
                _line.SetPosition(2,_pos3);
                _line.SetPosition(3,_pos4);
                
                List<Vector2> _vector2s = new List<Vector2>();
                _vector2s.Add(_pos1);
                _vector2s.Add(_pos2);
                _vector2s.Add(_pos3);
                _vector2s.Add(_pos4);
                _edgeCollider2D.points = _vector2s.ToArray();
            }
            catch
            {
                _line.SetPosition(0,Vector3.zero);
                _line.SetPosition(1,Vector3.zero);
                _edgeCollider2D.points[0] = Vector3.zero;
                _edgeCollider2D.points[1] = Vector3.zero;
            }
        }
    }

    private void Update()
    {
        DelLine();
    }

    private void DelLine()
    {
        try
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D _hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
                if (_hit2D.collider.gameObject.tag == "Line")
                {
                    Destroy(_edgeCollider2D);
                    _line.positionCount = 0;
                    Destroy(gameObject.GetComponent<LineRenderUpdate>());
                }
            }
        }
        catch 
        {
            
        }
        
    }
}
