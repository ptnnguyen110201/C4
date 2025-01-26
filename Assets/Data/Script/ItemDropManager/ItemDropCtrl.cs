using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected InventoryEnum inventoryEnum = InventoryEnum.Items;
    public InventoryEnum InventoryEnum => inventoryEnum;

    [SerializeField] protected ItemEnum itemEnum;
    public ItemEnum ItemEnum => itemEnum;
    [SerializeField] protected int itemCount = 1;
    public int ItemCount => itemCount;
    [SerializeField] protected Rigidbody rigi;
    public Rigidbody Rigi => rigi;
    public override string GetName()
    {
        throw new System.NotImplementedException();
    }

    public virtual void SetValue(ItemEnum itemEnum, int itemCount) 
    {
        this.itemEnum = itemEnum;
        this.itemCount = itemCount;
    }
    public virtual void SetValue(ItemEnum itemEnum, int itemCount,InventoryEnum inventoryEnum)
    {
        this.itemEnum = itemEnum;
        this.itemCount = itemCount;
        this.inventoryEnum = inventoryEnum;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropSpawner();
    }

    protected virtual void LoadItemDropSpawner()
    {
        if (this.rigi != null) return;
        this.rigi = transform.GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": Load ItemDropSpawner");
    }

   

}
