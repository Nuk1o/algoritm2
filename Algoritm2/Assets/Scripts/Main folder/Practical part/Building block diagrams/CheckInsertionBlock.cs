using UnityEngine;
public class CheckInsertionBlock : MonoBehaviour
{
    private const float _offsetHeightUp = 4; 
    private const float _offsetHeightDown = -4; 
    private const float _offsetWwidthLeft = -3.3f; 
    private const float _offsetWwidthRight = 3.3f; 
    private void FixedUpdate()
    {
        CheckBlock();
    }
    private void CheckBlock()
    {
        if (gameObject.transform.position.y > _offsetHeightUp||gameObject.transform.position.y < _offsetHeightDown||
            gameObject.transform.position.x > _offsetWwidthRight || gameObject.transform.position.x < _offsetWwidthLeft)
        {
            gameObject.transform.position = Vector3.one;
        }
    }
}
