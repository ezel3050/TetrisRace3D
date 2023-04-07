using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : UIPanel
{
    public static FinalPanel instance;

    public override void Awake()
    {
        base.Awake();
        instance = this;
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }


    public override void ClosePanel()
    {
        base.ClosePanel();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;

    }

    public void NextLevelButtonClicked()
    {
        SceneManagement.LoadScene("GameScene");
    }

}