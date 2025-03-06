using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFlyTarget : GenericMove<EffectCtrl>
{
    [SerializeField] protected Transform target;

    protected virtual void Update()
    {
        this.Moving();
    }
    public virtual void SetTarget(Transform target) =>  this.target = target;
    
      
      
    
    protected override void Moving()
    {
        if (this.target == null) return;
        transform.parent.position = this.target.position;
    }
}
