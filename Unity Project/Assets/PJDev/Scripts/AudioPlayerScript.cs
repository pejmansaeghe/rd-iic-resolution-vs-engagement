using UnityEngine;
using System;

public class AudioPlayerScript : MonoBehaviour
{
    public enum BeepState{None, Low, High};

    public Action onBeep;
    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    public float timeForNextBeep { get; private set; }


    public BeepState beepState;
    public BeepState previousBeepState;

    private float lastBeepTime = 0;

    void Awake()
    {
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        timeForNextBeep = Mathf.Infinity;


        beepState = BeepState.None;
        previousBeepState = BeepState.None;
    }

    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > timeForNextBeep)
        {
            PlayBeep(0.01f);
        }
    }

    public void StartBeeping()
    {
        lastBeepTime = 0;
        beepState = BeepState.None;

        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;
    }

    public void StopBeeping()
    {
        timeForNextBeep = Mathf.Infinity;
    }

    public void PlayBeep(float duration)
    {
        
        previousBeepState = beepState;

        if (UnityEngine.Random.value < 0.5)
        {
            lo_pitch.Play();

            lastBeepTime = Time.realtimeSinceStartup;
            beepState = BeepState.Low;

            Invoke("StopBeep", duration);
        }
        else
        {
            hi_pitch.Play();

            lastBeepTime = Time.realtimeSinceStartup;
            beepState = BeepState.High;
            

            Invoke("StopBeep", duration);
        }

        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;

        if(onBeep != null)
        {
            onBeep();
        }

    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }

    public float GetLastBeepTime()
    {
        return lastBeepTime;    
    }


}


