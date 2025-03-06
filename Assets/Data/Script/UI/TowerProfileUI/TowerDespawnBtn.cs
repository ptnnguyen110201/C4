using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDespawnBtn : ButtonAbstract
{
   
     protected virtual void DespawnTower() 
    {
        TowerPoint towerPoint = PlayerManagerCtrl.Instance.CurrentPlayer.PlayerTowerPutting.TowerPoint;
        if (towerPoint == null) return;
        towerPoint.DespawnTower();
        TowerProfileUI.Instance.Toogle();
    }
    protected override void OnClick()
    {
        this.DespawnTower();
    }
}
