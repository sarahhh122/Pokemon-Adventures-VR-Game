using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverHealingPotion : MonoBehaviour
{

    public RawImage rawImageToShow;

    // When the pointer hovers over the object
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rawImageToShow != null)
        {
            rawImageToShow.gameObject.SetActive(true);
        }
    }

    // When the pointer exits the object
    public void OnPointerExit(PointerEventData eventData)
    {
        if (rawImageToShow != null)
        {
            rawImageToShow.gameObject.SetActive(false);
        }
    }
}
