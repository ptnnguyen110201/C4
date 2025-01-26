using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrl : Singleton<EffectSpawnerCtrl>
{
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => effectSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = transform.GetComponent<EffectSpawner>();
        Debug.Log(transform.name + ": Load EffectSpawner", gameObject);
    }

}