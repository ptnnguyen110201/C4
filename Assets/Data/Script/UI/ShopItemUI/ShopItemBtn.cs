using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBtn : ButtonAbstract 
{
    [SerializeField] protected ShopItemProfileSO shopItemProfileSO; 
    public ShopItemProfileSO ShopItemProfileSO => shopItemProfileSO;
    [SerializeField] protected Image ItemImage;
    [SerializeField] protected TextMeshProUGUI itemCount;
    [SerializeField] protected ShopItemBuyBtn shopItemBuyBtn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemText();
    }

    protected virtual void LoadItemText()
    {
        if (this.ItemImage != null && this.itemCount != null) return;
        this.ItemImage = transform.Find("ItemImage").GetComponent<Image>();
        this.itemCount = transform.Find("itemCount").GetComponent<TextMeshProUGUI>();
        this.shopItemBuyBtn = transform.GetComponentInChildren<ShopItemBuyBtn>(true);
        Debug.Log(transform.name + ": Load Text", gameObject);
    }

    public virtual void ItemShow(ShopItemProfileSO shopItemProfileSO) 
    {
        this.shopItemProfileSO = shopItemProfileSO;
        if (shopItemProfileSO.Count == 0) 
        {
            Destroy(this.gameObject);
            return;
        }
        this.ItemImage.sprite = this.shopItemProfileSO.ItemProfileSO.itemSprite;
        this.itemCount.text = this.shopItemProfileSO.Count.ToString();
        this.shopItemBuyBtn.SetItemPrice(shopItemProfileSO);
    }
    public virtual bool BuyItem() 
    {
        if (this.shopItemProfileSO == null) return false;
        if (this.shopItemProfileSO.Count <= 0) return false;
        bool isBuy = ShopItemManager.Instance.BuyItem(this.shopItemProfileSO);
        return isBuy;
    }
    protected override void OnClick()
    {

    }
}
