using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : LoadComPonentsManager
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;
    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int currentExp;
    public int CurrentExp => currentExp;
    [SerializeField] protected int nextLevelExp;
    public int NextLevelExp => nextLevelExp;
    public abstract int GetCurrentExp();
    protected abstract bool DeductExp(int exp);
    protected virtual void FixedUpdate() 
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
    protected virtual int GetNextLevelExp() => this.currentLevel * 10;


}
