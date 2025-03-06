using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [SerializeField] protected TowerCtrl towerCtrl;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.GetComponentInParent<TowerCtrl>(true);
        Debug.Log(transform.name + ": Load TowerCtrl ", gameObject);
    }
   
    protected override bool DeductExp(int exp) => this.towerCtrl.Deduct(exp);
    public override int GetCurrentExp() => this.currentExp = this.towerCtrl.KillCount;
    public override int GetNextLevelExp() => this.nextLevelExp = this.currentLevel * 10;
    public override int GetLevel() => this.currentLevel;
    public override int GetMaxLevel() => this.maxLevel = this.towerCtrl.TowerProfileSO.GetMaxLevel();
    
}
