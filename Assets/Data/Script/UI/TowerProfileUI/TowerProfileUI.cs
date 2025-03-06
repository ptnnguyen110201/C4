using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProfileUI : Singleton<TowerProfileUI>
{
    [SerializeField] protected bool isShow = true;
    public bool IsShow => isShow;
    [SerializeField] protected ShowHideUI showHide;
    [SerializeField] protected TowerProfileToggleBtn towerProfileToggle;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerProfileToggleBtn();
        this.LoadShowHiden();
    }
    protected virtual void LoadTowerProfileToggleBtn()
    {
        if (this.towerProfileToggle != null) return;
        this.towerProfileToggle = transform.GetComponentInChildren<TowerProfileToggleBtn>(true);
        this.HideDefault();
        Debug.Log(transform.name + ": Load TowerProfileToggleBtn", gameObject);
    }
    protected virtual void LoadShowHiden()
    {
        if (this.showHide != null) return;
        this.showHide = transform.GetComponentInChildren<ShowHideUI>();
        Debug.Log(transform.name + ": LoadShowHiden", gameObject);
    }
    protected virtual void HideDefault()
    {
        this.towerProfileToggle.gameObject.SetActive(false);
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


    public virtual void OpenShop(TowerPoint towerPoint)
    {
        this.isShow = towerPoint != null;
        this.Toogle();
    }
    public virtual void OpenBtn(string text)
    {
        this.towerProfileToggle.gameObject.SetActive(true);
        this.towerProfileToggle.SetText(text);
    }


    public virtual void CloseBtn(string text)
    {
        this.towerProfileToggle.gameObject.SetActive(false);
        this.towerProfileToggle.SetText(text);
    }
}
