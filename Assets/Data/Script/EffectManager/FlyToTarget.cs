using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : GenericMove<EffectCtrl>
{
    [SerializeField] protected Transform target;

    protected virtual void Update()
    {
        this.Moving();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
        transform.parent.LookAt(target);
    }
    protected override void Moving()
    {
        if (this.target == null) return;
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
}
