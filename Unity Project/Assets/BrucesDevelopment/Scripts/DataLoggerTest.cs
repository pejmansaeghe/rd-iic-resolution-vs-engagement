using System;
using UnityEngine;

public class DataLoggerTest : MonoBehaviour
{
    void Start()
    {
        DataLogger.Instance.SetFileName("test logging file.log");
    }

    // Update is called once per frame
    void Update()
    {
        DataLogger.Instance.WriteToFile(DateTime.Now.ToString() + " " + Time.timeSinceLevelLoad.ToString());
    }
}
