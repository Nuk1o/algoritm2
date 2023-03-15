using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrayBlocks : MonoBehaviour
{
    public List<BlocksListClass> _listBlocks = new List<BlocksListClass>();
    public void testArr()
    {
        foreach (var VARIABLE in _listBlocks)
        {
            //Debug.Log($"Первый блок: {VARIABLE.block1}");
            //Debug.Log($"Второй блок: {VARIABLE.block2}");
            
            TMP_Text _tmpText1 = VARIABLE.block1.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
            TMP_Text _tmpText2 = VARIABLE.block2.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
            Debug.Log($"Алгоритм: {_tmpText1.text}");
            Debug.Log($"Алгоритм: {_tmpText2.text}");
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