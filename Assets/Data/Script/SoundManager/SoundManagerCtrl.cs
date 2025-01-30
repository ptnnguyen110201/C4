using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerCtrl : Singleton<SoundManagerCtrl> 
{
    [SerializeField] protected SoundSpawner soundSpawner;
    public SoundSpawner SoundSpawner => soundSpawner;

    [SerializeField] protected SoundPrefabs soundPrefabs;
    public SoundPrefabs SoundPrefabs => soundPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundSpawner();
        this.LoadSoundPrefabs();
    }

    protected virtual void LoadSoundSpawner()
    {
        if (this.soundSpawner != null) return;
        this.soundSpawner = transform.GetComponentInChildren<SoundSpawner>();
        Debug.Log(transform.name + ": Load SoundSpawner", gameObject);
    }
    protected virtual void LoadSoundPrefabs()
    {
        if (this.soundPrefabs != null) return;
        this.soundPrefabs = transform.GetComponentInChildren<SoundPrefabs>();
        Debug.Log(transform.name + ": Load SoundPrefabs", gameObject);
    }
}
