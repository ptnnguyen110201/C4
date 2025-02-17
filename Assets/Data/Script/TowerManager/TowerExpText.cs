using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExpText : Text3DGeneric<TowerCtrl>
{

    protected override void UpdateText()
    {
        this.text.text = $"{this.parent.TowerLevel.GetCurrentExp()}/{this.parent.TowerLevel.GetNextLevelExp()}";

    }
}
