using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : WeaponAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.03f, 0.06f, 0.015f);
        transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
    }
}
