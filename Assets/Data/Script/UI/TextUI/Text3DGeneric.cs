using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Text3DGeneric<T> : Text3DAbstract where T : MonoBehaviour
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
    protected void LateUpdate()
    {
        this.UpdateText();
    }
    protected abstract void UpdateText();

}
