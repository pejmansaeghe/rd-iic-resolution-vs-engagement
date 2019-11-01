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
    TMP_Text messageText;
    GameObject button;
    UserInput userInput;
    private bool awaitingUserResponse = false;


    void Awake()
    {
        userInput = new UserInput();

        userInput.UserResponse.HighBeep.performed += _ => HighBeepResponse();
        userInput.UserResponse.LowBeep.performed += _ => LowBeepResponse();

        messageText = GameObject.FindGameObjectWithTag("tutorial_message").GetComponent<TMP_Text>();

        beeper.onBeep = BeepTriggered;

    }

    private void Update()
    {
        //Debug.Log(Time.realtimeSinceStartup - beeper.GetLastBeepTime());
        if (Time.realtimeSinceStartup - beeper.GetLastBeepTime() > 4 )
        {
            ResetTextMessage("");
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
            PrintMessage("Correct button was pressed. Well done.");
        }
        else
        {
            PrintMessage("Incorrect button. You'll get it next time.");
        }
        beepState = Beeper.BeepState.None;
        awaitingUserResponse = false;

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
            PrintMessage("Correct button was pressed. Well done.");
        }
        else
        {
            PrintMessage("Incorrect button. You'll get it next time.");
        }
        beepState = Beeper.BeepState.None;
        awaitingUserResponse = false;

    }

    void PrintMessage(string message)
    {
        messageText.text= message;
    }

    void ResetTextMessage(string m)
    {
        messageText.text = m;
    }

    public void StopTutorial()
    {
        beeper.StopBeeping();
    }

    public void StartExperiment()
    {
        beeper.StopBeeping();
        SceneManager.LoadSceneAsync("BrucesDevelopment/Scenes/VideoPlayerScene");
    }
}
