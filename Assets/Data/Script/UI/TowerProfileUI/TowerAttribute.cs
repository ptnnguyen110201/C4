using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttribute : TowerAbstract
{
    [SerializeField] protected TowerAttributeSO towerAttributeSO;
    public TowerAttributeSO TowerAttributeSO => towerAttributeSO;
    protected virtual void LateUpdate() 
    {
        this.UpdatingAttributes();
    }

    protected virtual void UpdatingAttributes() 
    {
        int Level = this.towerCtrl.TowerLevel.CurrentLevel;
        TowerAttributeSO towerAttributeSO = this.towerCtrl.TowerProfileSO.GetTowerAttributeSO(Level);
        if (towerAttributeSO == null) return;
        this.towerAttributeSO = towerAttributeSO;
    }
}
