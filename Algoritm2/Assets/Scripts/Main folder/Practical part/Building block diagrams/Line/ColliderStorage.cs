using System.Collections.Generic;
using UnityEngine;
/*
 *  Скрипт хранение коллайдера
 *  Collider storage script
 */
public class ColliderStorage : MonoBehaviour, iColliderStorage
{
    private List<EdgeCollider2D> _edgeCollider2Ds;

    private void Start()
    {
        _edgeCollider2Ds = new List<EdgeCollider2D>();
    }

    public void AddCollider(EdgeCollider2D _edgeCollider2D)
    {
        _edgeCollider2Ds.Add(_edgeCollider2D);
    }

    public void DelAllCollider()
    {
        try
        {
            Debug.Log(_edgeCollider2Ds.Count);
            if (_edgeCollider2Ds.Count>0)
            {
                foreach (var collider in _edgeCollider2Ds)
                {
                    Destroy(collider.gameObject);
                }
            }
        }
        catch
        {
            
        }
    }
}

interface iColliderStorage
{
    public void AddCollider(EdgeCollider2D _edgeCollider2D);
    public void DelAllCollider();
}