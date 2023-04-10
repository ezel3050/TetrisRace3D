using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    public static MessagePanel instance;
    public Transform panel;
    public TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }


    public void ShowMessage(string message)
    {
        panel.DOScale(1, 0.2f).SetEase(Ease.InOutQuint);
        text.text = message;
    }

    public void ClosePanel()
    {
        panel.DOScale(0, 0.2f).SetEase(Ease.InOutQuint);
    }


}
