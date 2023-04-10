using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseApplier : MonoBehaviour
{
    public string itemId;

    public virtual void Start()
    {
        ApplyPurchase();
    }

    public virtual void ApplyPurchase()
    {

    }

    public virtual void Preview(int index)
    {

    }

}
