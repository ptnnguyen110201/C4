using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegeSkill4 : MegeAttack
{
    protected override bool CheckSkillCondition() => true;


    protected override void ResetValue()
    {
        base.ResetValue();
        this.coolDownTime = 15f;
        this.coolDownTimer = 15f;
        this.ischargeTime = 3f;
        this.isChargEnum = EffectEnum.MuzzleMegeCharging;
        this.skillEffect = EffectEnum.MuzzleLaser;  
        this.skillEnum = SkillEnum.Skill4;
       
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
