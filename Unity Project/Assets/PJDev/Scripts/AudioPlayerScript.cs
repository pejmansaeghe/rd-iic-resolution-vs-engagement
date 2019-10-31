using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    public static float timeForNextBeep;

    private void Awake()
    {
        timeForNextBeep = Mathf.Infinity;
    }

    void Start()
    {
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
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
        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;
    }

    public void StopBeeping()
    {
        timeForNextBeep = Mathf.Infinity;
    }

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
        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;
    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }
}


