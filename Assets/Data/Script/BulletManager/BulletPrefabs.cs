using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabs : PoolPrefabs<BulletCtrl>
{
    public virtual BulletCtrl GetBulletByEnum(BulletEnum bulletEnum) 
    {
        return this.GetPrefabByName(bulletEnum.ToString());
    }
  
}
