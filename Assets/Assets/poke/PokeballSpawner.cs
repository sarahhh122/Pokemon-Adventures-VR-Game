using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeballSpawner : MonoBehaviour
{
    public GameObject pokeballPrefab;

    public Transform spawnPoint;

    private GameObject currentBall;

    public float lostHeightThreshold = -1f;

    public float spawnDelay = 0.5f;



    void Start()
    {
        SpawnBall();
    }
    void Update()
    {
        if (currentBall != null && currentBall.transform.position.y < lostHeightThreshold)
        {
            Destroy(currentBall);
            currentBall = null;
            Invoke(nameof(SpawnBall), spawnDelay);
        }
    }
    void SpawnBall()
    {
        if (pokeballPrefab == null || spawnPoint == null)
        {
            return;
        }

        currentBall = Instantiate(pokeballPrefab, spawnPoint.position, spawnPoint.rotation);
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = currentBall.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnBallReleased);
        }

    }

    void OnBallReleased(SelectExitEventArgs args)
    {
        if (currentBall != null)
        {
            currentBall.transform.SetParent(null);

            UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable = currentBall.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.selectExited.RemoveListener(OnBallReleased);
            }
            currentBall = null;
        }
        Invoke(nameof(SpawnBall), spawnDelay);
    }
}
