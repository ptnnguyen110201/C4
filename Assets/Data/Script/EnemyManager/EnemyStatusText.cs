using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusText : Text3DGeneric<EnemyCtrl>
{

    protected override void UpdateText()
    {
        string status;
        string timer;
        EnemyStatusEffect enemyStatusEffect = this.parent.EnemyStatusManager.CurrentStatusEffect;
        if (enemyStatusEffect == null)
        {
            this.text.text = string.Empty;
            return;
        }
        status = this.parent.EnemyStatusManager.CurrentStatusEffect.StatusType.ToString();
        timer = Mathf.FloorToInt(this.parent.EnemyStatusManager.CurrentStatusEffect.CurrentTime).ToString();
        this.text.text = $"{status}: {timer}s";
    }
}
