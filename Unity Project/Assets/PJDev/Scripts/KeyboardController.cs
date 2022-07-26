﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardController : MonoBehaviour
{
    PlayerControls controls;


    public void Awake()
    {
        Beeper audioPlayer = GameObject.FindObjectOfType<Beeper>();
        controls = new PlayerControls();
        audioPlayer = new Beeper();
        
        // start tutorial with spacebar and quit by pressing q
        controls.Player.StartTutorial.performed += _ => audioPlayer.StartBeeping();
        controls.Player.QuitTutorial.performed += _ => audioPlayer.StopBeeping();

        
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
