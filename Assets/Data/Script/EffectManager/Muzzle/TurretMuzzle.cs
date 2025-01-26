using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMuzzle : MuzzleAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectEnum = EffectEnum.TurretMuzzle;
    }
}
