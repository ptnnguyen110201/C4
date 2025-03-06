using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;

    [SerializeField] protected ShowHideUI showHide; 
    [SerializeField] protected InventoryItemShowHide inventoryItemShowHide;
    [SerializeField] protected InventoryItemBtn InventoryItemBtn;
    [SerializeField] protected List<InventoryItemBtn> InventoryItemBtns;
    protected virtual void LateUpdate()
    {
        this.ItemUpdating();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryItemBtn(); 
        this.LoadInventoryItemShowHide();
        this.LoadShowHiden();
    }
    protected virtual void LoadInventoryItemBtn()
    {
        if (this.InventoryItemBtn != null) return;
        this.InventoryItemBtn = transform.GetComponentInChildren<InventoryItemBtn>(true);
        Debug.Log(transform.name + ": Load InventoryItemBtn", gameObject);
    }
    protected virtual void LoadInventoryItemShowHide()
    {
        if (this.inventoryItemShowHide != null) return;
        this.inventoryItemShowHide = transform.GetComponentInChildren<InventoryItemShowHide>(true);
        Debug.Log(transform.name + ": Load InventoryItemShowHide", gameObject);
    }
    protected virtual void LoadShowHiden()
    {
        if (this.showHide != null) return;
        this.showHide = transform.GetComponentInChildren<ShowHideUI>();
        Debug.Log(transform.name + ": LoadShowHiden", gameObject);
    }
    protected virtual void HideDefaultInventoryItem()
    {
        this.inventoryItemShowHide.gameObject.SetActive(false);
        this.InventoryItemBtn.gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        this.isShow = true;
        UIManager.Instance.ToggleUI(this.showHide);
    }
    public virtual void Hide()
    {
        this.isShow = false;
        this.HideDefaultInventoryItem();
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
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.Items();
        foreach (ItemInventory itemInventory in inventoryCtrl.Items)
        {
            InventoryItemBtn newItemUI = this.GetExistItem(itemInventory);
            if (newItemUI == null)
            {
                newItemUI = Instantiate(this.InventoryItemBtn);
                newItemUI.transform.SetParent(this.InventoryItemBtn.transform.parent);
                newItemUI.SetItemInventory(itemInventory);
                newItemUI.transform.localScale = Vector3.one;
                newItemUI.gameObject.SetActive(true);
                newItemUI.name = itemInventory.itemProfileSO.name + "-" + itemInventory.itemID;
                this.InventoryItemBtns.Add(newItemUI);
            }

        }
    }


    protected virtual InventoryItemBtn GetExistItem(ItemInventory itemInventory)
    {
        foreach (InventoryItemBtn itemBtn in this.InventoryItemBtns)
        {
            if (itemBtn.ItemInventory.itemID == itemInventory.itemID) return itemBtn;
        }
        return null;
    }

    public virtual void OpenItemShowHide(ItemInventory itemInventory)
    {
        if (itemInventory == null || itemInventory.itemCount == 0) return;
        this.inventoryItemShowHide.SetItemInventory(itemInventory);
        this.inventoryItemShowHide.gameObject.SetActive(true);
    }

}
