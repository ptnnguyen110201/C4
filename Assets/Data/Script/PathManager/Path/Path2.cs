using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Path2 : Path
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathEnum = PathEnum.Path2;
    }
}
