using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManager : Singleton<ItemsDropManager>
{
    [SerializeField] protected ItemDropSpanwer itemDropSpanwer;
    public ItemDropSpanwer ItemDropSpanwer => itemDropSpanwer;

    [SerializeField] protected float spawnHeight = 1;
    [SerializeField] protected float forceAmount = 5;
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
        Vector3 Pos = DropPos + new Vector3(Random.Range(-2, 2), this.spawnHeight, Random.Range(-2, 2));
        ItemDropCtrl itemPrefab = this.itemDropSpanwer.PoolPrefabs.GetPrefabByName(itemEnum.ToString());
        ItemDropCtrl newItem = this.itemDropSpanwer.Spawn(itemPrefab, Pos);
        newItem.SetValue(itemEnum, dropCount, inventoryEnum);

        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rigi.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
    }

}
