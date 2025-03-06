using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPrefabs : PoolPrefabs<TowerCtrl>
{
    public virtual TowerCtrl GetTowerByEnum(TowerEnum towerEnum) 
    {
        return this.GetPrefabByName(towerEnum.ToString());
    }
  
}
