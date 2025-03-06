using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleLaserDespawn : EffectDespawn
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLife = 4;
        this.currentTime = 4;
    }
}
