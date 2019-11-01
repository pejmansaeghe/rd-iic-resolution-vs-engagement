using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    private static DataLogger instance = null;

    public static DataLogger Instance
    {
        get
        {
            return instance;
        }
    }

    private FileStream currentFile;

    void Awake()
    {
        instance = this;
    }

    void OnApplicationQuit()
    {
        CloseLogFile();
    }

    public void CloseLogFile()
    {
        if(currentFile != null)
        {
            currentFile.Flush();
            currentFile.Close();
        }
    }

    public bool SetFileName(string fileName)
    {
        CloseLogFile();

        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        Debug.Log(filePath);

        try
        {       
            currentFile = File.Open(filePath, FileMode.Append);                 
        }
        catch(Exception e)
        {
            Debug.Log("DataLogger error: " + e.Message);
            return false;
        }


        if(currentFile == null)
        {
            Debug.Log("DataLogger error. Null file");
            return false;
        }

        return true;
    }

    public bool WriteToFile(string message)
    {
        if(currentFile == null)
        {            
            Debug.Log("DataLogger error. null file in WriteToFile");
            return false;
        }

        if(!message.EndsWith(System.Environment.NewLine))
        {
            message += (System.Environment.NewLine);
        }

        try
        {
            //UnicodeEncoding uniencoding = new UnicodeEncoding();
            UTF8Encoding utf8 = new UTF8Encoding();

            byte[] result = utf8.GetBytes(message);

            currentFile.Write(result, 0, result.Length);
        }
        catch(Exception e)
        {
            Debug.Log("DataLogger error: " + e.Message);
            return false;
        }

        return true;
    }

    public string CurrentFilePath()
    {
        if(currentFile == null)
        {
            return "";
        }

        return currentFile.Name;
    }

}
