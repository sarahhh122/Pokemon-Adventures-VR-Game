using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class hoverScripttt : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel; 

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable; 
    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        if (infoPanel != null)
            infoPanel.SetActive(false); // 🔒 Hide the panel initially
        else
            Debug.LogError("Please assign the infoPanel GameObject! 🥺");
    }

    private void OnEnable()
    {
        // 🔔 Subscribe to hover events
        interactable.hoverEntered.AddListener(ShowPanel);
        interactable.hoverExited.AddListener(HidePanel);
    }

    private void OnDisable()
    {
        // 🔕 Unsubscribe to avoid memory leaks
        interactable.hoverEntered.RemoveListener(ShowPanel);
        interactable.hoverExited.RemoveListener(HidePanel);
    }

    private void ShowPanel(HoverEnterEventArgs args)
    {
        infoPanel.SetActive(true); // 🌟 Show info panel when hover starts
    }

    private void HidePanel(HoverExitEventArgs args)
    {
        infoPanel.SetActive(false); // 🌙 Hide info panel when hover ends
    }
}
