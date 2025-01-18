using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : LoadComPonentsManager
{
    [SerializeField] protected int damage = 1;

    public virtual void OnTriggerEnter(Collider collider) 
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    protected virtual void Send(DamageReceiver damageReceiver) 
    {
        damageReceiver.Deduct(this.damage);
    }

}
