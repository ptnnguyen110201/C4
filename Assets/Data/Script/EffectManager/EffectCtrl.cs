using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : PoolObj
{
    [SerializeField] protected EffectEnum effectEnum;
    public override string GetName() => this.effectEnum.ToString();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.SetNameByEnum();
    }
    protected virtual void SetNameByEnum()
    {
        if (this.effectEnum == EffectEnum.None) return;
        this.transform.name = this.effectEnum.ToString();
        Debug.Log(transform.name + " Set NameByEnum ", gameObject);
    }
}
