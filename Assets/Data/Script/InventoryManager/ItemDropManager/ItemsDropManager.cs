using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManager : Singleton<ItemsDropManager>
{
    [SerializeField] protected ItemDropSpanwer itemDropSpanwer;
    public ItemDropSpanwer ItemDropSpanwer => itemDropSpanwer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropSpawner();
    }

    protected virtual void LoadItemDropSpawner() 
    {
        if (this.itemDropSpanwer != null) return;
        this.itemDropSpanwer = transform.GetComponent<ItemDropSpanwer>();
        Debug.Log(transform.name + ": Load ItemDropSpawner");
    }

    public virtual void DropItems(InventoryEnum inventoryEnum, ItemEnum itemEnum, int dropCount, Vector3 DropPos) 
    {
        ItemDropCtrl itemPrefab = this.itemDropSpanwer.PoolPrefabs.GetPrefabByName(itemEnum.ToString());
        ItemDropCtrl newItem = this.itemDropSpanwer.Spawn(itemPrefab, DropPos);
        newItem.SetValue(itemEnum, dropCount, inventoryEnum);
        newItem.gameObject.SetActive(true);
    }

}
