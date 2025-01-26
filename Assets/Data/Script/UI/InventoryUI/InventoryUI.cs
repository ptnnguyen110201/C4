using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;
    [SerializeField] protected Transform showHide;
    [SerializeField] protected InventoryItemBtn InventoryItemBtn;
    [SerializeField] protected List<InventoryItemBtn> InventoryItemBtns;
    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }

    protected override void Start()
    {
        base.Start();
        this.Show();
        this.HideDefaultInventoryItem();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryItemBtn();
        this.LoadShowHiden();
    }
    protected virtual void LoadInventoryItemBtn()
    {
        if (this.InventoryItemBtn != null) return;
        this.InventoryItemBtn = transform.GetComponentInChildren<InventoryItemBtn>();
        Debug.Log(transform.name + ": Load InventoryItemBtn", gameObject);
    }
    protected virtual void LoadShowHiden()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide").GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadShowHiden", gameObject);
    }
    protected virtual void HideDefaultInventoryItem()
    {
        this.InventoryItemBtn.gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        showHide.gameObject.SetActive(true);
        this.isShow = true;
    }
    public virtual void Hide()
    {
        showHide.gameObject.SetActive(false);
        this.isShow = false;
    }
    public virtual void Tooggle()
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
        foreach(InventoryItemBtn itemBtn in this.InventoryItemBtns) 
        {
            if (itemBtn.ItemInventory.itemID == itemInventory.itemID) return itemBtn;
        }
        return null;
    }

    protected virtual void HotkeyToogleInventory() 
    {
        if (InputHotkeys.Instance.IsToogleInventoryUI) this.Tooggle();
    }
}
