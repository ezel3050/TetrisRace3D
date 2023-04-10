using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics.Contracts;
using System.Drawing;

[RequireComponent(typeof(CanvasGroup))]
public class UIElement : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    public void ShowScale(bool instant = true)
    {
        ShowScale(true, instant);
    }

    public void HideScale(bool instant = true)
    {
        ShowScale(false, instant);
    }

    void ShowScale(bool show , bool instant = true)
    {
        float newScale = show ? 1 : 0;
        float animationDuration = instant ? 0 : 0.3f;

        Tween t;
        t = transform.DOScale(newScale, animationDuration);
        t.SetEase(Ease.InOutQuint);
    }

    public void ShowFade(bool show)
    {
        float alpha = show ? 0 : 1;
        Tween t1 = DOTween.To(() => alpha, x => alpha = x, show ? 1 : 0, 1);
        t1.onUpdate += () =>
        {
            canvasGroup.alpha = alpha;
        };
        t1.SetEase(Ease.InOutQuint);
    }



}