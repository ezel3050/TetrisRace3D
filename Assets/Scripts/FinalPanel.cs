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
        UICollectableImageGenerator.Instance.SpawnItems(Input.mousePosition, MainMenu.instance.HUD.moneyUISlot.imageIcon.transform.position, () =>
        {
            MainMenu.instance.HUD.moneyUISlot.UpdateText(GameManager.instnace.currentLevel.levelReward);
            this.CallWithDelay(() =>
            {
                SceneManagement.LoadScene("GameScene");
            }, 1);
        });

    }

}