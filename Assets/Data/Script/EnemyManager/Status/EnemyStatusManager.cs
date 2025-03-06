using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusManager : StatusManager<EnemyStatusEffect>
{
    public virtual void SetT(StatusType statusType, float duration, double effectValue)
    {
        if (this.currentStatusEffect != null)
        {
            if (this.currentStatusEffect.StatusType == statusType)
            {
                this.currentStatusEffect.ApplyEffect(statusType, duration, effectValue);
                return;
            }
            if (this.currentStatusEffect.StatusType != statusType) return;
        }

        foreach (EnemyStatusEffect effect in this.stateList)
        {
            if (effect.StatusType == statusType)
            {
                this.currentStatusEffect = effect;
                this.currentStatusEffect.ApplyEffect(statusType, duration, effectValue);
                return;
            }
        }
    }
   
}
