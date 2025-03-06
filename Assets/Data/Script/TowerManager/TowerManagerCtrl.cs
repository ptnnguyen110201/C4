using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManagerCtrl : Singleton<TowerManagerCtrl>
{
    [SerializeField] protected TowerSpawner towerSpawner;
    public TowerSpawner TowerSpawner => towerSpawner;
    [SerializeField] protected TowerPrefabs towerPrefabs;
    public TowerPrefabs TowerPrefabs => towerPrefabs;

    [SerializeField] protected TowerShopManager towerShopManager;
    public TowerShopManager TowerShopManager => towerShopManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerSpawner();
        this.LoadTowerPrefabs();
        this.LoadTowerShopManager();
    }

    protected virtual void LoadTowerSpawner()
    {
        if (this.towerSpawner != null) return;
        this.towerSpawner = transform.GetComponentInChildren<TowerSpawner>();
        Debug.Log(transform.name + ": Load TowerSpawner", gameObject);
    }
    protected virtual void LoadTowerPrefabs()
    {
        if (this.towerPrefabs != null) return;
        this.towerPrefabs = transform.GetComponentInChildren<TowerPrefabs>();
        Debug.Log(transform.name + ": Load TowerPrefabs", gameObject);
    }

    protected virtual void LoadTowerShopManager()
    {
        if (this.towerShopManager != null) return;
        this.towerShopManager = transform.GetComponentInChildren<TowerShopManager>();
        Debug.Log(transform.name + ": Load TowerShopManager", gameObject);
    }
}