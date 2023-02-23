using System.Collections.Generic;
using UnityEngine;

public class ArrayBlocks : MonoBehaviour
{
    public List<BlocksListClass> _listBlocks = new List<BlocksListClass>();
    public void testArr()
    {
        foreach (var VARIABLE in _listBlocks)
        {
            Debug.Log($"Первый блок: {VARIABLE.block1}");
            Debug.Log($"Второй блок: {VARIABLE.block2}");
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