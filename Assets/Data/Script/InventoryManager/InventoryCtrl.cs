using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : LoadComPonentsManager
{
    [SerializeField] protected List<ItemInventory> items = new();

    public abstract InventoryEnum GetName();

    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item.itemProfileSO.itemEnum);
        if (itemExist == null)
        {
            this.items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;  
    }

    public virtual ItemInventory FindItem(ItemEnum itemEnum) 
    {
        if (this.items.Count <= 0) return null;
        foreach (ItemInventory itemInventory in this.items) 
        {
            if(itemInventory.itemProfileSO.itemEnum == itemEnum) return itemInventory;
        }
        return null;
    }
}
