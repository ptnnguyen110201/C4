using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    [SerializeField] protected bool isAlwaysAiming = false;
    protected float closeLookDistance = 0.6f;
    protected float farLookDistance = 1.3f;

    protected virtual void FixedUpdate()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (isAlwaysAiming || InputManager.Instance.IsAiming()) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.closeLookDistance;

        CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
        this.playerCtrl.VThirdPersonController.RotateToPosition(crosshairPointer.transform.position);
        this.playerCtrl.VThirdPersonController.isSprinting = false;
        this.playerCtrl.AimingRig.weight = 1;
    }
    protected virtual void LookFar()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.farLookDistance;
       this.playerCtrl.AimingRig.weight = 0;
    }

}
