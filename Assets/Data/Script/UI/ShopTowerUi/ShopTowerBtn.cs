using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopTowerBtn : ButtonAbstract
{
    [SerializeField] protected TowerBuyProfileSO towerBuyProfile; 
    public TowerBuyProfileSO TowerBuyProfileSO => towerBuyProfile;
    [SerializeField] protected Image towerImage;
    [SerializeField] protected ShopTowerBuyBtn shopTowerBuyBtn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerText();
    }

    protected virtual void LoadTowerText()
    {
        if (this.towerImage != null) return;
        this.towerImage = transform.Find("TowerImage").GetComponent<Image>();
        this.shopTowerBuyBtn = transform.GetComponentInChildren<ShopTowerBuyBtn>(true);
        Debug.Log(transform.name + ": Load Text", gameObject);
    }

    public virtual void ItemShow(TowerBuyProfileSO towerBuyProfileSO) 
    {
        this.towerBuyProfile = towerBuyProfileSO;
        this.towerImage.sprite = towerBuyProfileSO.towerProfileSO.towerSprite;
        this.shopTowerBuyBtn.SetTowerPrice(towerBuyProfileSO);
    }

    public virtual bool BuyItem()
    {
        if (this.towerBuyProfile == null) return false;
        bool isBuy = TowerManagerCtrl.Instance.TowerShopManager.BuyTower(this.towerBuyProfile);
        return isBuy;
    }
    protected override void OnClick()
    {

    }
}
