using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class RemoteExperimentControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text messageText;
    public VideoPlayer videoPlayer;
    public GameObject canvas;
    public Beeper beeper;
    public float experimentStartDelay = 3f;
    private static int currentVideo = 1;
    private UserInput userInput;
    private string videoPath;
    private string[] videoNames = {"video_1.mp4", "video_2.mp4", "video_3.mp4", "video_4.mp4", "video_5.mp4"};
    private bool awaitingUserResponse = false;
    private float timeToHideCursor;

    void Awake()
    {
        videoPlayer.loopPointReached += endOfVideoReached;

        userInput = new UserInput();

        userInput.ExperimentControls.Quit.performed += _ => Application.Quit();
        userInput.ExperimentControls.PauseVideo.performed += _ => Pause();
        userInput.ExperimentControls.RestartVideo.performed += _ => RestartCurrentVideo();
        userInput.ExperimentControls.ShowMouseCursor.performed += _ => ShowMouseCursor();

        userInput.UserResponse.LowBeep.performed += _ => LowBeepUserResponse();
        userInput.UserResponse.HighBeep.performed += _ => HighBeepUserResponse();

        beeper.onBeep = BeepTriggered;

        timeToHideCursor = Time.realtimeSinceStartup + 3;

    }

    void OnEnable()
    {
        userInput.ExperimentControls.Enable();
        userInput.UserResponse.Enable();
    }

    void OnDisable()
    {
        userInput.ExperimentControls.Disable();
        userInput.UserResponse.Disable();
    }

    void ShowMouseCursor()
    {
        Cursor.visible = true;
        timeToHideCursor = Time.realtimeSinceStartup + 3;
    }

    void Update()
    {
        if(Cursor.visible && Time.realtimeSinceStartup > timeToHideCursor)
        {
            Cursor.visible = false;
        }
    }


    public void BeginExperiment()
    {     
        if(!InitialiseLogFile())
        {
            return;
        }
        foreach (string videoName in videoNames)
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), videoName)))
            {
                return;
            }
        }
        //video files exist and log files was successfully initialised, now we can start coroutine
        // StartCoroutine(StartVideoSequenceAfterDelay());
        PlayNextVideo();
    }

    bool InitialiseLogFile()
    {
        if(!DataLogger.Instance.SetFileName("Results.txt"))
        {
            DisplayMessage("Problem opening experiment save file");
            return false;
        }
        else
        {
            DataLogger.Instance.WriteToFile("Date and Time:" + DateTime.Now);
        }
        return true;
    }

    // IEnumerator StartVideoSequenceAfterDelay()
    // {        
        // DisplayMessage("Video will begin shortly.");

        // yield return new WaitForSecondsRealtime(experimentStartDelay);

        // PlayNextVideo();
        // StartVideoSequence();
    // }

    public void PlayNextVideo()
    {
        // currentVideo = 1;
        Debug.Log("video number: " + currentVideo);
        string videoName = "video_" + currentVideo + ".mp4";
        string url = Path.Combine(Directory.GetCurrentDirectory(), videoName);
        
        PlayVideo(url);       
    }

    void PlayVideo(string url)
    {
        if(!File.Exists(url))
        {
            DisplayMessage("File not found: " + url);
            return;
        }

        DataLogger.Instance.WriteToFile("Playing: " + url);
        Debug.Log("Playing: " + url);

        canvas.SetActive(false);

        videoPlayer.url = url;
        videoPlayer.Play();

        beeper.StartBeeping();
    }

    void endOfVideoReached (VideoPlayer source)
    {
        beeper.StopBeeping();
        Debug.Log("video_" + currentVideo + ".mp4 finished.");
        DataLogger.Instance.WriteToFile("video_" + currentVideo + ".mp4 finished.");
        currentVideo += 1;
        if(currentVideo > 5)
        {
            EndExperiment();
        }
        else
        {
            Debug.Log("Next video in line is: " + "video_" + currentVideo + ".mp4");
            SceneManager.LoadScene(2);
            // canvas.SetActive(true);
            // DisplayMessage("");
        }
    }

    void Pause()
    {
        if(videoPlayer.isPaused)
        {
            videoPlayer.Play();
            beeper.StartBeeping();
        }
        else
        {
            videoPlayer.Pause();
            beeper.StopBeeping();
            DataLogger.Instance.WriteToFile("Video Paused");
        }
    }

    void RestartCurrentVideo()
    {
        videoPlayer.Stop();
        beeper.StopBeeping();
        videoPlayer.Play();
        beeper.StartBeeping();

        DataLogger.Instance.WriteToFile("Video Restarting");
    }

    private void BeepTriggered()
    {
        Debug.Log("BeepTriggered");

        if(awaitingUserResponse && beeper.previousBeepState != Beeper.BeepState.None)
        {
            LogResult(beeper.previousBeepState, false, -1, videoPlayer.time);
        }

        awaitingUserResponse = true;
    }

    public void LowBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - beeper.GetLastBeepTime();

        Beeper.BeepState beepState = beeper.beepState;


        if(beepState == Beeper.BeepState.None || awaitingUserResponse == false)
        {
            return;
        }

        if(beepState == Beeper.BeepState.Low)
        {
            LogResult(beepState, true, responseDelay, videoPlayer.time);
        } 
        else
        {
            LogResult(beepState, false, responseDelay, videoPlayer.time);
        }

        beepState = Beeper.BeepState.None;

        awaitingUserResponse = false;

    }

    public void HighBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - beeper.GetLastBeepTime();

        Beeper.BeepState beepState = beeper.beepState;

        if(beepState == Beeper.BeepState.None || awaitingUserResponse == false)
        {
            return;
        }

        if(beepState == Beeper.BeepState.High)
        {
            LogResult(beepState, true, responseDelay, videoPlayer.time);
        } 
        else
        {
            LogResult(beepState, false, responseDelay, videoPlayer.time);
        }

        beepState = Beeper.BeepState.None;

        awaitingUserResponse = false;

        
    }

    void LogResult(Beeper.BeepState type, bool correct, float responseDelay, double videoTime)
    {
        Debug.Log(type.ToString() + ", " + correct + ", " + responseDelay + ", " + videoTime);
        
        DataLogger.Instance.WriteToFile(type.ToString() + ", " + correct + ", " + responseDelay + ", " + videoTime);
    }


    void DisplayMessage(string message)
    {
        canvas.SetActive(true);
        messageText.text = message;
    }

    void EndExperiment()
    {
        DataLogger.Instance.CloseLogFile();
        SceneManager.LoadScene(3);
        // DisplayMessage("");
    }


    public void GoToTutorial()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToVideo2()
    {
        SceneManager.LoadScene(2);
    }

}
