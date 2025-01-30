using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingGunCtrl : SFXCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.soundEnum = SoundEnum.MaMachingGun;

    }
}
