using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TowerLevelText : Text3DGeneric<TowerCtrl>
{

    protected override void UpdateText()
    {
        this.text.text = this.parent.TowerLevel.CurrentLevel.ToString();
        
    }
}
