using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerProfileToggleBtn : ButtonAbstract
{
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText() 
    {
        if (this.text != null) return;
        this.text = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(transform.name + ": Load Text", gameObject);
    }
    protected override void OnClick()
    {
        TowerProfileUI.Instance.Toogle();
    }

    protected virtual void HotKeyToggleTowerShop()
    {
        if (InputHotkeys.Instance.isInputKeyQ) TowerProfileUI.Instance.Toogle();
    }
    public virtual void SetText(string Text) =>  this.text.text = Text;  
   
       
    
}
