using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuickTest : MonoBehaviour
{
    // Start is called before the first frame update
    public DetectClicks detectClicks;
    void Start()
    {
        detectClicks.onClick = ProcessClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ProcessClick(float clickTime, PointerEventData.InputButton button)
    {
        Debug.Log("ProcessClick: " + clickTime + " " + button);
    }
}
