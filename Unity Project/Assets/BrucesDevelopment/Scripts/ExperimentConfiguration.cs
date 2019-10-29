using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

/// <summary>
/// Class to be read by the UnityEngine.JSONUtility class as used in
/// the ExperimentConfigurationReader class.
/// If this is changed then the structure of the matching JSON file
/// will also need to change to match it.
/// </summary>
public class ExperimentConfiguration
{
    public int experimentNumber;
    public string[] videoUrls;
}

[Serializable]
public class Experiment
{
    public ExperimentConfiguration[] experimentConfigurations;
}