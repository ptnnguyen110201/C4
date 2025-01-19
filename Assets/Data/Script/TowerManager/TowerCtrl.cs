using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TowerCtrl : LoadComPonentsManager
{
    [SerializeField] protected BulletEnum bulletEnum;
    public BulletEnum BulletEnum => bulletEnum;
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    [SerializeField] protected BulletPrefabs bulletPrefabs;
    public BulletPrefabs BulletPrefabs => bulletPrefabs;

    [SerializeField] protected List<FirePoint> firePoints;
    public List<FirePoint> FirePoints => firePoints;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBulletPrefabs();
        this.LoadFirePoint();

    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = transform.Find("Model/Rotator");
        this.model.localPosition = new Vector3(0f, 1f, 0f);
        Debug.Log(transform.name + ": Load Model ", gameObject);
    }

    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.Log(transform.name + ": Load TowerTargeting ", gameObject);
    }
    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = GameObject.FindAnyObjectByType<BulletSpawner>();
        Debug.Log(transform.name + ": Load BulletSpawner ", gameObject);
    }
    protected virtual void LoadBulletPrefabs()
    {
        if (this.bulletPrefabs != null) return;
        this.bulletPrefabs = GameObject.FindAnyObjectByType<BulletPrefabs>();
        Debug.Log(transform.name + ": Load BulletPrefabs ", gameObject);
    }

    protected virtual void LoadFirePoint()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] point = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = point.ToList();
        Debug.Log(transform.name + "Load FirePoint", gameObject);
    }

}
