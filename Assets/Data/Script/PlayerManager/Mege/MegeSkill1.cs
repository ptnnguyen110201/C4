using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegeSkill1 : MegeAttack
{
    protected override bool CheckSkillCondition() => true;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.coolDownTime = 5f;
        this.coolDownTimer = 5f;  
        this.ischargeTime = 2f;
        this.isChargEnum = EffectEnum.MuzzleMegeCharging;
        this.skillEffect = EffectEnum.MuzzleDestroyBall;  
        this.skillEnum = SkillEnum.Skill1;

       
    }
    protected override void SpawnEffect()
    {
        List<EnemyCtrl> enemyList = EnemyManagerCtrl.Instance.EnemySpawning.Enemies;
        if (enemyList.Count <= 0) return;
        EffectCtrl effectCtrl = EffectManagerCtrl.Instance.EffectPrefabs.GetPrefabByName(this.skillEffect.ToString());
        foreach (EnemyCtrl enemy in enemyList) 
        {
            EffectCtrl newEffect = EffectManagerCtrl.Instance.EffectSpawner.Spawn(effectCtrl, enemy.transform.position);
            newEffect.EffectFlyTarget.SetTarget(enemy.transform);
            newEffect.gameObject.SetActive(true);
        }

    }
}
