using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemData" , menuName = "ShopItemData")]
public class ShopItemData : ScriptableObject
{
    public string itemId;
    public int index;
    public int price;
    public int RVPrice;
}
