using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public ShopManager shopManager;
    public HUD HUD;
    public UIPanel lostPanel;
    public GameObject mainMenu;
    public GameObject handTutorial;
    private void Awake()
    {
        instance = this;
    }


    public void TryAgainButtonClicked()
    {
        SceneManagement.ReloadCurrentLevel();
    }


    public void OpenShop(bool open)
    {
        shopManager.gameObject.SetActive(open);
        shopManager.ShowOnlyPurchased();
    }

}
