using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class ExperimentControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField experimentNumberInput;
    public TMP_Text messageText;
    public VideoPlayer videoPlayer;
    public GameObject canvas;
    public Beeper beeper;
    public float experimentStartDelay = 3f;
    private int currentExperiment=0;
    private int currentVideo = 0;
    private ExperimentConfiguration experimentConfiguration;

    private UserInput userInput;
    private string[] videoURlsForExperiment;

    private bool awaitingUserResponse = false;

    void Awake()
    {
        videoPlayer.loopPointReached += onLatestVideoFinished;

        userInput = new UserInput();

        userInput.ExperimentControls.Quit.performed += _ => Application.Quit();
        userInput.ExperimentControls.PauseVideo.performed += _ => Pause();
        userInput.ExperimentControls.RestartVideo.performed += _ => RestartCurrentVideo();

        userInput.UserResponse.LowBeep.performed += _ => LowBeepUserResponse();
        userInput.UserResponse.HighBeep.performed += _ => HighBeepUserResponse();

        beeper.onBeep = BeepTriggered;
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


    public void BeginExperiment()
    {
        if(!int.TryParse(experimentNumberInput.text, out currentExperiment))
        {
            DisplayMessage("Number input error");
            return;
        }

        
        ExperimentConfigurationReader ecr = new ExperimentConfigurationReader();
        experimentConfiguration = ecr.GetExperimentConfiguration(currentExperiment);
        
        videoURlsForExperiment = experimentConfiguration.videoUrls;

        Debug.Log(videoURlsForExperiment.Length);

        if(!InitialiseLogFile())
        {
            return;
        }

        if(videoURlsForExperiment != null &&  videoURlsForExperiment.Length > 0 )
        {
            StartCoroutine(StartVideoSequenceAfterDelay());
        }

    }

    bool InitialiseLogFile()
    {
        if(!DataLogger.Instance.SetFileName("Experiment_" + currentExperiment + ".txt"))
        {
            DisplayMessage("Problem opening experiment save file");
            return false;
        }
        else
        {
            DataLogger.Instance.WriteToFile("Experiment: " + currentExperiment + " " + DateTime.Now);
            int videoNumber = 0;
            foreach(string url in videoURlsForExperiment)
            {
                DataLogger.Instance.WriteToFile(videoNumber.ToString() + " " + url);

                videoNumber+=1;
            }
        }

        return true;
    }

    IEnumerator StartVideoSequenceAfterDelay()
    {        
        DisplayMessage("The experiment will begin shortly.");

        yield return new WaitForSecondsRealtime(experimentStartDelay);

        StartVideoSequence();
    }

    void StartVideoSequence()
    {
        currentVideo = 0;

        string url = videoURlsForExperiment[currentVideo];
        
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

    void onLatestVideoFinished(VideoPlayer source)
    {
        Debug.Log("video finished");

        beeper.StopBeeping();

        currentVideo += 1;

        Debug.Log(currentVideo + " " + videoURlsForExperiment.Length );
        if(currentVideo >= videoURlsForExperiment.Length)
        {
            EndExperiment();
        }
        else
        {
            PlayVideo(videoURlsForExperiment[currentVideo]);
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
            LogResult(beeper.previousBeepState, false, -1);
        }

        awaitingUserResponse = true;
    }

    public void LowBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - beeper.GetLastBeepTime();

        Beeper.BeepState beepState = beeper.beepState;

        if(beepState == Beeper.BeepState.None)
        {
            return;
        }

        if(beepState == Beeper.BeepState.Low)
        {
            LogResult(beepState, true, responseDelay);
        } 
        else
        {
            LogResult(beepState, false, responseDelay);
        }

        beepState = Beeper.BeepState.None;

        awaitingUserResponse = false;

    }

    public void HighBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - beeper.GetLastBeepTime();

        Beeper.BeepState beepState = beeper.beepState;

        if(beepState == Beeper.BeepState.None)
        {
            return;
        }

        if(beepState == Beeper.BeepState.High)
        {
            LogResult(beepState, true, responseDelay);
        } 
        else
        {
            LogResult(beepState, false, responseDelay);
        }

        beepState = Beeper.BeepState.None;

        awaitingUserResponse = false;

        
    }

    void LogResult(Beeper.BeepState type, bool correct, float responseDelay)
    {
        Debug.Log(type.ToString() + ", " + correct + ", " + responseDelay);
        
        DataLogger.Instance.WriteToFile(type.ToString() + ", " + correct + ", " + responseDelay);
    }


    void DisplayMessage(string error)
    {
        canvas.SetActive(true);
        messageText.text = error;
    }

    void EndExperiment()
    {
        DisplayMessage("Fin\nThank you for participating.");
    }

}
