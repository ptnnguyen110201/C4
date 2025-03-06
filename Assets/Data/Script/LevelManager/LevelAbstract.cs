using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : LoadComPonentsManager
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    [SerializeField] protected int maxLevel ;
    [SerializeField] protected int currentExp;
    [SerializeField] protected int nextLevelExp;
    public abstract int GetCurrentExp();
    public abstract int GetNextLevelExp();
    public abstract int GetLevel();
    public abstract int GetMaxLevel();
    protected abstract bool DeductExp(int exp);
    protected override void Start()
    {
        base.Start();
        this.GetLevel();
        this.GetMaxLevel();
    }
    protected virtual void LateUpdate() 
    {
        this.Leveling();
    }

    protected virtual void Leveling() 
    {
        if (this.currentLevel >= this.maxLevel) return;
        if (this.GetCurrentExp() < this.GetNextLevelExp()) return;
        if (!this.DeductExp(this.GetNextLevelExp())) return;

        this.currentLevel++;
    }
  


}
