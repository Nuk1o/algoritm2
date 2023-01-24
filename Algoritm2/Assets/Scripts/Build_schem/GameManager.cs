using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject _buildingToPlace;
    [SerializeField] private CustomCursor _cursor;
    [SerializeField] private GameObject _parent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _buildingToPlace != null)
        {
            Instantiate(_buildingToPlace, _cursor.transform.position, Quaternion.identity,_parent.transform);
            _buildingToPlace = null;
            _cursor.gameObject.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void ConstructionBuilding(GameObject building)
    {
        _cursor.gameObject.SetActive(true);
        _cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
        _buildingToPlace = building;
        Cursor.visible = false;
    }
}
