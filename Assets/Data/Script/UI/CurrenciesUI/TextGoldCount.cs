using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGoldCount : TextAbstract
{
    protected virtual void LateUpdate() 
    {
        this.LoadGoldCount();
    }

    protected virtual void LoadGoldCount() 
    {
        ItemInventory item = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
        string goldCount;
        if (item == null)  goldCount = "0";
        else goldCount = item.itemCount.ToString() ;
        this.text.text = goldCount;
    }
}
