using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PokemonHoverInfo : MonoBehaviour
{
    public GameObject infoPanel;
    
    public TextMeshProUGUI infoText;
    
    public string pokemonInfo = "Default Pokemon Info";
    
    public Color highlightColor = Color.yellow;
    
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;
    private Renderer[] renderers;
    private Color[] originalColors;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();


        renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
        
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
    if (infoPanel != null)
        infoPanel.SetActive(false);
    
    for (int i = 0; i < renderers.Length; i++)
    {
        if (renderers[i] != null)
            renderers[i].material.color = originalColors[i];
    }
}

}
