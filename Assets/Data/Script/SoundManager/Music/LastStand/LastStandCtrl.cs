using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStandCtrl : MusicCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.soundEnum = SoundEnum.LastStand;

    }
}
