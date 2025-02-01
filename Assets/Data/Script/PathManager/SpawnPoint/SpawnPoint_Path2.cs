using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Path2 : SpawnPoints
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathEnum = PathEnum.Path2;
        this.spawnPointEnum = SpawnPointEnum.SpawnPoint2;
    }
}
