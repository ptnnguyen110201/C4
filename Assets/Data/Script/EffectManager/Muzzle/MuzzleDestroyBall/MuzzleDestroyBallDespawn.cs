using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleDestroyBallDespawn : EffectDespawn
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLife = 1.3f;
        this.currentTime = 1.3f;
    }
}
