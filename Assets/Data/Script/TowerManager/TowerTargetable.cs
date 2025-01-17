using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(SphereCollider))]
public class TowerTargetable : LoadComPonentsManager
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
        this.sphereCollider.radius = 0.5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }
}
