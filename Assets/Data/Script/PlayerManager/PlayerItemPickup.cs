using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class PlayerItemPickup : PlayerAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
  
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider) 
    {
        if (collider.transform.parent == null) return;
        ItemDropCtrl itemDropCtrl = collider.transform.parent.GetComponent<ItemDropCtrl>();    
        if (itemDropCtrl == null) return;
        itemDropCtrl.DespawnBase.DespawnObj();
    }
}
