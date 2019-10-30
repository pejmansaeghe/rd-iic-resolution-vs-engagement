//This script allows you to toggle music to play and stop.
//Assign an AudioSource to a GameObject and attach an Audio Clip in the Audio Source. Attach this script to the GameObject.

using System;
using System.Timers;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{

    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    private float timer;

    // toggle=false means sound off, toggle=true means sound on
    bool lo_toggle, hi_toggle, _playBeep;

    void Start()
    {
        //Fetch the AudioSources from the GameObject
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        lo_toggle = false;
        hi_toggle = false;
        _playBeep = false;
        timer = 0.0f;
    }


    void FixedUpdate()
    {
        timer += Time.fixedUnscaledDeltaTime;
        //Debug.Log(timer);

        if (Input.GetKeyDown("space"))
        {
            timer = 0.0f;
            _playBeep = true;
        }

        if (_playBeep)
        {
            if (timer > timeBetweenBeepsSeconds)
            {
                PlayBeep(0.01f);
            }
        }
    }

    /// <summary>
    /// Receive the start time from another script (the videoPlayer) and plays a short beep every 15 seconds.
    /// </summary>
    /// <returns></returns>
    /// 
    public void PlayBeep(float duration)
    {
        if (UnityEngine.Random.value < 0.5)
        {
            lo_pitch.Play();
            Invoke("StopBeep", duration);
        }
        else
        {
            hi_pitch.Play();
            Invoke("StopBeep", duration);
        }
        timer = 0f;
    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }
}
