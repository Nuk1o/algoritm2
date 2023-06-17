using System.Collections.Generic;
using UnityEngine;

interface IBlockStorage
{
    public void SaveBlock(GameObject _block);
    public void RemoveBlock(GameObject _block);
    public List<GameObject> GetArray();
}