using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected bool isAiming = false;
    [SerializeField] protected bool isAttacking = false;

    protected virtual void Update()
    {
        this.CheckAiming();
        this.CheckAttacking();
    }
  

    protected virtual void CheckAiming() => this.isAiming = Input.GetMouseButtonDown(1);
    protected virtual void CheckAttacking() => this.isAttacking = Input.GetMouseButton(0);

    public virtual bool IsAttacking() => this.isAttacking;
    public virtual bool IsAiming() => this.isAiming;
}
