using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPointCollider : LoadComPonentsManager
{
    [SerializeField] protected TowerPoint towerPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerPoint();
    }

    protected virtual void LoadTowerPoint()
    {
        if (this.towerPoint != null) return;
        this.towerPoint = transform.GetComponentInParent<TowerPoint>();
        Debug.Log(transform.name + ":Load TowerPoint", gameObject);
    }
    protected virtual string SetText()
    {
        if (!this.towerPoint.IsPutted && this.towerPoint.IsFixed) return "Put Tower (Q)";
        if (!this.towerPoint.IsPutted && !this.towerPoint.IsFixed) return "Open Shop (Q)";
        if (this.towerPoint.IsPutted) return "View Tower (Q)";
        return string.Empty;


    }

    protected virtual void OpenButton() 
    {
        if (!this.towerPoint.IsPutted)
        {
            ShopTowerUI.Instance.OpenBtn(this.SetText());
            TowerProfileUI.Instance.CloseBtn(this.SetText());
            return;
        }
        ShopTowerUI.Instance.CloseBtn(this.SetText());
        TowerProfileUI.Instance.OpenBtn(this.SetText());
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent == null) return;
        PlayerCtrl playerCtrl = collider.transform.parent.GetComponent<PlayerCtrl>();
        if (playerCtrl == null) return;
        this.OpenButton();

    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.transform.parent == null) return;
        PlayerCtrl playerCtrl = collider.transform.parent.GetComponent<PlayerCtrl>();
        if (playerCtrl == null) return;
        ShopTowerUI.Instance.CloseBtn(this.SetText());
        TowerProfileUI.Instance.CloseBtn(this.SetText());
    }
}
