using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : HPSlider<EnemyCtrl>
{
    protected override float GetValue()
    {
        if (this.parent.EnemyDamageReceiver.MaxHp <= 0) return 0;
        return (float)this.parent.EnemyDamageReceiver.CurrentHp / this.parent.EnemyDamageReceiver.MaxHp;
    }
}
