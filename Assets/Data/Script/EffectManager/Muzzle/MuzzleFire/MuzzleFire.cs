using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFire : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.Damage;
        this.effectEnum = EffectEnum.MuzzleFire;
        this.statusType = StatusType.Bleed;
    }
}
