using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextAbstract : LoadComPonentsManager
{
    [SerializeField] protected TextMeshProUGUI goldText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGoldText();
    }

    protected virtual void LoadGoldText() 
    {
        if (this.goldText != null) return;
        this.goldText = transform.GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": Load GoldText", gameObject);
    }

}
