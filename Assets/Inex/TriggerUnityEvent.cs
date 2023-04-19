using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerUnityEvent : MonoBehaviour
{
    public UnityEvent theEvent;

    public void InvokeEvent()
    {
        theEvent?.Invoke();
    }
}
