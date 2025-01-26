using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExpText : LevelText<TowerCtrl>
{

    protected override void UpdatingLevel()
    {
        this.text.text = $"{this.parent.KillCount}/{this.parent.TowerLevel.NextLevelExp}";

    }
}
