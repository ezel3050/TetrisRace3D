using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopItemData shopItemData;
    public GameObject ownedIcon;
   public  Button button;
    public Image buttonBG;

    private void Awake()
    {
        button.onClick.AddListener(Clicked);

    }

    private void Start()
    {
        RefreshButtonGraphics();
    }


    public void RefreshButtonGraphics()
    {
        buttonBG.sprite = PlayerPrefs.GetInt(shopItemData.itemId + "Selected") == shopItemData.index ? ShopManager.instance.ShopButtonSelectedSprite : ShopManager.instance.shopButtonNormalSprite;
        ownedIcon.SetActive(isItemPurchased());

    }

    void Clicked()
    {
        ShopManager.instance.ShopButtonClicked(this);
        ShopManager.instance.RefreshButtons();
    }

    public bool isItemPurchased()
    {
        return PlayerPrefs.GetInt(shopItemData.itemId + shopItemData.index + "Purchased") == 1 || shopItemData.index == 0;
    }

}


