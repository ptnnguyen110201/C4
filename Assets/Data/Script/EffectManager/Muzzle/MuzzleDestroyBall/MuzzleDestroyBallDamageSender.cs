using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class MuzzleDestroyBallDamageSender : EffectDamageSender
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusEffectTimer = 0;
        this.statusEffectValue = 0;
    }
    protected override void LoadSphereCollider()
    {
        base.LoadSphereCollider();
        this.sphereCollider.radius = 0.1f;
        this.sphereCollider.center = new Vector3(0, 0.5f, 0);
    }
    protected override void SendEffectStatus(DamageReceiver damageReceiver)
    {
        if (damageReceiver == null) return;

        EnemyCtrl enemyCtrl = damageReceiver.transform.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;

        EnemyStatusManager enemyStatusManager = enemyCtrl.EnemyStatusManager;
        if (enemyStatusManager == null) return;

        EnemyStatusEffect enemyStatusEffect = enemyStatusManager.CurrentStatusEffect;
        if (enemyStatusEffect == null) return;

        StatusType currentStatus = enemyStatusEffect.StatusType;
        float boostTimer = enemyStatusEffect.TimeLife;
        float boostValue = (float)enemyStatusEffect.EffectValue;
        enemyStatusManager.SetT(currentStatus, boostTimer, boostValue);
    }

   
}
