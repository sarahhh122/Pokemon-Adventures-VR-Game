using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
public class cubeHover : MonoBehaviour
{

    public GameObject panel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (panel != null)
        {
            panel.SetActive(false);
           // Debug.Log("Hover Enter.");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            // Debug.Log("Hover Exit");
        }
    }
}
