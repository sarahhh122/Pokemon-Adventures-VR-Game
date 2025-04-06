using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUiScene : MonoBehaviour
{
    public GameObject mainMenuPanel;   // main menu
    public GameObject aboutPanel;      // About panel
    public GameObject optionsPanel;      // Options panel

    private bool isMuted = false; 



    public void StartGame()
    {
        SceneManager.LoadScene("VRROOMSarah");
    }

    public void OpenAbout()
    {
        mainMenuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }
        public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
 public void ToggleSound()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
    }
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

     public void BackFromAbout()
    {
        aboutPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Call this method when the Quit button is clicked.
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game.");
    }
}
