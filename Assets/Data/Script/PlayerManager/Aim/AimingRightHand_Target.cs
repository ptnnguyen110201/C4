using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_Target : LoadComPonentsManager
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.125f, 0.1f, 0.3f);
        transform.localRotation = Quaternion.Euler(20f, -110f, -100);
    }
}
