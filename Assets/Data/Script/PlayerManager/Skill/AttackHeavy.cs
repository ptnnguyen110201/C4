using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 0.1f;
    [SerializeField] protected string effectName = "Fire2";
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) 
        {  
   
            return; 
        }

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        AttackPoint attackPoint = this.GetAttackPoint();
        EffectCtrl effect = this.effectSpawner.Spawn(this.GetEffect(),attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);
    }
    protected virtual EffectCtrl GetEffect()
    {
        return this.effectPrefabs.GetPrefabByName(this.effectName);
    }


}
