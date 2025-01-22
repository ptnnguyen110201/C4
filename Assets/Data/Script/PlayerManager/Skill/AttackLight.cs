using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;

    }


}
