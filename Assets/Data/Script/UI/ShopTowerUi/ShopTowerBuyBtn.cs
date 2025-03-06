using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopTowerBuyBtn : ButtonAbstract
{
    [SerializeField] protected ShopTowerBtn shopTowerBtn;
    [SerializeField] protected TextMeshProUGUI towerPrice;
    [SerializeField] protected Image towerPriceIMG;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerPrice();
    }

    protected virtual void LoadTowerPrice()
    {
        if (this.towerPrice != null && this.towerPriceIMG != null) return;
        this.towerPrice = transform.Find("TowerPrice").GetComponent<TextMeshProUGUI>();
        this.towerPriceIMG = transform.Find("TowerPriceIMG").GetComponent<Image>();
        this.shopTowerBtn = transform.GetComponentInParent<ShopTowerBtn>(true);
        Debug.Log(transform.name + ": Load TowerPrice", gameObject);
    }
 
    public virtual void SetTowerPrice(TowerBuyProfileSO towerBuyProfileSO) 
    {
        this.towerPrice.text = towerBuyProfileSO.itemPrice.ToString();
        this.towerPriceIMG.sprite = towerBuyProfileSO.itemProfileSO.itemSprite;
    }
   
    protected override void OnClick()
    {
        this.shopTowerBtn.BuyItem();
    }
}
