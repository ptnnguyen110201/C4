using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAbstract : LoadComPonentsManager
{
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = transform.GetComponent<Button>();
        Debug.Log(transform.name + ": Load Button", gameObject);
    }
    protected virtual void AddOnClickEvent() 
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
