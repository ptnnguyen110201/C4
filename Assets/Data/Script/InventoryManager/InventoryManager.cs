using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfileSOs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 1f);
    }
    protected virtual void Test()
    {
        Invoke(nameof(this.Test), 1f);
        ItemInventory item = new ItemInventory()
        {
            itemCount = 1,
            itemProfileSO = this.GetItemProfileSO(ItemEnum.Wand)
        };
        this.Items().AddItem(item);

    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            InventoryCtrl inventoryCtrl = obj.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }

        Debug.Log(transform.name + " Load Inventories ", gameObject);

    }

    public virtual InventoryCtrl GetInventoryByName(InventoryEnum inventoryEnum)
    {
        if (this.inventories.Count <= 0) return null;
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if (inventory.GetName() == inventoryEnum) return inventory;
        }
        return null;
    }
    public virtual ItemProfileSO GetItemProfileSO(ItemEnum itemEnum)
    {
        if (this.itemProfileSOs.Count <= 0) return null;
        foreach (ItemProfileSO itemProfileSO in this.itemProfileSOs)
        {
            if (itemProfileSO.itemEnum == itemEnum) return itemProfileSO;
        }
        return null;
    }

    public virtual InventoryCtrl Currencies() => this.GetInventoryByName(InventoryEnum.Currency);
    public virtual InventoryCtrl Items() => this.GetInventoryByName(InventoryEnum.Items);
}
