using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBleedEffect : EnemyStatusEffect
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusType = StatusType.Bleed;
    }
    protected override IEnumerator PlayeEffectCoroutine()
    {
        if (this.parent == null) yield break;

        while (this.currentTime > 0)
        {
            if (this.parent.EnemyDamageReceiver.IsDead()) break;
            else
            {
                yield return new WaitForSeconds(1);
                this.OnEffectStart();
                this.currentTime -= 1;

            }

        }
        this.OnEffectEnd();
        yield break;
    }
    protected override void OnEffectStart()
    {
        base.OnEffectStart();
        float maxHp = this.parent.EnemyDamageReceiver.MaxHp;
        int deductHp = (int)((maxHp * this.effectValue) / 100);
        this.parent.EnemyDamageReceiver.Deduct(deductHp);
    }
}
