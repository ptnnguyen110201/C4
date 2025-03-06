using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAiming : PlayerAbstract
{
    [SerializeField] protected bool isAiming = false;
    public bool IsAiming => isAiming;
    [SerializeField] protected float closeLookDistance = 2.7f;
    [SerializeField] protected float farLookDistance = 3.5f;


    protected virtual void Update() 
    {
        this.CheckAiming();
        this.Aiming();
        this.isLookLock();
        this.isMoveLock();
    }
    protected virtual void Aiming()
    {
        if (this.isAiming) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    { 
        this.playerCtrl.RigBuilder.enabled = true;
        this.playerCtrl.AimingRig.weight = 1;
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.closeLookDistance;
        CrosshairPointer crosshairPointer = this.playerCtrl.CrosshairPointer;
        this.playerCtrl.VThirdPersonController.RotateToPosition(crosshairPointer.transform.position);
        this.playerCtrl.VThirdPersonController.isSprinting = false;
   
    }
    protected virtual void LookFar()
    {
        this.playerCtrl.VThirdPersonCamera.defaultDistance = this.farLookDistance;
        this.playerCtrl.AimingRig.weight = 0;
        this.playerCtrl.RigBuilder.enabled = false;

    }

    protected virtual void isLookLock()
    {
        if (UIManager.Instance.UiIsActive())
        {
            this.playerCtrl.VThirdPersonCamera.xMouseSensitivity = 0;
            this.playerCtrl.VThirdPersonCamera.yMouseSensitivity = 0;

            return;
        }
        this.playerCtrl.VThirdPersonCamera.xMouseSensitivity = 3;
        this.playerCtrl.VThirdPersonCamera.yMouseSensitivity = 3;

    }

   
    protected virtual void isMoveLock() 
    {
        if (UIManager.Instance.UiIsActive())
        {
            this.playerCtrl.VThirdPersonController.input = Vector3.zero;
            this.playerCtrl.VThirdPersonController.moveDirection = Vector3.zero;
            this.playerCtrl.VThirdPersonController.inputMagnitude = 0;
            this.playerCtrl.VThirdPersonController.isSprinting = false;
            this.playerCtrl.VThirdPersonInput.jumpInput = KeyCode.None;
            return; 
           
        }

        this.playerCtrl.VThirdPersonInput.jumpInput = KeyCode.Space;
    }

    protected virtual void CheckAiming() 
    {
        if (InputManager.Instance.IsAiming())
        this.isAiming = !this.isAiming;
    }
}
