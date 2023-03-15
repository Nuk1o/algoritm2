using UnityEngine;
using UnityEngine.EventSystems;

public class PointingBlock :MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject[] dots = new GameObject [4];

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            dots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var dot in dots)
        {
            dot.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var dot in dots)
        {
            dot.SetActive(false);
        }
    }
}
