using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DetectClicks : MonoBehaviour, IPointerDownHandler 
{
    public Action<float, PointerEventData.InputButton> onClick;
    
    public void OnPointerDown(PointerEventData evt)
    {
        Debug.Log("click: " + evt.button + " " +  Time.timeSinceLevelLoad);

        if(onClick != null)
        {
            onClick(Time.timeSinceLevelLoad, evt.button);
        }
    }
}
