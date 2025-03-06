using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleLaser : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectType = EffectType.Damage;
        this.effectEnum = EffectEnum.MuzzleLaser;
        this.statusType = StatusType.Stun;
    }
}
