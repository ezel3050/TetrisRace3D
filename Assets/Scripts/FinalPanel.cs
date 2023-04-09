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

    }


    public override void ClosePanel()
    {
        base.ClosePanel();


    }

    public void NextLevelButtonClicked()
    {
        SceneManagement.LoadScene("GameScene");
    }

}