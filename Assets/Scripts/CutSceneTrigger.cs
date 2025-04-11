using UnityEngine;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public CutsceneManager cutsceneManager;

    public string triggeringTag = "Player";
    private bool hasTriggered = false;


    private void OnTriggerEnter(Collider other)
    {
          if (hasTriggered)
            return;
        // Check if the entering object is the player (if a tag is set)
        if (!string.IsNullOrEmpty(triggeringTag) && !other.CompareTag(triggeringTag))
        {
            return;
        }
        hasTriggered = true;

        if (cutsceneManager != null)
        {
            cutsceneManager.PlayCutscene();
        }
        else
        {
            Debug.LogWarning("CutsceneManager reference is not assigned.");
        }
    }
}
