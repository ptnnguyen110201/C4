using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : Singleton<SettingUI>
{
    protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected ShowHideUI showHide;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.GetComponentInChildren<ShowHideUI>();
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
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
}