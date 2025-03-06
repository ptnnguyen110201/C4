using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleSnow : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.Damage;
        this.effectEnum = EffectEnum.MuzzleSnow;
        this.statusType = StatusType.Slow;
    }
}
