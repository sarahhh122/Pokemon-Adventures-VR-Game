using UnityEngine;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{    
    public GameObject videoQuad;  // Quad 

    public VideoPlayer videoPlayer;  // VideoPlayer

   
    public GameObject leftController;

    public GameObject rightController;


    // Call this method to start the cutscene
    public void PlayCutscene()
    {
        // Disable VR controllers :))
        if (leftController != null) leftController.SetActive(false);
        if (rightController != null) rightController.SetActive(false);

        // Enable the video quad.
        if (videoQuad != null) videoQuad.SetActive(true);

        // play the video.
        if (videoPlayer != null)
        {
            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Play();

            
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        EndCutscene();
    }

    // End the cutscene and enable VR controllers.
    public void EndCutscene()
    {

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.loopPointReached -= OnVideoFinished;  // Remove event
        }
        

        // Disable the video 
        if (videoQuad != null) videoQuad.SetActive(false);

        // enable VR controllers.
        if (leftController != null) leftController.SetActive(true);
        if (rightController != null) rightController.SetActive(true);
    }
}
