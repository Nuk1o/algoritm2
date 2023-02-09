using UnityEngine;
using UnityEngine.EventSystems;

public class PointingBlock :MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject[] dots;
    PointingBlock(GameObject[] dots)
    {
        this.dots = dots;
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
