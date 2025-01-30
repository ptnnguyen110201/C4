using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDespawn : Despawn<SoundCtrl>
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.isDespawnByTime = !this.parent.AudioSource.loop;
    }
}
