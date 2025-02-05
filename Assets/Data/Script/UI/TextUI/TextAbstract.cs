using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextAbstract : LoadComPonentsManager
{
    [SerializeField] protected TextMeshProUGUI text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshProUGUI();
    }

    protected virtual void LoadTextMeshProUGUI() 
    {
        if (this.text != null) return;
        this.text = transform.GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ":Load TextMeshProUGUI", gameObject);
    }

}
