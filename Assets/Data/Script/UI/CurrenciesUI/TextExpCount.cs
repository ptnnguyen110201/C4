using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextExpCount : TextAbstract
{
    protected virtual void FixedUpdate() 
    {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount() 
    {
        ItemInventory item = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Exp);
        string goldCount;
        if (item == null)  goldCount = "0";
        else goldCount = item.itemCount.ToString() ;
        this.text.text = goldCount;
    }
}
