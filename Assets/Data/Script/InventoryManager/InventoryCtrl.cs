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
        ItemInventory itemExist = this.FindItemNotFullStack(item.itemProfileSO.itemEnum);

        if (!item.itemProfileSO.isStackable || itemExist == null)
        {
            item.itemID = Random.Range(0, 1000);
            this.items.Add(item);
            return;
        }
        if (item.itemProfileSO.isUnlimitedStack)
        {
            itemExist.itemCount += item.itemCount;
            return;
        }
        int availableSpace = itemExist.itemStack - itemExist.itemCount;
        int amountToAdd = Mathf.Min(item.itemCount, availableSpace);

        itemExist.itemCount += amountToAdd;

        int remainingItems = item.itemCount - amountToAdd;
        if (remainingItems <= 0) return;

        ItemInventory newStack = new ItemInventory
        {
            itemID = Random.Range(0, 1000),
            itemProfileSO = item.itemProfileSO,
            itemCount = remainingItems,
            itemStack = item.itemStack
        };
        this.items.Add(newStack);

    }
    public virtual bool RemoveItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItemNotEmty(item.itemProfileSO.itemEnum);
        if (itemExist == null) return false;
        if (itemExist.itemCount < item.itemCount) return false;
        itemExist.itemCount -= item.itemCount;
        if (itemExist.itemCount == 0) this.items.Remove(itemExist);
        return true;
    }
    public virtual ItemInventory FindItemNotFullStack(ItemEnum itemEnum)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemEnum != itemEnum) continue;
            if (itemInventory.isFullStack()) continue;
            return itemInventory;

        }
        return null;
    }
    public virtual ItemInventory FindItem(ItemEnum itemEnum)
    {
        if (this.items.Count <= 0) return null;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemEnum != itemEnum) continue;
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
