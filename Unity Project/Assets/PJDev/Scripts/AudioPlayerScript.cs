using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    enum PreviousBeep{None, Low, High};

    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    public static float timeForNextBeep;

    private UserInput userInput;

    private PreviousBeep previousBeep;

    private float lastBeepTime = 0;

    void Awake()
    {
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        timeForNextBeep = Mathf.Infinity;

        userInput = new UserInput();

        userInput.UserResponse.LowBeep.performed += _ => LowBeepUserResponse();
        userInput.UserResponse.HighBeep.performed += _ => HighBeepUserResponse();

        previousBeep = PreviousBeep.None;
    }

    void OnEnable()
    {
        userInput.UserResponse.Enable();
    }

    void OnDisable()
    {
        userInput.UserResponse.Disable();
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
        previousBeep = PreviousBeep.None;

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

            lastBeepTime = Time.realtimeSinceStartup;
            previousBeep = PreviousBeep.Low;

            Invoke("StopBeep", duration);
        }
        else
        {
            hi_pitch.Play();

            lastBeepTime = Time.realtimeSinceStartup;
            previousBeep = PreviousBeep.High;
            

            Invoke("StopBeep", duration);
        }
        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;
    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }

    public void LowBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if(previousBeep == PreviousBeep.None)
        {
            return;
        }

        if(previousBeep == PreviousBeep.Low)
        {
            LogResult(previousBeep, true, responseDelay);
        } else
        {
            LogResult(previousBeep, false, responseDelay);
        }

        previousBeep = PreviousBeep.None;
    }

    public void HighBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if(previousBeep == PreviousBeep.None)
        {
            return;
        }

        if(previousBeep == PreviousBeep.High)
        {
            LogResult(previousBeep, true, responseDelay);
        } else
        {
            LogResult(previousBeep, false, responseDelay);
        }

        previousBeep = PreviousBeep.None;
    }

    void LogResult(PreviousBeep type, bool correct, float responseDelay)
    {
        Debug.Log(type.ToString() + ", " + correct + ", " + responseDelay);
        
        DataLogger.Instance.WriteToFile(type.ToString() + ", " + correct + ", " + responseDelay);
    }
}


