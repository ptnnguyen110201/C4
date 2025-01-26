using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelText<T> : Text3DAbstract where T : MonoBehaviour
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
    protected virtual void FixedUpdate()
    {
        this.UpdatingLevel();
    }
    protected abstract void UpdatingLevel();

}
