using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_Target : LoadComPonentsManager
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.05f, 0.025f, 0.2f);
        transform.localRotation = Quaternion.Euler(20f, -110f, -100);
    }
}
