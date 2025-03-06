using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShopManager : LoadComPonentsManager
{
    [SerializeField] protected List<TowerBuyProfileSO> towerBuyProfileSOs;
    [SerializeField] protected float puttingDelayTimer = 3;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerProfileSOs();
    }

    protected virtual void LoadTowerProfileSOs()
    {
        if (this.towerBuyProfileSOs.Count > 0) return;
        TowerBuyProfileSO[] itemProfileSOs = Resources.LoadAll<TowerBuyProfileSO>("/");
        this.towerBuyProfileSOs = new List<TowerBuyProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + " Load TowerProfileSOs", gameObject);
    }

    public virtual bool BuyTower(TowerBuyProfileSO towerBuyProfileSO)
    {
        InventoryCtrl currencyInventory = InventoryManager.Instance.Currencies();
        if (currencyInventory == null) return false;

        ItemInventory playerCurrency = currencyInventory.FindItem(ItemEnum.Gold);
        if (playerCurrency == null) return false;
        if (playerCurrency.itemProfileSO != towerBuyProfileSO.itemProfileSO) return false;

        bool deducted = currencyInventory.RemoveItem(new ItemInventory
        {
            itemProfileSO = playerCurrency.itemProfileSO,
            itemCount = towerBuyProfileSO.itemPrice
        });

        if (!deducted) return false;

        this.CloseShop();
        this.SpawnTower(towerBuyProfileSO.towerProfileSO);

        return true;
    }

    public virtual void SpawnTower(TowerProfileSO towerProfileSO)
    {
        TowerPoint towerPoint = PlayerManagerCtrl.Instance.CurrentPlayer.PlayerTowerPutting.TowerPoint;
        if (towerPoint == null) return;
        towerPoint.SetProfile(towerProfileSO);
        towerPoint.PuttingTower();
    }

    protected virtual void CloseShop() => ShopTowerUI.Instance.Toogle();

    public virtual List<TowerBuyProfileSO> GetTowerBuyProfileSOs() => this.towerBuyProfileSOs;
}
