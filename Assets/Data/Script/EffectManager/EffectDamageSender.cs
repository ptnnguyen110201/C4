using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class EffectDamageSender : DamageSender
{
    [SerializeField] protected EffectCtrl effectCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigiBody;


    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.Despawn();
    }
    protected virtual void Despawn()
    {
        this.effectCtrl.DespawnBase.DespawnObj();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectCtrl();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.GetComponentInParent<EffectCtrl>(true);
        Debug.Log(transform.name + ": Load EffectCtrl", gameObject);
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigiBody != null) return;
        this.rigiBody = transform.GetComponent<Rigidbody>();
        this.rigiBody.useGravity = false;
        Debug.Log(transform.name + ":Load Rigidbody", gameObject);
    }

}
