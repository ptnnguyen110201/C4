using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbstract : LoadComPonentsManager
{
    [SerializeField] protected AttackPoint attackPoint;
    public AttackPoint AttackPoint => attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = transform.GetComponentInChildren<AttackPoint>();
        this.attackPoint.transform.localPosition = new Vector3(0.05f, 0.5f, 0f); ;
        Debug.Log(transform.name + ": Load AttackPoint", gameObject);
    }
}
