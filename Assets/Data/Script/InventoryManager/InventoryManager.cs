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
        this.LoadItemProfiles();
    }

    protected virtual void LoadItemProfiles() 
    {
        if (this.itemProfileSOs.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfileSOs = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + " Load ItemProfiles", gameObject);
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

    public virtual InventoryCtrl GetInventoryCodeName(InventoryEnum inventoryEnum)
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

    public virtual InventoryCtrl Currencies() => this.GetInventoryCodeName(InventoryEnum.Currencies);
    public virtual InventoryCtrl Items() => this.GetInventoryCodeName(InventoryEnum.Items);
}
