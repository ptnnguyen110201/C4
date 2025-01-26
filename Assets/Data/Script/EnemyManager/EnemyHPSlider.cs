using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : SliderAbstract<EnemyCtrl>
{
    protected override float GetValue() => (float)this.parent.EnemyDamageReceiver.CurrentHp / this.parent.EnemyDamageReceiver.MaxHp;
     
       
    
}
