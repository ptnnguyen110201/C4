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

    [SerializeField] protected float statusEffectTimer;
    [SerializeField] protected float statusEffectValue;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    public override void Send(DamageReceiver damageReceiver)
    {
        if (this.effectCtrl.EffectType == EffectType.NoDamage)
        {
            return;
        }
        base.Send(damageReceiver);
        this.SendEffectStatus(damageReceiver);
        this.sphereCollider.enabled = false;
    }

    public virtual void Despawn()
    {
        this.effectCtrl.DespawnBase.DespawnObj();
    }
    protected virtual void SendEffectStatus(DamageReceiver damageReceiver)
    {
        if (damageReceiver == null) return;
        EnemyCtrl enemyCtrl = damageReceiver.transform.GetComponentInParent<EnemyCtrl>();

        if (enemyCtrl == null) return;
        EnemyStatusManager enemyStatusManager = enemyCtrl.EnemyStatusManager;

        if (enemyStatusManager == null) return;
        enemyStatusManager.SetT(this.effectCtrl.StatusType, this.statusEffectTimer, this.statusEffectValue);


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
        Debug.Log(transform.name + ": Load Rigidbody", gameObject);
    }

    protected virtual void Reborn()
    {
        this.sphereCollider.enabled = true;
    }
}
