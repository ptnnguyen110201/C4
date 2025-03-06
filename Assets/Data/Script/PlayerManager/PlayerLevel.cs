using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : LevelByItem
{
    public override int GetLevel() => this.currentLevel;

    public override int GetMaxLevel() => this.maxLevel = 10;


    public override int GetNextLevelExp() => this.nextLevelExp = this.currentLevel * 10;


}
