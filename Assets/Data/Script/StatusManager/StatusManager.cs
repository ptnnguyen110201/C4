using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusManager<T> : LoadComPonentsManager where T : MonoBehaviour
{
    [SerializeField] protected List<T> stateList;
    [SerializeField] protected T currentStatusEffect;
    public T CurrentStatusEffect => currentStatusEffect;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStatusEffect();
    }


    public virtual void ResetStatus() => this.currentStatusEffect = null;
 

    protected virtual void LoadStatusEffect()
    {
        if (this.stateList.Count > 0) return;

        foreach (Transform child in transform)
        {
            T status = child.GetComponent<T>(); 
            if (status == null) continue;
            this.stateList.Add(status);
        }

        Debug.Log(transform.name + " Load StatusEffect", gameObject);
    }

 
}
