using System.Collections.Generic;
using UnityEngine;

public class LevelAbstractTest : TowerAbstract
{
    [SerializeField] protected int currentLevel = 1;
    [SerializeField] protected int maxLevel;
    [SerializeField] protected List<TowerItemUpgrade> currentExp = new();
    [SerializeField] protected List<TowerItemUpgrade> nextLevelExp = new();
    protected virtual void LateUpdate()
    {
        this.GetCurrentExp();
        this.GetNextLevel();

        this.Leveling();
    }
    protected virtual void Leveling()
    {
        if(DeductItemsFromCurrentExp()) this.currentLevel++;
        
    }
    protected virtual List<TowerItemUpgrade> GetNextLevel() => this.nextLevelExp = towerCtrl.TowerProfileSO.GetTowerItemUpgrades(this.currentLevel);
    protected virtual List<TowerItemUpgrade> GetCurrentExp()
    {
        List<TowerItemUpgrade> nextLevelRequirements = this.GetNextLevel();
        if (nextLevelRequirements == null || nextLevelRequirements.Count == 0) return null;

        this.currentExp.Clear();

        InventoryCtrl currencies = InventoryManager.Instance.Currencies();

        foreach (ItemInventory itemInventory in currencies.Items)
        {
            TowerItemUpgrade requiredItem = nextLevelRequirements.Find(req => req.ItemProfileSO == itemInventory.itemProfileSO);

            if (requiredItem == null) continue;

            TowerItemUpgrade matchingItem = new TowerItemUpgrade
            {
                ItemProfileSO = itemInventory.itemProfileSO,
                ItemCount = itemInventory.itemCount,
            };
            this.currentExp.Add(matchingItem);
        }
        InventoryCtrl items = InventoryManager.Instance.Items();

        foreach (ItemInventory itemInventory in items.Items)
        {
            TowerItemUpgrade requiredItem = nextLevelRequirements.Find(req => req.ItemProfileSO == itemInventory.itemProfileSO);

            if (requiredItem == null) continue;

            TowerItemUpgrade matchingItem = new TowerItemUpgrade
            {
                ItemProfileSO = itemInventory.itemProfileSO,
                ItemCount = itemInventory.itemCount,
            };
            this.currentExp.Add(matchingItem);
        }
        return this.currentExp;
    }



    protected virtual bool DeductItemsFromCurrentExp()
    {
        foreach (TowerItemUpgrade requiredItem in this.nextLevelExp)
        {
            TowerItemUpgrade ownedItem = this.currentExp.Find(item => item.ItemProfileSO == requiredItem.ItemProfileSO);

            if (ownedItem == null || ownedItem.ItemCount < requiredItem.ItemCount)
            {
                return false; 
            }
        }

        foreach (TowerItemUpgrade requiredItem in this.nextLevelExp)
        {
            TowerItemUpgrade ownedItem = this.currentExp.Find(item => item.ItemProfileSO == requiredItem.ItemProfileSO);
            if (ownedItem != null)
            {
                ownedItem.ItemCount -= requiredItem.ItemCount;
            }
        }

        return true; 
    }


}
