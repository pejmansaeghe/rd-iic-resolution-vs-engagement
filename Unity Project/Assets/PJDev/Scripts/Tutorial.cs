using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Tutorial : MonoBehaviour
{
    enum PreviousBeep { None, Low, High };
    private PreviousBeep previousBeep;
    private float lastBeepTime = 0;

    //public GameObject canvas;
    public Beeper beeper;
    TMP_Text messageText;
    GameObject button;
    PlayerControls controls;



    void Awake()
    {
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
        beeper = new Beeper();
        
    }

    public void StartTutorial()
    {

        beeper.StartBeeping();
    }

    public void LowBeepResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if (previousBeep == PreviousBeep.None)
        {
            return;
        }

        if (previousBeep == PreviousBeep.Low)
        {
            LogResult(previousBeep, true, responseDelay);
        }
        else
        {
            LogResult(previousBeep, false, responseDelay);
        }

        previousBeep = PreviousBeep.None;
    }

    public void HighBeepResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if (previousBeep == PreviousBeep.None)
        {
            return;
        }

        if (previousBeep == PreviousBeep.High)
        {
            LogResult(previousBeep, true, responseDelay);
        }
        else
        {
            LogResult(previousBeep, false, responseDelay);
        }

        previousBeep = PreviousBeep.None;
    }

    //void DisplayMessage(string message)
    //{
    //    messageText.text = message;
    //}
    void LogResult(PreviousBeep type, bool correct, float responseDelay)
    {
        Debug.Log(type.ToString() + ", " + correct + ", " + responseDelay);
        //messageText.text = correct.ToString();

    }
}
