using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : PlayerAbstract
{
    protected abstract void Attacking();

    protected void Update()
    {
        this.Attacking();
    }
    protected virtual AttackPoint GetAttackPoint() => this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
 
}
