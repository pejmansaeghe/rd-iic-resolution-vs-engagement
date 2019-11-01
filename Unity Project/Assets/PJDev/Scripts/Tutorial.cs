using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Tutorial : MonoBehaviour
{
    //public GameObject canvas;
    public Beeper beeper;
    TMP_Text messageText;
    GameObject button;
    PlayerControls controls;



    void Awake()
    {
        beeper = GameObject.FindGameObjectWithTag("beeper").GetComponent<Beeper>();
        controls = new PlayerControls();

        controls.Player.HighBeep.performed += _ => HighBeepResponse();
        controls.Player.LowBeep.performed += _ => LowBeepResponse();

        messageText = GameObject.FindGameObjectWithTag("tutorial_message").GetComponent<TMP_Text>();

    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }


    private void Start()
    {
        
        
    }

    public void StartTutorial()
    {
        Debug.Log("start button pressed");
        beeper.StartBeeping();
    }

    public void LowBeepResponse()
    {
        Beeper.BeepState beepState = beeper.beepState;

        if (beepState == Beeper.BeepState.None)
        {
            return;
        }
        if (beepState == Beeper.BeepState.Low)
        {
            PrintToConsole("Correct button was pressed. Well done.");
        }
        else
        {
            PrintToConsole("Incorrect button. Please try again.");
        }
        beepState = Beeper.BeepState.None;

    }

    public void HighBeepResponse()
    {
        Beeper.BeepState beepState = beeper.beepState;

        if (beepState == Beeper.BeepState.None)
        {
            return;
        }
        if (beepState == Beeper.BeepState.High)
        {
            PrintToConsole("Correct button was pressed. Well done.");
        }
        else
        {
            PrintToConsole("Incorrect button. Please try again.");
        }
        beepState = Beeper.BeepState.None;

    }

    void PrintToConsole(string message)
    {
        Debug.Log(message);
    }
}
