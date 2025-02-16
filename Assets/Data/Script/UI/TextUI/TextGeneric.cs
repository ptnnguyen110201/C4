using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextGeneric<T> : TextAbstract where T : MonoBehaviour
{
    [SerializeField] protected T parent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl() 
    {
        if (this.parent != null) return;
        this.parent = transform.GetComponentInParent<T>();
        Debug.Log(transform.name + "Load Ctrl", gameObject);
    }
    protected override void OnEnable()
    {
        this.UpdateText();
    }
    protected abstract void UpdateText();

}
