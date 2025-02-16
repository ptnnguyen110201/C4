using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabs : PoolPrefabs<PlayerCtrl>
{
    public virtual PlayerCtrl GetPlayerByEnum(PlayerEnum playerEnum)
    {
        return this.GetPrefabByName(playerEnum.ToString());
    }


}
