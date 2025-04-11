using UnityEngine;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{    
    public GameObject videoQuad;  // Your quad for the cutscene; it should be disabled by default.

    public VideoPlayer videoPlayer;  // VideoPlayer set to play your cutscene.

   
    public GameObject leftController;

    public GameObject rightController;


    // Call this method to start the cutscene
    public void PlayCutscene()
    {
        // Disable VR controllers to prevent input during the cutscene.
        if (leftController != null) leftController.SetActive(false);
        if (rightController != null) rightController.SetActive(false);

        // Enable the video quad.
        if (videoQuad != null) videoQuad.SetActive(true);

        // Start playing the video.
        if (videoPlayer != null)
        {
            videoPlayer.isLooping = false;

            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Play();

            
        }
    }

    // Called when the VideoPlayer finishes playing.
    private void OnVideoFinished(VideoPlayer vp)
    {
        EndCutscene();
    }

    // End the cutscene and re-enable VR controllers.
    public void EndCutscene()
    {

        // Stop the video.
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.loopPointReached -= OnVideoFinished;  // Remove event
        }
        

        // Disable the video quad.
        if (videoQuad != null) videoQuad.SetActive(false);

        // Re-enable VR controllers.
        if (leftController != null) leftController.SetActive(true);
        if (rightController != null) rightController.SetActive(true);
    }
}
