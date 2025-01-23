using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1Ctrl : EffectFlyAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectEnum = EffectEnum.Fire1;
    }
}
