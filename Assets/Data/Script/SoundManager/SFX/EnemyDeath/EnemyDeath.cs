using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : SFXCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.soundEnum = SoundEnum.EnemyDeath;

    }
}
