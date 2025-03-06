using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulletDamagerSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigiBody;


    public override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.SetShooter(this.bulletCtrl.Shooter.transform);
        base.Send(damageReceiver);
        this.Despawn();
    }
    protected virtual void Despawn() 
    {
        this.bulletCtrl.DespawnBase.DespawnObj();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletCtrl>();
        Debug.Log(transform.name + ": Load BulletCtrl", gameObject);
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
