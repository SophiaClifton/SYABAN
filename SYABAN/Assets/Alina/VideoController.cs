using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad;

    private void Start()
    {
        // Make sure the VideoPlayer component is assigned to the script's videoPlayer variable.
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Register a method to be called when the video finishes playing.
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the specified scene when the video ends.
        SceneManager.LoadScene(sceneToLoad);
    }
}
