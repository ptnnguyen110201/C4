using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Path1 : SpawnPoints
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathEnum = PathEnum.Path1;
        this.spawnPointEnum = SpawnPointEnum.SpawnPoint1;
    }
}
