using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockStorage : MonoBehaviour, IBlockStorage
{
    private List<GameObject> _arrayBlocks;

    private void Awake()
    {
        _arrayBlocks = new List<GameObject>();
    }

    public void SaveBlock(GameObject _block)
    {
        try
        {
            _arrayBlocks.Add(_block);
            Debug.Log(_arrayBlocks.Count);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void RemoveBlock(GameObject _block)
    {
        try
        {
            _arrayBlocks.Remove(_block);
            Debug.Log(_arrayBlocks.Count);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public List<GameObject> GetArray()
    {
        return _arrayBlocks;
    }
}

