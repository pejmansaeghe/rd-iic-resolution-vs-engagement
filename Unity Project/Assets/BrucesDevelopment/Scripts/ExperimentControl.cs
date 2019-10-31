using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class ExperimentControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField experimentNumberInput;
    public VideoPlayer videoPlayer;
    public GameObject canvas;
    private int currentExperiment=0;
    private int currentVideo = 0;
    private ExperimentConfiguration experimentConfiguration;

    private string[] videoURlsForExperiment;
    void Awake()
    {
        videoPlayer.loopPointReached += onLatestVideoFinished;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginExperiment()
    {
        if(!int.TryParse(experimentNumberInput.text, out currentExperiment))
        {
            return;
        }

        currentVideo = 0;

        ExperimentConfigurationReader ecr = new ExperimentConfigurationReader();
        experimentConfiguration = ecr.GetExperimentConfiguration(currentExperiment);
        
        videoURlsForExperiment = experimentConfiguration.videoUrls;

        if(videoURlsForExperiment != null &&  videoURlsForExperiment.Length > 0 )
        {
            canvas.SetActive(false);
            StartVideo(videoURlsForExperiment[currentVideo]);
        }

    }

    void StartVideo(string url)
    {
        videoPlayer.url = url;
        videoPlayer.Play();
    }

    void onLatestVideoFinished(VideoPlayer source)
    {
        Debug.Log("video finished");
    }
}
