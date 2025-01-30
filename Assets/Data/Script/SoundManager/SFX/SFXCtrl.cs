using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SFXCtrl : SoundCtrl
{
    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();
        this.audioSource.loop = false;
    }
}
