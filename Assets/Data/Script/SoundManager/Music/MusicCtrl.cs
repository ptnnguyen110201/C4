using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MusicCtrl : SoundCtrl
{
    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();
        this.audioSource.loop = true;
    }
}
