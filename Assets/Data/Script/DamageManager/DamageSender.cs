using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : LoadComPonentsManager
{
    [SerializeField] protected int damage = 1;
    protected virtual void OnTriggerEnter(Collider collider) 
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        
    
    }
    public virtual void Send(DamageReceiver damageReceiver) 
    {
        damageReceiver.Deduct(this.damage);
    }

    public virtual void SetDamage(int damage ) => this.damage = damage;
}
