using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    [SerializeField] protected string effectName = "Fire1";
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        AttackPoint attackPoint = this.GetAttackPoint();

        EffectCtrl effect = this.effectSpawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        EffectFlyAbstract effectFly =(EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);

    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.effectPrefabs.GetPrefabByName(this.effectName);
    }

}
