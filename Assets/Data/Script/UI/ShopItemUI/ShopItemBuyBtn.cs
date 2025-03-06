using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBuyBtn : ButtonAbstract
{
    [SerializeField] protected ShopItemBtn shopItemBtn;
    [SerializeField] protected TextMeshProUGUI itemPrice;
    [SerializeField] protected Image itemPriceIMG;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemPrice();
    }

    protected virtual void LoadItemPrice()
    {
        if (this.itemPrice != null) return;
        this.itemPrice = transform.Find("itemPrice").GetComponent<TextMeshProUGUI>();
        this.itemPriceIMG = transform.Find("itemPriceIMG").GetComponent<Image>();
        this.shopItemBtn = transform.GetComponentInParent<ShopItemBtn>(true);
        Debug.Log(transform.name + ": Load ItemPrice", gameObject);
    }

    public virtual void SetItemPrice(ShopItemProfileSO shopItemProfileSO)
    {
        this.itemPrice.text = shopItemProfileSO.shopItemBuyProfileSO.itemPrice.ToString();
        this.itemPriceIMG.sprite = shopItemProfileSO.shopItemBuyProfileSO.ItemProfileSO.itemSprite;
    }

    protected override void OnClick()
    {
        this.shopItemBtn.BuyItem();
    }
}
