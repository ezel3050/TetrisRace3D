using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public TabManager tabManager;
    public int tabIndex;
    public UnityEvent extraOnClickEvents;

    bool isSelected;
    float selectScaleMultiplier = 1.5f;
    float animDuration = 0.05f;
    public Vector3 baseScale;
    Button button;


    private void Awake()
    {
        baseScale = transform.localScale;
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            extraOnClickEvents?.Invoke();
            tabManager.SelectTab(tabIndex);
            ShopManager.instance.ShowOnlyPurchased();
        });

    }

    public void SeletcTabButtonVisually()
    {
        transform.localScale = baseScale;
        transform.DOScale(baseScale * selectScaleMultiplier, animDuration).SetEase(Ease.InOutBounce);
        isSelected = true;
    }

    public void DeseletTabVisually()
    {
        transform.localScale = baseScale * selectScaleMultiplier;
        transform.DOScale(baseScale, isSelected ? animDuration : 0);
        isSelected = false;
    }

}
