using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected BulletEnum bulletEnum;
    public override string GetName() => this.bulletEnum.ToString();
  
}
