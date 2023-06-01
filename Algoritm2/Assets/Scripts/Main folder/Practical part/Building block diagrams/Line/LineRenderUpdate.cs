using UnityEngine;

public class LineRenderUpdate : MonoBehaviour
{
    private LineRenderer _line;
    private EdgeCollider2D _edgeCollider2D;
    private bool _redyUpdate = false;
    private Vector3 _pos1,_pos2,_pos3,_pos4 = Vector3.zero;
    private Vector3 _posArrow1, _posArrow2;
    private int _countPoints;

    private GameObject _arrow1GO, _arrow2GO;
    private float _blockOffsetNew;


    SaveBlock _saveBlock;

    public void LineRenderUpdate1(GameObject _arrow1, GameObject _arrow2, int _count, float _blockOffset)
    {
        _arrow1GO = _arrow1;
        _arrow2GO = _arrow2;
        _blockOffsetNew = _blockOffset;
        _countPoints = _count;
        _redyUpdate = true;
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
                switch (_countPoints)
                {
                    case 4:
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
                            // if (_arrow1GO.name == "right"||_arrow1GO.name=="left"&&_arrow2GO.name=="right"||_arrow2GO.name=="left")
                            // {
                            //     _pos2 = new Vector3((_posArrow1.x+_posArrow2.x)/2, _posArrow1.y,1);
                            //     _pos3 = new Vector3((_posArrow1.x+_posArrow2.x)/2 , _posArrow2.y,1);                        
                            // }
                            // else
                            // {
                            //     _pos2 = new Vector3(_posArrow1.x, (_posArrow1.y + _posArrow2.y)/2,1);
                            //     _pos3 = new Vector3(_posArrow2.x, (_posArrow1.y + _posArrow2.y)/2,1);
                            // }
                            _pos2 = new Vector3(_posArrow1.x, _posArrow2.y,1);
                            _pos3 = new Vector3(_posArrow1.x, _posArrow2.y,1);
                        }
                        _pos4 = new Vector3(_posArrow2.x,_posArrow2.y,1);
                        _line.SetPosition(0,_pos1);
                        _line.SetPosition(1,_pos2);
                        _line.SetPosition(2,_pos3);
                        _line.SetPosition(3,_pos4);
                        break;
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
