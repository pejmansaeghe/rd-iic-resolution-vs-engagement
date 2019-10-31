using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationReadTest : MonoBehaviour
{
    // Start is called before the first frame update
    public ExperimentConfigurationReader experimentConfigurationReader;
    public int experimentNumber = 0;
    void Start()
    {
        
    }

    void OnValidate()
    {
        DisplayExperimentDetails();
    }

    void DisplayExperimentDetails()
    {
        
        ExperimentConfiguration exc = experimentConfigurationReader.GetExperimentConfiguration(experimentNumber);

        if(exc == null)
        {
            Debug.Log("exc == null");
        }
        else
        {
            Debug.Log("Experiment found");
            foreach(string videoURL in exc.videoUrls)
            {
                Debug.Log(videoURL);
            }
        }
    }
}
