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
