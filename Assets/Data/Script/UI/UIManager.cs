using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] protected List<ShowHideUI> activeUIs = new List<ShowHideUI>();
    [SerializeField] protected ShowHideUI activeUI;
    [SerializeField] protected Transform crosshairPointer;
    [SerializeField] protected bool isHide;

    protected virtual void LateUpdate() 
    {
        this.SetHideMouse();
        this.CloseCurrentUIByKey();
    }
    protected override void Start()
    {
        base.Start();
        this.CloseAllUI();
    }
    protected virtual void CloseAllUI() 
    {
        if (this.activeUIs.Count <= 0) return;
        foreach (ShowHideUI showHideUI in this.activeUIs)
        {
            this.CloseUI(showHideUI);
        }
    }
    protected virtual void CloseCurrentUIByKey() 
    {
        if (!this.isHide) return;
        if (InputHotkeys.Instance.isBack) this.CloseUI(this.activeUI);
    }

    public void ToggleUI(ShowHideUI showHideUI)
    {
        if (showHideUI == this.activeUI) 
        {
            this.CloseUI(showHideUI);
            return;
        }

        if (this.activeUI != null) return;
        this.OpenUI(showHideUI);
    }
    protected void OpenUI(ShowHideUI showHideUI)
    {
        showHideUI.gameObject.SetActive(true);
        this.activeUI = showHideUI;
    }
    protected void CloseUI(ShowHideUI showHideUI)
    {
        showHideUI.gameObject.SetActive(false);
        this.activeUI = null;
    }

    public virtual bool UiIsActive() 
    {
        if(this.activeUIs.Count <= 0 ) return false;
        foreach (ShowHideUI showHideUI in this.activeUIs) 
        {
            if(showHideUI.gameObject.activeSelf) 
                return true;
        }
        return false;
    }
    protected virtual void SetHideMouse()
    {
        this.isHide = this.UiIsActive();
        this.SetCrosshairPointer();
        this.SetCursorVisibility();
    }
    protected virtual void SetCursorVisibility()
    {
        Cursor.visible = this.isHide;
        if (!this.isHide) Cursor.lockState = CursorLockMode.Locked;
        else Cursor.lockState = CursorLockMode.None;
    }
    protected virtual void SetCrosshairPointer() 
    {
        if(this.isHide) this.crosshairPointer.gameObject.SetActive(false);
        else this.crosshairPointer.gameObject.SetActive(true);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadActiveUIs();
        this.LoadcrosshairPointer();

    }
    protected virtual void LoadActiveUIs()
    {
        if (this.activeUIs.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            ShowHideUI showHideUI = obj.transform.GetComponentInChildren<ShowHideUI>(true);
            if (showHideUI == null) continue;
            this.activeUIs.Add(showHideUI);
        }
        Debug.Log(transform.name + ": Load ActiveUIs ", gameObject);
    }

    protected virtual void LoadcrosshairPointer()
    {
        if (this.crosshairPointer != null ) return;
        this.crosshairPointer = transform.Find("CrosshairPointer").GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadCrosshairPointer ", gameObject);
    }

}
