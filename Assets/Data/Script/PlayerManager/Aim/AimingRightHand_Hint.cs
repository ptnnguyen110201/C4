using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_Hint : LoadComPonentsManager
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.5f, 0.2f, -0.5f);
        transform.localRotation = Quaternion.Euler(25f, -110f, -110f);
    }
}
