using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverHealingPotion : MonoBehaviour
{

    public RawImage rawImageToShow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rawImageToShow != null)
        {
            rawImageToShow.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (rawImageToShow != null)
        {
            rawImageToShow.gameObject.SetActive(false);
        }
    }
}
