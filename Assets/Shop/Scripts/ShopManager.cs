//using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public TabManager mainTabManager;
    public Image imageBackground;
    public List<Sprite> backgroundSprites;
    public Sprite shopButtonNormalSprite, ShopButtonSelectedSprite;
    public TextMeshProUGUI cashPriceText, rvPriceText;
    public GameObject purchaseButtons, rvButton, orText;

    [HideInInspector]
    public ShopButton[] shopButtons;
    ShopButton selectedShopButton;

    private void Awake()
    {
        instance = this;
        shopButtons = GetComponentsInChildren<ShopButton>();
    }

    

    private void OnEnable()
    {
        imageBackground.sprite = backgroundSprites[Random.Range(0, backgroundSprites.Count)];
    }

    void Start()
    {
        mainTabManager.SelectTab(0);
    }

    public void SelectItem(ShopItemData shopItemData)
    {
        SetThisItemAsSelectedInPrefs(shopItemData);
        ShowPurchaseButtons(false);
        ShowOnlyPurchased();
        this.CallWithDelay(RefreshButtons, 0.1f);
        RefreshButtons();
    }

    public void PurchaseItem(ShopItemData shopItemData)
    {
        SetThisItemAsPurchasedInPrefs(shopItemData);
        SelectItem(shopItemData);
     //   GameAnalytics.NewDesignEvent("ShopPurchasedItem_" + shopItemData.itemId + "_" + shopItemData.index);

    }


    public void RefreshButtons()
    {
        foreach(ShopButton shopButton in shopButtons)
        {
            shopButton.RefreshButtonGraphics();
        }
    }   

    public void ShopButtonClicked(ShopButton clickedButtons)
    {
        string itemId = clickedButtons.shopItemData.itemId;
        int itemIndex = clickedButtons.shopItemData.index;

        if (clickedButtons.isItemPurchased())
        {
            SelectItem(clickedButtons.shopItemData);
        }

        else
        {
            //Preview
            foreach (PurchaseApplier purchaseApplier in FindObjectsOfType<PurchaseApplier>())
            {
                if(purchaseApplier.itemId == itemId)
                {
                    purchaseApplier.Preview(itemIndex);
                }
            }

            //PurchaseButtons
            selectedShopButton = clickedButtons;
            PrintPurchasePricesOnPurchaseButtons();
            ShowPurchaseButtons(true);

        }
    }

    void PrintPurchasePricesOnPurchaseButtons()
    {
        int price = selectedShopButton.shopItemData.price;
        bool isFree = price <= 0;

        rvPriceText.text = PlayerPrefs.GetInt(selectedShopButton.shopItemData.itemId + selectedShopButton.shopItemData.index + "RVWatched").ToString() + "/" + selectedShopButton.shopItemData.RVPrice.ToString();
        cashPriceText.text = isFree ? "FREE" : price.ToString();

        orText.SetActive(!isFree);
        rvButton.SetActive(!isFree);


    }


    public void PurchaseCashButtonClicked()
    {
        //if have the money purchase it.
        int price = selectedShopButton.shopItemData.price;
        
    
        MainMenu.instance.HUD.moneyUISlot.TryToDeduct(price, () =>
        {
            PurchaseItem(selectedShopButton.shopItemData);
        });




    }


   //  public void PurchaseRVButtonClicked()
   //  {
   //  //    GameAnalytics.NewDesignEvent("ShopPurchaseClicked_RV");
   // //     GameAnalytics.NewDesignEvent("WhatRVPricesAreClickedTheMost(ValueHereIsRVPrice)", selectedShopButton.shopItemData.RVPrice);
   //
   //      //Show RV 
   //      AdManager.instance.ShowRV(RvShowed);
   //
   //  }

    void RvShowed()
    {
        //Increase Number of RV Watched for this Item
        string prefKey = selectedShopButton.shopItemData.itemId + selectedShopButton.shopItemData.index + "RVWatched";
        int currentWatchedRV = PlayerPrefs.GetInt(prefKey) + 1;
        PlayerPrefs.SetInt(prefKey, currentWatchedRV);

        //Purchase the item OR update the prices
        if(currentWatchedRV >= selectedShopButton.shopItemData.RVPrice)
        {
            PurchaseItem(selectedShopButton.shopItemData);
        }
        else
        {
            PrintPurchasePricesOnPurchaseButtons();
        }
    }


    public void ShowOnlyPurchased()
    {
        foreach (PurchaseApplier purchaseApplier in FindObjectsOfType<PurchaseApplier>())
        {
            purchaseApplier.ApplyPurchase();
        }
    }

    public void ShowPurchaseButtons(bool show)
    {
        purchaseButtons.SetActive(show);
    }

    public static void SetThisItemAsPurchasedInPrefs(ShopItemData shopItemData)
    {
        PlayerPrefs.SetInt(shopItemData.itemId + shopItemData.index + "Purchased", 1);

    }

    public static void SetThisItemAsSelectedInPrefs(ShopItemData shopItemData)
    {
        PlayerPrefs.SetInt(shopItemData.itemId + "Selected", shopItemData.index);

    }


}

