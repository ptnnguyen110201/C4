using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleHit : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.NoDamage;
        this.effectEnum = EffectEnum.MuzzleHit;
    }
}
