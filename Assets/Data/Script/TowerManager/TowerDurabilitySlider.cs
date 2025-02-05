using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDurabilitySlider : HPSlider<TowerCtrl>
{
    protected override float GetValue()
    {
        if (this.parent.TowerDurability.CurrentDurability <= 0) return 0;
        return (float)this.parent.TowerDurability.CurrentDurability / this.parent.TowerDurability.MaxDurability;
    }
}
