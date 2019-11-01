using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    enum BeepState{None, Low, High};

    public int timeBetweenBeepsSeconds;
    private static AudioSource lo_pitch, hi_pitch;
    public float timeForNextBeep { get; private set; }

    private UserInput userInput;

    private BeepState beepState;

    private float lastBeepTime = 0;
    private bool awaitingUserResponse = false;

    void Awake()
    {
        lo_pitch = GameObject.FindGameObjectWithTag(tag: "Lo_Pitch").GetComponent<AudioSource>();
        hi_pitch = GameObject.FindGameObjectWithTag(tag: "Hi_Pitch").GetComponent<AudioSource>();
        timeForNextBeep = Mathf.Infinity;

        userInput = new UserInput();

        userInput.UserResponse.LowBeep.performed += _ => LowBeepUserResponse();
        userInput.UserResponse.HighBeep.performed += _ => HighBeepUserResponse();

        beepState = BeepState.None;
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
        beepState = BeepState.None;

        timeForNextBeep = Time.realtimeSinceStartup + timeBetweenBeepsSeconds;
    }

    public void StopBeeping()
    {
        timeForNextBeep = Mathf.Infinity;
    }

    public void PlayBeep(float duration)
    {
        if(awaitingUserResponse && beepState != BeepState.None)
        {
            LogResult(beepState, false, -1);
        }

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

        awaitingUserResponse = true;
    }

    public void StopBeep()
    {
        lo_pitch.Stop();
        hi_pitch.Stop();
    }

    public void LowBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if(beepState == BeepState.None)
        {
            return;
        }

        if(beepState == BeepState.Low)
        {
            LogResult(beepState, true, responseDelay);
        } else
        {
            LogResult(beepState, false, responseDelay);
        }

        beepState = BeepState.None;

        awaitingUserResponse = false;
    }

    public void HighBeepUserResponse()
    {
        float responseDelay = Time.realtimeSinceStartup - lastBeepTime;

        if(beepState == BeepState.None)
        {
            return;
        }

        if(beepState == BeepState.High)
        {
            LogResult(beepState, true, responseDelay);
        } else
        {
            LogResult(beepState, false, responseDelay);
        }

        beepState = BeepState.None;

        awaitingUserResponse = false;
    }

    void LogResult(BeepState type, bool correct, float responseDelay)
    {
        Debug.Log(type.ToString() + ", " + correct + ", " + responseDelay);
        
        DataLogger.Instance.WriteToFile(type.ToString() + ", " + correct + ", " + responseDelay);
    }
}


