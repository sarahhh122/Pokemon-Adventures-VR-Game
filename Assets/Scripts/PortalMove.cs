using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalMove: MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 1; 
    

     private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("hereee1");

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
    
}
