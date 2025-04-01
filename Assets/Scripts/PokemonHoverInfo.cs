using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PokemonHoverInfo : MonoBehaviour
{
    [Tooltip("The Info Panel GameObject (a World Space Canvas)")]
    public GameObject infoPanel;
    
    [Tooltip("Text component on the Info Panel (TextMeshProUGUI)")]
    public TextMeshProUGUI infoText;
    
    [Tooltip("Information text for this Pokemon")]
    [TextArea]
    public string pokemonInfo = "Default Pokemon Info";
    
    [Tooltip("Color to highlight the Pokemon on hover")]
    public Color highlightColor = Color.yellow;
    
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;
    private Renderer[] renderers;
    private Color[] originalColors;

    void Awake()
    {
        // Get the XRGrabInteractable component, or add one if it doesn't exist.
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Optionally, disable selectability if you only want hover feedback:
        // interactable.selectMode = InteractableSelectMode.Disabled;

        // Get all renderers on this object and its children
        renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
        
        // Ensure the info panel is off by default
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    void OnEnable()
    {
        if (interactable != null)
        {
           void OnEnable()
{
    if (interactable != null)
    {
        interactable.hoverEntered.AddListener(OnHoverEntered);
        interactable.hoverExited.AddListener(OnHoverExited);
        Debug.Log($"{gameObject.name} subscribed to hover events.");
    }
}

        }
    }

    void OnDisable()
    {
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnHoverEntered);
            interactable.hoverExited.RemoveListener(OnHoverExited);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
{
    Debug.Log($"{gameObject.name} hover entered by {args.interactorObject}");
    if (infoPanel != null)
    {
        infoPanel.SetActive(true);
        if (infoText != null)
            infoText.text = pokemonInfo;
    }
    
    for (int i = 0; i < renderers.Length; i++)
    {
        if (renderers[i] != null)
            renderers[i].material.color = highlightColor;
    }
}

private void OnHoverExited(HoverExitEventArgs args)
{
    Debug.Log($"{gameObject.name} hover exited by {args.interactorObject}");
    if (infoPanel != null)
        infoPanel.SetActive(false);
    
    for (int i = 0; i < renderers.Length; i++)
    {
        if (renderers[i] != null)
            renderers[i].material.color = originalColors[i];
    }
}

}
