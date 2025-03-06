using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatusEffect : StatusEffect<EnemyCtrl>
{
    protected override void OnEffectEnd()
    {
        this.timeLife = 0;
        this.currentTime = 0;
        this.effectValue = 0;
        this.parent.EnemyStatusManager.ResetStatus();
        this.StopEffectCoroutine();
    }

}
