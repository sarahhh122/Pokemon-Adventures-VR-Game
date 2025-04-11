using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class cantGrab : MonoBehaviour
{

    public InteractionLayerMask hoverLayer = InteractionLayerMask.GetMask("HoverOnly");
    public InteractionLayerMask grabLayer = InteractionLayerMask.GetMask(); // empty mask

    UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.interactionLayers = hoverLayer | grabLayer;
    }
}