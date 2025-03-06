using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAttack : SkillAbstract
{

    public override void Attacking()
    {
        this.SpawnEffect();
    }
    protected abstract void SpawnEffect();

  
}
