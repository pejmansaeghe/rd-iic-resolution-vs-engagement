using System;
using System.IO;
using UnityEngine;

public class ExperimentConfigurationReader
{
    
    private Experiment experiment = null;

    /// <summary>
    /// Returns the requested experiment configuration from the JSON file (default "config.json"),
    /// which should be in the Persistent storage directory (windows: \user\[name]\Appdata\LocalLow\rd_bbc_co_uk\ResolutionEngagement\)
    /// </summary>
    public ExperimentConfiguration GetExperimentConfiguration(int number, string configurationFilename="config.json")
    {
        if(!ReadConfigFile(configurationFilename))
        {
            return null;
        }

        else
        {
            foreach(ExperimentConfiguration exc in experiment.experimentConfigurations)
            {
                if(exc.experimentNumber == number)
                {
                    return exc;
                }
            }

            return null;
        }
    }

    private bool ReadConfigFile(string configurationFilename)
    {
        string filePath = Path.Combine(Application.persistentDataPath, configurationFilename);

        if(!File.Exists(filePath))
        {
            Debug.Log("Could not find file: " + filePath);
            return false;
        }

        string fileContent = File.ReadAllText(filePath);

        try
        {
            experiment = FromJson(fileContent);
        }
        catch(Exception e)
        {
            Debug.Log("Json parsing error: " + e.Message);
            return false;
        }

        return true;
    }

    private Experiment FromJson(string json)
    {
        return JsonUtility.FromJson<Experiment>(json);
    }

}
