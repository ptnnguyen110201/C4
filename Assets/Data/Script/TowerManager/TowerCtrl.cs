using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TowerCtrl : PoolObj
{
    
    [SerializeField] protected TowerProfileSO towerProfileSO;
    public TowerProfileSO TowerProfileSO => towerProfileSO;
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;

    [SerializeField] protected TowerLooking towerLooking;
    public TowerLooking TowerLooking => towerLooking;

    [SerializeField] protected TowerLevel towerLevel;
    public TowerLevel TowerLevel => towerLevel;
    [SerializeField] protected TowerDurability towerDurability;
    public TowerDurability TowerDurability => towerDurability;

    [SerializeField] protected TowerAttribute towerAttribute;
    public TowerAttribute TowerAttribute => towerAttribute;

    [SerializeField] protected List<TowerFirePoint> towerFirePoints;
    public List<TowerFirePoint> TowerFirePoint => towerFirePoints;

    [SerializeField] protected int killCount;
    public int KillCount => killCount;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadTowerLooking();
        this.LoadTowerLevel();
        this.LoadTowerDurability();
        this.LoadTowerAttribute();
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

    protected virtual void LoadTowerLooking()
    {
        if (this.towerLooking != null) return;
        this.towerLooking = transform.GetComponentInChildren<TowerLooking>();
        Debug.Log(transform.name + ": Load TowerLooking ", gameObject);
    }
    protected virtual void LoadTowerTargeting()
    {
        if (this.towerTargeting != null) return;
        this.towerTargeting = transform.GetComponentInChildren<TowerTargeting>();
        Debug.Log(transform.name + ": Load TowerTargeting", gameObject);
    }
    protected virtual void LoadTowerLevel()
    {
        if (this.towerLevel != null) return;
        this.towerLevel = transform.GetComponentInChildren<TowerLevel>();
        Debug.Log(transform.name + "Load TowerLevel", gameObject);
    }
    protected virtual void LoadTowerDurability()
    {
        if (this.towerDurability != null) return;
        this.towerDurability = transform.GetComponentInChildren<TowerDurability>();
        Debug.Log(transform.name + "Load TowerDurability ", gameObject);
    }
    protected virtual void LoadTowerAttribute()
    {
        if (this.towerAttribute != null) return;
        this.towerAttribute = transform.GetComponentInChildren<TowerAttribute>();
        Debug.Log(transform.name + "Load TowerAttribute ", gameObject);
    }
    protected virtual void LoadFirePoint()
    {
        if (this.towerFirePoints.Count > 0) return;
        TowerFirePoint[] point = transform.GetComponentsInChildren<TowerFirePoint>();
        this.towerFirePoints = point.ToList();
        Debug.Log(transform.name + "Load FirePoint", gameObject);
    }

    public virtual bool Deduct(int Amount)
    {
        if (this.killCount < Amount) return false;
        this.killCount -= Amount;
        return true;
    }
    public virtual void Add() => this.killCount += 1;

    public virtual void SetProfile(TowerProfileSO towerProfileSO) => this.towerProfileSO = towerProfileSO;

    public override string GetName() => this.towerProfileSO.towerEnum.ToString();
   
}
