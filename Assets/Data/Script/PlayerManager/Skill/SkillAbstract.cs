using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SkillAbstract : PlayerAbstract
{
    [SerializeField] protected float coolDownTime;
    public float CoolDownTime => coolDownTime;
    [SerializeField] protected float coolDownTimer;
    public float CoolDownTimer => coolDownTimer;
    [SerializeField] protected bool isOnCooldown = false;
    public bool IsOnCooldown => isOnCooldown;
    [SerializeField] protected SkillEnum skillEnum;
    public SkillEnum SkillEnum => skillEnum;

    [SerializeField] protected float ischargeTime;
    [SerializeField] protected bool isCharging = false;  
    [SerializeField] protected EffectCtrl isChargEffect;
    [SerializeField] protected EffectEnum isChargEnum;


    protected Coroutine chargeCoroutine;
    protected Coroutine cooldownCoroutine;
    protected virtual bool CanStartCharging()
    {
        if (this.isOnCooldown) return false;
        if (!this.CheckSkillCondition()) return false;
        return true;
    }
    public void StartCharging()
    {
        if (this.isCharging || !this.CanStartCharging()) return;

        this.isCharging = true;
        SkillUIManager.Instance.StartCharging(this.ischargeTime);
        this.chargeCoroutine = this.StartCoroutine(ChargeSkill());

    }
    public void StopCharging()
    {
        if (!this.isCharging)
        {
            this.StopChargingEffect();
            SkillUIManager.Instance.SkillUIChargingSlider.StopChargingUI();
            return;
        }

        this.isCharging = false;

        if (this.chargeCoroutine != null)
        {
            this.StopCoroutine(this.chargeCoroutine);
            this.chargeCoroutine = null;
        }


    }
    protected virtual IEnumerator ChargeSkill()
    {
        this.StartChargingEffect();
        yield return new WaitForSeconds(this.ischargeTime);
        this.Attacking();
        this.StartCooldown();
        this.StopChargingEffect();

    }

    protected virtual void StartChargingEffect()
    {
        EffectCtrl effect = EffectManagerCtrl.Instance.EffectPrefabs.GetPrefabByName(this.isChargEnum.ToString());
        if (effect == null) return;
        EffectCtrl newEffect = EffectManagerCtrl.Instance.EffectSpawner.Spawn(effect, transform.position);
        if (this.isChargEffect != null) return;
        newEffect.EffectFlyTarget.SetTarget(this.playerCtrl.transform);
        newEffect.gameObject.SetActive(true);

        this.isChargEffect = newEffect;
    }

    protected virtual void StopChargingEffect()
    {
        if (this.isChargEffect == null) return;
        EffectManagerCtrl.Instance.EffectSpawner.Despawn(this.isChargEffect);
        this.isChargEffect = null;
    }
    protected virtual void StartCooldown()
    {
        this.isOnCooldown = true;
        if (this.cooldownCoroutine != null)
        {
            this.StopCoroutine(this.cooldownCoroutine);
        }

        this.cooldownCoroutine = StartCoroutine(this.CooldownRoutine());
    }
    protected virtual IEnumerator CooldownRoutine()
    {
        this.coolDownTimer = this.coolDownTime;
        SkillUISlot skillUISlot = SkillUIManager.Instance.FindSkillByEnenum(this.SkillEnum);
        skillUISlot.StartCoolDown(this.coolDownTime);
        while (this.coolDownTimer > 0)
        {
            this.coolDownTimer -= Time.deltaTime;
            yield return null;
        }

        this.isOnCooldown = false;
    }
    protected virtual SkillAttackPoint GetAttackPoint() => this.playerCtrl.Weapons.GetCurrentWeapon().SkillAttackPoint;
    public abstract void Attacking();
    protected abstract bool CheckSkillCondition();


}
