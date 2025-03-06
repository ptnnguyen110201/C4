using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemUI : Singleton<ShopItemUI>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;
    [SerializeField] protected ShowHideUI showHide;
    [SerializeField] protected ShopItemBtn shopItemBtn;
    [SerializeField] protected List<ShopItemBtn> shopItemBtns;
    protected virtual void LateUpdate()
    {
        this.ItemUpdating();

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryItemBtn();
        this.LoadShowHiden();
    }
    protected virtual void LoadInventoryItemBtn()
    {
        if (this.shopItemBtn != null) return;
        this.shopItemBtn = transform.GetComponentInChildren<ShopItemBtn>(true);
        this.HideDefaultInventoryItem();
        Debug.Log(transform.name + ": Load InventoryItemBtn", gameObject);
    }
    protected virtual void LoadShowHiden()
    {
        if (this.showHide != null) return;
        this.showHide = transform.GetComponentInChildren<ShowHideUI>();
        Debug.Log(transform.name + ": LoadShowHiden", gameObject);
    }
    protected virtual void HideDefaultInventoryItem()
    {
        this.shopItemBtn.gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        this.isShow = true;          
        UIManager.Instance.ToggleUI(this.showHide);


    }
    public virtual void Hide()
    {
        this.isShow = false;
        UIManager.Instance.ToggleUI(this.showHide);
    }
    public virtual void Toogle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void ItemUpdating()
    {
        if (!this.isShow) return;
        List<ShopItemProfileSO> shopItemProfileSOs = ShopItemManager.Instance.GetShopItemProfileSOs();
        foreach (ShopItemProfileSO shopItemProfileSO in shopItemProfileSOs)
        {
            ShopItemBtn newItemUI = this.GetExistItem(shopItemProfileSO);
            if (newItemUI == null)
            {
                newItemUI = Instantiate(this.shopItemBtn);
                newItemUI.transform.SetParent(this.shopItemBtn.transform.parent);
                newItemUI.ItemShow(shopItemProfileSO);
                newItemUI.transform.localScale = Vector3.one;
                newItemUI.gameObject.SetActive(true);
                this.shopItemBtns.Add(newItemUI);
            }

        }
    }
    protected virtual ShopItemBtn GetExistItem(ShopItemProfileSO shopItemProfileSO)
    {
        foreach (ShopItemBtn itemBtn in this.shopItemBtns)
        {
            if (itemBtn.ShopItemProfileSO == shopItemProfileSO) return itemBtn;
        }
        return null;
    }


}
