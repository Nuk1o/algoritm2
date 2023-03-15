using UnityEngine;

public class CheckInsertionBlock : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    private const int _offsetHeight = 893; 
    private const int _offsetWwidth = 895; 
    private void FixedUpdate()
    {
        CheckBlock();
    }

    private void CheckBlock()
    {
        if (_block.transform.position.y > _offsetHeight || _block.transform.position.x > _offsetWwidth ||
            _block.transform.position.y < -_offsetHeight || _block.transform.position.x < -_offsetWwidth)
        {
            _block.transform.position = Vector3.one;
        }
    }
}
