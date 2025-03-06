using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : PoolObj
{
    [SerializeField] protected EffectType effectType;
    public EffectType EffectType => effectType;
    [SerializeField] protected EffectEnum effectEnum;
    public EffectEnum EffectEnum => effectEnum;
    [SerializeField] protected StatusType statusType;
    public StatusType StatusType => statusType;

    [SerializeField] protected EffectFlyTarget effectFlyTarget;
    public EffectFlyTarget EffectFlyTarget => effectFlyTarget;
    [SerializeField] protected EffectDamageSender effectDamageSender;
    public EffectDamageSender EffectDamageSender => effectDamageSender;

    public override string GetName() => this.effectEnum.ToString();

    protected override void LoadComponents()
    {
        base.LoadComponents();
   
        this.LoadEffectDamageSender();
        this.LoadFlyToTarget();
        this.SetNameByEnum();
    }
    protected virtual void LoadEffectDamageSender() 
    {
        if (this.effectDamageSender != null) return;
        this.effectDamageSender = transform.GetComponentInChildren<EffectDamageSender>(true);
        Debug.Log(transform.name + ": Load EffectDamageSender ", gameObject);
    }
    protected virtual void LoadFlyToTarget()
    {
        if (this.effectFlyTarget != null) return;
        this.effectFlyTarget = transform.GetComponentInChildren<EffectFlyTarget>(true);
        Debug.Log(transform.name + ": Load FlyToTarget", gameObject);
    }
    protected virtual void SetNameByEnum()
    {
        if (this.effectEnum.ToString() == this.transform.name) return;
        this.transform.name = this.effectEnum.ToString();
        Debug.Log(transform.name + ": Set NameByEnum ", gameObject);
    }
}
