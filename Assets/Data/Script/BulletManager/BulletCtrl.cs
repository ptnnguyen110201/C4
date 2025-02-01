using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected BulletEnum bulletEnum;
    public override string GetName() => this.bulletEnum.ToString();

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    public virtual void SetShooter(Transform shooter) => this.shooter = shooter;

    protected override void OnDisable()
    {
        base.OnDisable();
        this.shooter = null;
    }
}
