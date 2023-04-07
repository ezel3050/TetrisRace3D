using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image imageIcon;
    public TextMeshProUGUI text;
    public string saveID;
    public bool shouldMinify;
    public int value { get; set; }

    int desplayedValue;
    private void Start()
    {
        value = PlayerPrefs.GetInt(saveID);
        UpdateText(0);
    }

    [Button]
    public void UpdateText(int delta)
    {
        PlayIconScaleAnimation();
        PlayerPrefs.SetInt(saveID, value + delta);
        value += delta;

        DOTween.To(() => desplayedValue, x => desplayedValue = x, value, 1.3f).SetEase(Ease.OutQuint).onUpdate += () =>
        {
            text.text = shouldMinify ? MinifyLong.Minify(desplayedValue) : desplayedValue.ToString();
        };
    }


    public void TryToDeduct(int deductValue, Action onDeduct = null)
    {
        if (HaveTheMoney(deductValue))
        {
            UpdateText(-deductValue);
            onDeduct?.Invoke();
            PlayIconScaleAnimation();
        }

        //Don't have the money
        else
        {
            PlayIconScaleAnimation();
        }
    }

    public bool HaveTheMoney(int amount)
    {
        return amount <= value;
    }


    void PlayIconScaleAnimation()
    {
        imageIcon.transform.DOScale(1.4f, 0.5f).SetEase(Ease.InOutQuint).SetLoops(2, LoopType.Yoyo);
        this.CallWithDelay(() =>
        {
            imageIcon.transform.localScale = Vector3.one;
        },2);
    }
}