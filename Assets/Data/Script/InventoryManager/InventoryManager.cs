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
        this.TestInventory();
    }

    protected virtual void TestInventory()
    {
        InventoryCtrl inventoryCtrl = this.GetInventoryByName(InventoryEnum.Currency);

        ItemInventory item = new ItemInventory()
        {
            itemProfileSO = this.GetItemProfileSO(ItemEnum.Gold),
            itemCount = 10,
        }; 
        inventoryCtrl.AddItem(item);
        inventoryCtrl.AddItem(item);
        InventoryCtrl inventoryCtr1l = this.GetInventoryByName(InventoryEnum.Items);
        ItemInventory item1 = new ItemInventory()
        {
            itemProfileSO = this.GetItemProfileSO(ItemEnum.Wand),
            itemCount = 10,
        };
        inventoryCtr1l.AddItem(item1);

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
        foreach(InventoryCtrl inventory in this.inventories)
        {
            if(inventory.GetName() == inventoryEnum) return inventory;
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
}
