using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseApplier : MonoBehaviour
{
    public string itemId;
    public bool applyPurchasedOnStart = true;

    public virtual void Start()
    {
        if (!applyPurchasedOnStart) return;
        ApplyPurchase();
    }

    public virtual void ApplyPurchase()
    {

    }

    public virtual void Preview(int index)
    {

    }

}
