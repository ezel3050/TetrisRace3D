using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireEventOnInput : MonoBehaviour
{
    public UnityEvent theEvent;


    private void OnEnable()
    {
        InputManager.interactAction += InteractPrssed;

    }

    void InteractPrssed()
    {
        InputManager.interactAction -= InteractPrssed;
        theEvent?.Invoke();
    }

}
