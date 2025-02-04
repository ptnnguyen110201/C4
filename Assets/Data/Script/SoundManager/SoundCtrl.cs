using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundCtrl : PoolObj
{
    [SerializeField] protected SoundEnum soundEnum;
    [SerializeField] protected AudioSource audioSource;
    public AudioSource AudioSource => audioSource;
    public override string GetName() => this.soundEnum.ToString();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
        this.SetNameByEnum();
    }

    protected virtual void LoadAudioSource() 
    {
        if (this.audioSource != null) return;
        this.audioSource = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + "Load AudioSource");
    }
    protected virtual void SetNameByEnum()
    {
        if (this.transform.name == this.soundEnum.ToString()) return;
        this.transform.name = this.soundEnum.ToString();
        Debug.Log(transform.name + " Set NameByEnum ", gameObject);
    }
}
