using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPointCount : TextAbstract
{
    protected virtual void LateUpdate() 
    {
        this.LoadPointCount();
    }

    protected virtual void LoadPointCount() 
    {
        ItemInventory item = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Point);
        string pointCount;
        if (item == null) pointCount = "0";
        else pointCount = item.itemCount.ToString() ;
        this.text.text = pointCount;
    }
}
