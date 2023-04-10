using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseApplierGameObject : PurchaseApplier
{
    public List<GameObject> purchaseableGameObjects;

    public override void Start()
    {
        base.Start();
    }


    public override void ApplyPurchase()
    {
        base.ApplyPurchase();
        DisableAllPurchasableGameObjects();
        purchaseableGameObjects[PlayerPrefs.GetInt(itemId + "Selected")].SetActive(true);
    }


    void DisableAllPurchasableGameObjects()
    {
        foreach (GameObject go in purchaseableGameObjects)
        {
            go.SetActive(false);
        }
    }

    public override void Preview(int index)
    {
        base.Preview(index);
        DisableAllPurchasableGameObjects();
        purchaseableGameObjects[index].SetActive(true);

    }

}