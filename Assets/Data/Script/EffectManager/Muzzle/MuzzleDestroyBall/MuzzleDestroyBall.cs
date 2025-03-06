using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleDestroyBall : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.Damage;
        this.effectEnum = EffectEnum.MuzzleDestroyBall;
        this.statusType = StatusType.None;
    }
}
