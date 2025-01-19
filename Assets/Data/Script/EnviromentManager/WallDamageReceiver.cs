using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class WallDamageReceiver : DamageReceiver
{
    [SerializeField] protected BoxCollider BoxCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }


    protected virtual void LoadBoxCollider()
    {
        if (this.BoxCollider != null) return;
        this.BoxCollider = transform.GetComponent<BoxCollider>();
        this.BoxCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load BoxCollider", gameObject);
    }
    protected override void ResetValue()
    {
        this.isImmotal = true;
        base.ResetValue();

    }
}
