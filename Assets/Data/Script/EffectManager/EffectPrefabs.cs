using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefabs : PoolPrefabs<EffectCtrl>
{
    public virtual EffectCtrl GetBulletByEnum(EffectEnum effectEnum)
    {
        return this.GetPrefabByName(effectEnum.ToString());
    }

}
