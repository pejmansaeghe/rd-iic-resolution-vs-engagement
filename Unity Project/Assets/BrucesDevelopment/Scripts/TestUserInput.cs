using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestUserInput : MonoBehaviour
{
    UserInput userInput;
    
    void Awake()
    {
        userInput = new UserInput();

        userInput.UserResponse.LowBeep.performed += ctx => LowBeep();   
        userInput.UserResponse.HighBeep.performed += ctx => HighBeep();
    }

    void OnEnable()
    {
        userInput.UserResponse.Enable();
    }

    void OnDisable()
    {
        userInput.UserResponse.Disable();
    }

    // Update is called once per frame
    void LowBeep()
    {
        Debug.Log("LowBeep: " + Time.realtimeSinceStartup);
    }

    void HighBeep()
    {
        Debug.Log("HighBeep: " + Time.realtimeSinceStartup);
    }
}
