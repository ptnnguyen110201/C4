using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTowerUI : Singleton<ShopTowerUI>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;
    [SerializeField] protected ShowHideUI showHide;
    [SerializeField] protected ShopTowerBtn shopTowerBtn;
    [SerializeField] protected List<ShopTowerBtn> shopTowerBtns;
    [SerializeField] protected ShopTowerToggleBtn shopTowerToggleBtn;
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
        if (this.shopTowerBtn != null) return;
        this.shopTowerBtn = transform.GetComponentInChildren<ShopTowerBtn>(true);
        this.shopTowerToggleBtn = transform.GetComponentInChildren<ShopTowerToggleBtn>(true);
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
        this.shopTowerBtn.gameObject.SetActive(false);
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
        List<TowerBuyProfileSO> towerProfileSOs = TowerManagerCtrl.Instance.TowerShopManager.GetTowerBuyProfileSOs();
        foreach (TowerBuyProfileSO towerProfileSO in towerProfileSOs)
        {
            ShopTowerBtn newTowerUI = this.GetExistItem(towerProfileSO);
            if (newTowerUI == null)
            {
                newTowerUI = Instantiate(this.shopTowerBtn);
                newTowerUI.transform.SetParent(this.shopTowerBtn.transform.parent);
                newTowerUI.ItemShow(towerProfileSO);
                newTowerUI.transform.localScale = Vector3.one;
                newTowerUI.gameObject.SetActive(true);
                this.shopTowerBtns.Add(newTowerUI);
            }

        }
    }
    protected virtual ShopTowerBtn GetExistItem(TowerBuyProfileSO towerBuyProfileSO)
    {
        foreach (ShopTowerBtn itemBtn in this.shopTowerBtns)
        {
            if (itemBtn.TowerBuyProfileSO == towerBuyProfileSO) return itemBtn;
        }
        return null;
    }

    public virtual void OpenShop(TowerPoint towerPoint)
    {
        this.isShow = towerPoint != null;
        this.Toogle();
    }
    public virtual void OpenBtn(string text)
    {
        this.shopTowerToggleBtn.gameObject.SetActive(true);
        this.shopTowerToggleBtn.SetText(text);
    }


    public virtual void CloseBtn(string text)
    {
        this.shopTowerToggleBtn.gameObject.SetActive(false);
        this.shopTowerToggleBtn.SetText(text);
    }
}
