using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalMove: MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 1; // Example index
    

     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hereee1");

        if (other.CompareTag("Player"))
        {
            Debug.Log("hereeee");
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
    
}
