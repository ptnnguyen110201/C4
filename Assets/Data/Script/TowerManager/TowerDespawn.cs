using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDespawn : Despawn<TowerCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = false;
    }
}
