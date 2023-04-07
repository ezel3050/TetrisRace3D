using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{
    internal CanvasGroup canvasGroup;


    public virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OpenPanel()
    {
        InputManager.movementInputActive = false;


    }

    public virtual void ClosePanel()
    {
        InputManager.movementInputActive = true;


    }

}