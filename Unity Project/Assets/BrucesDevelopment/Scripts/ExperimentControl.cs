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
    public AudioPlayerScript beeper;
    public float experimentStartDelay = 3f;
    private int currentExperiment=0;
    private int currentVideo = 0;
    private ExperimentConfiguration experimentConfiguration;

    private string[] videoURlsForExperiment;
    void Awake()
    {
        videoPlayer.loopPointReached += onLatestVideoFinished;
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
