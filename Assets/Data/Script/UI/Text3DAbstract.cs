using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Text3DAbstract : LoadComPonentsManager
{
    [SerializeField] protected TextMeshPro text;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        if (this.text != null) return;
        this.text = transform.GetComponent<TextMeshPro>();
        Debug.Log(transform.name + ": Load TextMeshPro", gameObject);
    }

}
