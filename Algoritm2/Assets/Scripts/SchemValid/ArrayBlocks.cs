using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrayBlocks : MonoBehaviour
{
    [SerializeField] private GameObject _go1;
    [SerializeField] private GameObject _go2;
    [SerializeField] private GameObject _go3;
    [SerializeField] private GameObject _go4;
    private List<BlocksListClass> _listBlocks;
    
    private void Start()
    {
        _listBlocks = new List<BlocksListClass>()
        {
            new BlocksListClass(_go1,_go2)
        };
        BlocksListClass _blocksList = new BlocksListClass(_go3, _go4);
        Debug.Log(_listBlocks.Count);
        _listBlocks.Add(_blocksList);
        Debug.Log(_listBlocks.Count);
        foreach (var VARIABLE in _listBlocks)
        {
            Debug.Log(VARIABLE.block1);
            Debug.Log(VARIABLE.block2);
        }
    }
}

public class BlocksListClass
{
    public GameObject block1 { get; }
    public GameObject block2 { get; }

    public BlocksListClass(GameObject Fblock, GameObject Sblock)
    {
        block1 = Fblock;
        block2 = Sblock;
    }
}