using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DamageReceiver : LoadComPonentsManager
{
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int currentHp = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    public virtual int Deduct(int Hp)
    {
        if (!this.isImmotal) this.currentHp -= Hp;
        if (this.IsDead()) this.OnDead();
        else this.OnHurt();

        if (this.currentHp < 0) this.currentHp = 0;
        return this.currentHp;
    }

    public virtual bool IsDead() => this.isDead = this.currentHp <= 0;
    protected virtual void OnDead()
    {
        //for override
    }
    protected virtual void OnHurt()
    {
        //for override
    }

    protected virtual void Reborn() 
    {
        this.currentHp = this.maxHp;
    }
}
