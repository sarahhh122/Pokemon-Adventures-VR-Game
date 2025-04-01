using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
public class cubeHover : MonoBehaviour
{

    // Assign the panel GameObject in the Inspector.
    public GameObject panel;

    // Called when the pointer (or VR ray) enters this object's collider.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (panel != null)
        {
            panel.SetActive(false);
            Debug.Log("Hover Enter: Panel deactivated.");
        }
    }

    // Called when the pointer (or VR ray) exits this object's collider.
    public void OnPointerExit(PointerEventData eventData)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            Debug.Log("Hover Exit: Panel activated.");
        }
    }
}
