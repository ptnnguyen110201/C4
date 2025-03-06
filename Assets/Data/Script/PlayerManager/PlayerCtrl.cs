using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : LoadComPonentsManager
{

    [SerializeField] protected vThirdPersonInput vThirdPersonInput;
    public vThirdPersonInput VThirdPersonInput => vThirdPersonInput;
    [SerializeField] protected vThirdPersonController vThirdPersonController;
    public vThirdPersonController VThirdPersonController => vThirdPersonController;
    [SerializeField] protected vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonCamera VThirdPersonCamera => vThirdPersonCamera;
    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;
    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected RigBuilder rigBuilder;
    public RigBuilder RigBuilder => rigBuilder;
    [SerializeField] protected Weapons weapons;
    public Weapons Weapons => weapons;

    [SerializeField] protected PlayerLevel playerLevel;
    public PlayerLevel PlayerLevel => playerLevel;

    [SerializeField] protected PlayerAiming playerAiming;
    public PlayerAiming PlayerAiming => playerAiming;
    [SerializeField] protected SkillManager skillManager;
    public SkillManager SkillManager => skillManager;

    [SerializeField] protected PlayerTowerPutting playerTowerPutting;
    public PlayerTowerPutting PlayerTowerPutting => playerTowerPutting;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRig();
        this.LoadvThirdPersonController();
        this.LoadvThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadWeapons();
        this.LoadPlayerLevel();
        this.LoadPlayerAiming();
        this.LoadSkillManager();
        this.LoadPlayerTowerPutting();
    }
    protected virtual void LoadRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        this.rigBuilder = transform.Find("Model").GetComponent<RigBuilder>();
        Debug.Log(transform.name + ": Load Rig", gameObject);
    }
    protected virtual void LoadvThirdPersonController()
    {
        if (this.vThirdPersonController != null) return;
        this.vThirdPersonController = transform.GetComponent<vThirdPersonController>();
        this.vThirdPersonInput = transform.GetComponent<vThirdPersonInput>();   
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

    protected virtual void LoadPlayerAiming()
    {
        if (this.playerAiming != null) return;
        this.playerAiming = transform.GetComponentInChildren<PlayerAiming>(true);
        Debug.Log(transform.name + ": Load PlayerAiming", gameObject);
    }

    protected virtual void LoadSkillManager()
    {
        if (this.skillManager != null) return;
        this.skillManager = transform.GetComponentInChildren<SkillManager>(true);
        Debug.Log(transform.name + ": Load SkillManager", gameObject);
    }

    protected virtual void LoadPlayerTowerPutting()
    {
        if (this.playerTowerPutting != null) return;
        this.playerTowerPutting = transform.GetComponentInChildren<PlayerTowerPutting>(true);
        Debug.Log(transform.name + ": Loa dPlayerTowerPutting", gameObject);
    }
}
