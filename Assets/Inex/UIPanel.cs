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
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public virtual void ClosePanel()
    {
        InputManager.movementInputActive = true;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;

    }

}