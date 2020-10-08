using UnityEngine;
using UnityEngine.Video;
using System;


public class Beeper : MonoBehaviour
{
    public enum BeepState { None, Low, High };

    public Action onBeep;
    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    public float videoTimeForNextBeep { get; private set; }


    public BeepState beepState;
    public BeepState previousBeepState;
    public VideoPlayer videoPlayer;

    private float lastBeepTime = 0;
    private double lastBeepVideoTime = 0;

    void Awake()
    {
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        videoTimeForNextBeep = Mathf.Infinity;


        beepState = BeepState.None;
        previousBeepState = BeepState.None;
    }

    void FixedUpdate()
    {
        if (videoPlayer.time >= videoTimeForNextBeep)
        {
            Debug.Log("beep at: " + videoPlayer.time);

            PlayBeep(0.004f);
        }
    }

    public void StartBeeping()
    {
        lastBeepTime = 0;
        beepState = BeepState.None;

        videoTimeForNextBeep = timeBetweenBeepsSeconds;
    }

    public void StopBeeping()
    {
        videoTimeForNextBeep = Mathf.Infinity;
    }

    public void PlayBeep(float duration)
    {

        previousBeepState = beepState;

        if (UnityEngine.Random.value < 0.5)
        {
            lo_pitch.Play();

            beepState = BeepState.Low;

            Invoke("StopBeep", duration);
        }
        else
        {
            hi_pitch.Play();

            beepState = BeepState.High;

            Invoke("StopBeep", duration);
        }

        lastBeepTime = Time.realtimeSinceStartup;
        lastBeepVideoTime = videoPlayer.time;


        videoTimeForNextBeep += timeBetweenBeepsSeconds;

        if (onBeep != null)
        {
            onBeep();
        }

    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }

    public float GetLastBeepRealTime()
    {
        return lastBeepTime;
    }

    public double GetLastBeepVideoTime()
    {
        return lastBeepVideoTime;
    }


}


