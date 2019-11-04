using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    //public GameObject canvas;
    public Beeper beeper;
    public TMP_Text messageText;
    GameObject button;
    UserInput userInput;
    private bool awaitingUserResponse = false;

    private float clearMessageTime = Mathf.Infinity;
    void Awake()
    {
        userInput = new UserInput();

        userInput.UserResponse.HighBeep.performed += _ => HighBeepResponse();
        userInput.UserResponse.LowBeep.performed += _ => LowBeepResponse();
        userInput.ExperimentControls.Quit.performed += _ => Application.Quit();

        
        beeper.onBeep = BeepTriggered;


    }

    private void Update()
    {
        //Debug.Log(Time.realtimeSinceStartup - beeper.GetLastBeepTime());
        if (Time.realtimeSinceStartup > clearMessageTime)
        {
           ClearDisplay();
           clearMessageTime = Mathf.Infinity;
        }
    }

    private void BeepTriggered()
    {
        awaitingUserResponse = true;
        //ResetTextMessage();
        //messageText.text = "";
    }

    void OnEnable()
    {
        userInput.Enable();
    }

    void OnDisable()
    {
        userInput.Disable();
    }

    public void StartTutorial()
    {
        //Debug.Log("start button pressed");
        beeper.StartBeeping();

        DisplayMessage("Get ready.....");

        clearMessageTime = Time.realtimeSinceStartup + beeper.timeBetweenBeepsSeconds - 1;
    }

    public void LowBeepResponse()
    {
        Beeper.BeepState beepState = beeper.beepState;

        if (beepState == Beeper.BeepState.None || !awaitingUserResponse)
        {
            return;
        }
        if (beepState == Beeper.BeepState.Low)
        {
            DisplayMessage("Correct button was pressed. Well done.");
        }
        else
        {
            DisplayMessage("Incorrect button. You'll get it next time.");
        }
        beepState = Beeper.BeepState.None;
        awaitingUserResponse = false;

        clearMessageTime = Time.realtimeSinceStartup + 3;

    }

    public void HighBeepResponse()
    {
        Beeper.BeepState beepState = beeper.beepState;

        if (beepState == Beeper.BeepState.None || !awaitingUserResponse)
        {
            return;
        }
        if (beepState == Beeper.BeepState.High)
        {
            DisplayMessage("Correct button was pressed. Well done.");
        }
        else
        {
            DisplayMessage("Incorrect button. You'll get it next time.");
        }
        beepState = Beeper.BeepState.None;
        awaitingUserResponse = false;

        clearMessageTime = Time.realtimeSinceStartup + 3;

    }

    void DisplayMessage(string message)
    {
        messageText.text= message;
    }

    void ClearDisplay()
    {
        Debug.Log("clear display");
        messageText.text = "";
    }

    public void StopTutorial()
    {
        beeper.StopBeeping();
    }

    public void StartExperiment()
    {
        beeper.StopBeeping();
        SceneManager.LoadSceneAsync(1);//"BrucesDevelopment/Scenes/VideoPlayerScene");
    }
}
