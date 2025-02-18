using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : LoadComPonentsManager
{
    [SerializeField] protected List<ItemInventory> items = new();
    public List<ItemInventory> Items => items;
    public abstract InventoryEnum GetName();

    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item.itemProfileSO.itemEnum);

        if (!item.itemProfileSO.isStackable || itemExist == null || item.isFullStack(itemExist.itemCount))
        {
            item.itemID = Random.Range(0, 1000);
            this.items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;  
    }

    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmty(item.itemProfileSO.itemEnum);
        if (itemExist == null) return false;
        if (itemExist.itemCount < item.itemCount) return false;
        itemExist.itemCount -= item.itemCount;
        if(itemExist.itemCount == 0) this.items.Remove(itemExist);
        return true;
    }

    public virtual ItemInventory FindItem(ItemEnum itemEnum) 
    {
        if (this.items.Count <= 0) return null;
        foreach (ItemInventory itemInventory in this.items) 
        {
            if(itemInventory.isFullStack(itemInventory.itemCount)) continue;
            if(itemInventory.itemProfileSO.itemEnum == itemEnum)
            return itemInventory;
        }
        return null;
    }

    public virtual ItemInventory FindItemNotEmty(ItemEnum itemEnum) 
    {
        if (this.items.Count <= 0) return null;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemEnum != itemEnum) continue;
            if (itemInventory.itemCount > 0) return itemInventory;
         
        }
        return null;
    }
}
