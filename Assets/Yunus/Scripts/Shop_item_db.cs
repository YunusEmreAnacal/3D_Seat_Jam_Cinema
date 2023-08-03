using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop_item_db", menuName ="Shopping/Shop item db")]
public class Shop_item_db : ScriptableObject
{
    public Shop_item[] items;

    public int ItemsCount{
        get{return items.Length;}
    }

    public Shop_item GetItem(int index){
        return items[index];
    }
    public void PurchaseItem(int index){
        items[index].isPurchased = true;
    }
}
