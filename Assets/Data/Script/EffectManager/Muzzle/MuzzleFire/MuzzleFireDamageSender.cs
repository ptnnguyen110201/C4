using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MuzzleFireDamageSender : EffectDamageSender
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusEffectTimer = 10;
        this.statusEffectValue = 3;
    }
    protected override void LoadSphereCollider()
    {
        base.LoadSphereCollider();
        this.sphereCollider.radius = 0.1f;
        this.sphereCollider.center = new Vector3(0, 0.5f, 0);
    }
}
