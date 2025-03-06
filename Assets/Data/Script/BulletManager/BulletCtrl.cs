using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected BulletEnum bulletEnum;
    public override string GetName() => this.bulletEnum.ToString();

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    [SerializeField] protected BulletDamagerSender bulletDamagerSender;
    public BulletDamagerSender BulletDamagerSender => bulletDamagerSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDamageSender();

    }
    protected virtual void LoadBulletDamageSender() 
    {
        if (this.bulletDamagerSender != null) return;
        this.bulletDamagerSender = transform.GetComponentInChildren<BulletDamagerSender>(true);
        Debug.Log(transform.name + "Load BulletDamageSender", gameObject);
    }
    public virtual void SetShooter(Transform shooter) => this.shooter = shooter;

    protected override void OnDisable()
    {
        base.OnDisable();
        this.shooter = null;
    }
}
