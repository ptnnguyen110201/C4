using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TowerLevelText : LevelText<TowerCtrl>
{

    protected override void UpdatingLevel()
    {
        this.text.text = this.parent.TowerLevel.CurrentLevel.ToString();
        
    }
}
