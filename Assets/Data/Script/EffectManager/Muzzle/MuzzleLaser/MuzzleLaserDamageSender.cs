using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MuzzleLaserDamageSender : EffectDamageSender
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusEffectTimer = 7;
        this.statusEffectValue = 50;

    }
    protected override void LoadSphereCollider()
    {
        base.LoadSphereCollider();
        this.sphereCollider.radius = 0.1f;
        this.sphereCollider.center = new Vector3(0, 0.5f, 0);
    }
}
