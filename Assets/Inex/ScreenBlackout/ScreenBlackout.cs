using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenBlackout : MonoBehaviour
{
    public static ScreenBlackout instance;
    public float blackOutDuration = 0.5f;
    public bool blackOutOnStart;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
    }


    private void Start()
    {
        if (blackOutOnStart)
        {
            BlackFadeOut(null);
        }
    }


    public void BlackFadeIn(Action onFadeIn)
    {
        LerpImageAlpha(0, 1, onFadeIn);
    }

    public void BlackFadeOut(Action onFadeOut)
    {
        LerpImageAlpha(1, 0, onFadeOut);
    }


    void LerpImageAlpha(float startAlpha, float newAlpha, Action onFadeFinished)
    {

        float alpha = startAlpha;
        Tween t;
        t = DOTween.To(() => alpha, x => alpha = x, newAlpha, blackOutDuration).SetEase(Ease.OutQuint);

        t.onUpdate += () =>
        {
            canvasGroup.alpha = alpha;
        };

        t.onComplete += () => onFadeFinished?.Invoke();

    }
}