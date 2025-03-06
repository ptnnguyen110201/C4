using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemManager : Singleton<ShopItemManager>
{
    [SerializeField] protected List<ShopItemProfileSO> shopItemProfileSOs;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShopItemProfiles();
    }

    protected virtual void LoadShopItemProfiles()
    {
        if (this.shopItemProfileSOs.Count > 0) return;
        ShopItemProfileSO[] itemProfileSOs = Resources.LoadAll<ShopItemProfileSO>("/");
        this.shopItemProfileSOs = new List<ShopItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + " Load ItemProfiles", gameObject);
    }

    public virtual bool BuyItem(ShopItemProfileSO shopItemProfileSO)
    {
        InventoryCtrl currencyInventory = InventoryManager.Instance.Currencies(); 

        InventoryCtrl itemInventory = InventoryManager.Instance.Items();

        if (currencyInventory == null || itemInventory == null) return false;

        ItemInventory playerCurrency = currencyInventory.FindItem(ItemEnum.Gold);
        if (playerCurrency == null || playerCurrency.itemCount < shopItemProfileSO.shopItemBuyProfileSO.itemPrice) return false;

         bool deducted = currencyInventory.RemoveItem(new ItemInventory
         {
             itemProfileSO = playerCurrency.itemProfileSO,
             itemCount = shopItemProfileSO.shopItemBuyProfileSO.itemPrice
         });

         if (!deducted) return false;
        
        ItemInventory newItem = new ItemInventory
        {
            itemProfileSO = shopItemProfileSO.ItemProfileSO,
            itemCount = shopItemProfileSO.Count,
        };

        itemInventory.AddItem(newItem);
        return true;

    }
    public virtual List<ShopItemProfileSO> GetShopItemProfileSOs() => this.shopItemProfileSOs;
}
