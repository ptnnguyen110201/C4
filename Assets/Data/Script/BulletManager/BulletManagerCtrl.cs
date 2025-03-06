using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerCtrl : Singleton<BulletManagerCtrl>
{
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = transform.GetComponentInChildren<BulletSpawner>();
        Debug.Log(transform.name + ": Load BulletSpawner", gameObject);
    }
    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = transform.GetComponentInChildren<BulletPrefabs>();
        Debug.Log(transform.name + ": Load BulletPrefabs", gameObject);
    }
}