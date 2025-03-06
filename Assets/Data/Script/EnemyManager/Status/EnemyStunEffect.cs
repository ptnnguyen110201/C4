using System.Collections;
using UnityEngine;

public class EnemyStunEffect : EnemyStatusEffect
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusType = StatusType.Stun;
    }

    protected override IEnumerator PlayeEffectCoroutine()
    {
        if (this.parent == null || this.parent.EnemyDamageReceiver.IsDead()) yield break;

        this.OnEffectStart();

        while (this.currentTime > 0)
        {
            if (this.parent.EnemyDamageReceiver.IsDead()) break;
            else
            {
                this.currentTime -= Time.deltaTime;
                yield return null;
            }


        }

        this.OnEffectEnd();
        yield break;
    }

    protected override void OnEffectStart()
    {
        base.OnEffectStart();
        this.parent.EnemyMove.SetCanMove(false);
    }

    protected override void OnEffectEnd()
    {
        this.parent.EnemyMove.SetCanMove(true);
        base.OnEffectEnd();
    }
}
