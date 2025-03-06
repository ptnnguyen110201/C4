using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleMegeCharging : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.NoDamage;
        this.effectEnum = EffectEnum.MuzzleMegeCharging;
    }
}
