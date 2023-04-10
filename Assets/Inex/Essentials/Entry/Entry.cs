using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class Entry : MonoBehaviour
{
    CanvasGroup canvasGroup;

    void Awake()
    {
        DontDestroyOnLoad(this);
        AsyncOperation AO;
        canvasGroup = GetComponentInChildren<CanvasGroup>();


        AO = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        AO.completed += OnLoaded;
    }

    void OnLoaded(AsyncOperation AO)
    {
        this.CallWithDelay(() =>
        {
            FadeOutLoadingPanel();
        }, 1.5f);
    }

    void FadeOutLoadingPanel()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        float alpha = 1;
        DOTween.To(() => alpha, x => alpha = x, 0, 1.5f).SetEase(Ease.OutQuint).onUpdate += () =>
        {
            canvasGroup.alpha = alpha;
        };
    }
}

