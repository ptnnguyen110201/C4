using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected bool isAiming = false;
    [SerializeField] protected float attackHold = 0;
    [SerializeField] protected float attackLightLimit = 0.5f;

    [SerializeField] protected bool isAttackLight = false;
    [SerializeField] protected bool isAttackHeavy = false;


    protected virtual void Update()
    {
        this.CheckAiming();
        this.CheckAttacking();
    }

    protected virtual void CheckAiming()
    {
        this.isAiming = Input.GetMouseButton(1);
    }
    protected virtual void CheckAttacking()
    {
        if (Input.GetMouseButton(0)) this.attackHold += Time.deltaTime;

        if(Input.GetMouseButtonUp(0)) 
        {
            this.isAttackLight = this.attackHold < this.attackLightLimit;
            this.attackHold = 0;
        }
        else 
        {
            this.isAttackLight = false;
        }

        if (this.attackHold > this.attackLightLimit) this.isAttackHeavy = true;
        else this.isAttackHeavy = false ;
    }

    public virtual bool IsAttackLight() => this.isAttackLight;
    public virtual bool IsAttackHeavy() => this.isAttackHeavy;
    public virtual bool IsAiming() => this.isAiming;
}
