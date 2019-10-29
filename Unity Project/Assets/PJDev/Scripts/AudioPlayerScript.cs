//This script allows you to toggle music to play and stop.
//Assign an AudioSource to a GameObject and attach an Audio Clip in the Audio Source. Attach this script to the GameObject.

using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    public int timeBetweenBeepsSeconds;
    AudioSource lo_pitch, hi_pitch;
    System.DateTime playbackTime;
    System.TimeSpan beepDuration;
    System.TimeSpan timeBetweenBeeps;

    // toggle=false means sound off, toggle=true means sound on
    bool lo_toggle, hi_toggle, begin;

    void Start()
    {
        //Fetch the AudioSources from the GameObject
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        lo_toggle = false;
        hi_toggle = false;
        begin = false;
    }


    void FixedUpdate()
    {
        timeBetweenBeeps = System.DateTime.Now - playbackTime;
        //Debug.Log("fixed delta time: " + Time.fixedDeltaTime.ToString());
        //Debug.Log("delta time: " + Time.deltaTime.ToString());
        Debug.Log("system time in seconds: " + System.DateTime.Now);
        Debug.Log("time between beeps: " + timeBetweenBeeps.TotalMilliseconds);

        //if (Input.GetKeyDown("space"))
        //{
        //    PlayBeep();
        //}
       
        if (lo_toggle == false && hi_toggle == false && timeBetweenBeeps.TotalMilliseconds > timeBetweenBeepsSeconds * 1000)
        {
            PlayBeep();
        }
            

        else if ((lo_toggle || hi_toggle) && (System.DateTime.Now.Millisecond - playbackTime.Millisecond > 25))
        {
            StopBeep();
        }


        //if (Input.GetKeyDown("space") && toggle==false)
        //{
        //    if (Random.value < 0.5)
        //    {
        //        lo_pitch.Play();
        //    }
        //    else
        //    {
        //        hi_Pitch.Play();
        //    }
        //    toggle = true;
        //    Debug.Log("lo_pitch played");
        //    Debug.Log(toggle);
        //}
        //else if (Input.GetKeyDown("space") && toggle==true)
        //{
        //    lo_pitch.Stop();
        //    hi_Pitch.Stop();
        //    toggle = false;
        //    Debug.Log("lo_pitch stopped");
        //    Debug.Log(toggle);
        //}
    }

    /// <summary>
    /// Receive the start time from another script (the videoPlayer) and plays a short beep every 15 seconds.
    /// </summary>
    /// <returns></returns>
    public void PlayBeep()
    {
        if (Random.value < 0.5)
        {
            lo_pitch.Play();
            lo_toggle = true;
        }
        else
        {
            hi_pitch.Play();
            hi_toggle = true;
        }
        playbackTime = System.DateTime.Now;
    }

    public void StopBeep()
    {
        if (lo_toggle)
        {
            lo_pitch.Stop();
            lo_toggle = false;
        }
        else if (hi_toggle)
        {
            hi_pitch.Stop();
            hi_toggle = false;
        }
    }
   
}
