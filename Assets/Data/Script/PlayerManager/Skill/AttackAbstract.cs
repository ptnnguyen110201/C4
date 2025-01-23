using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : PlayerAbstract
{
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
        this.LoadEffectPrefabs();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        Debug.Log(transform.name + ": Load EffectSpawner", gameObject);
    }
    protected virtual void LoadEffectPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.Log(transform.name + ": Load EffectPrefabs", gameObject);
    }

    protected void LateUpdate()
    {
        this.Attacking();
    }
    protected abstract void Attacking();
    protected virtual AttackPoint GetAttackPoint() => this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;

}
