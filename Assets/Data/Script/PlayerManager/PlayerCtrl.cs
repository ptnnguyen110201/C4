using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : LoadComPonentsManager
{
    [SerializeField] protected vThirdPersonController vThirdPersonController;
    public vThirdPersonController VThirdPersonController => vThirdPersonController;
    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonCamera VThirdPersonCamera => vThirdPersonCamera;
    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;
    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected Weapons weapons;
    public Weapons Weapons => weapons;

    [SerializeField] protected PlayerLevel playerLevel;
    public PlayerLevel PlayerLevel => playerLevel;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRig();
        this.LoadvThirdPersonController();
        this.LoadvThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadWeapons();
        this.LoadPlayerLevel();
    }
    protected virtual void LoadRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": Load Rig", gameObject);
    }
    protected virtual void LoadvThirdPersonController()
    {
        if (this.vThirdPersonController != null) return;
        this.vThirdPersonController = transform.GetComponent<vThirdPersonController>();
        Debug.Log(transform.name + ": Load vThirdPersonController", gameObject);
    }
    protected virtual void LoadvThirdPersonCamera()
    {
        if (this.vThirdPersonCamera != null) return;
        this.vThirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        Debug.Log(transform.name + ": Load vThirdPersonCamera", gameObject);
    }
    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = transform.GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": Load CrosshairPointer", gameObject);
    }
    protected virtual void LoadWeapons()
    {
        if (this.weapons != null) return;
        this.weapons = transform.GetComponentInChildren<Weapons>(true);
        Debug.Log(transform.name + ": Load Weapons", gameObject);
    }
    protected virtual void LoadPlayerLevel()
    {
        if (this.playerLevel != null) return;
        this.playerLevel = transform.GetComponentInChildren<PlayerLevel>(true);
        Debug.Log(transform.name + ": Load PlayerLevel", gameObject);
    }
}
