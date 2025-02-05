using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLooking : TowerAbstract
{
    [SerializeField] protected float targetLoadSpeed = 0.01f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl targetLooking;
    protected Coroutine LookingCoroutine;


    protected override void OnEnable()
    {
        base.OnEnable();
        this.StartTargetLoading();
    }
    private void StartTargetLoading()
    {
        if (this.LookingCoroutine != null) this.StopCoroutine(LookingCoroutine);
        this.LookingCoroutine = this.StartCoroutine(this.TargetLoadingRoutine());
    }
    private IEnumerator TargetLoadingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.targetLoadSpeed);
            this.targetLooking = towerCtrl.TowerTargeting.NearestEnemy;
        }
    }

    protected virtual void Update()
    {
        if (!this.isActive()) 
        {
            this.SetIdleRotation();
            return;
        }

        this.Looking();
    }

    protected virtual void Looking()
    {
        if (!this.isLooking()) return;
        Vector3 directionToTarget = this.targetLooking.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            this.rotationSpeed * Time.deltaTime,
            0.0f
        );

        Quaternion targetRotation = Quaternion.LookRotation(newDirection);
        Vector3 adjustedEulerAngles = targetRotation.eulerAngles;
        adjustedEulerAngles.x = Mathf.Clamp(adjustedEulerAngles.x, 15f, 30f);
        this.towerCtrl.Rotator.rotation = Quaternion.Euler(adjustedEulerAngles);
    }

    protected virtual void SetIdleRotation()
    {
        Vector3 currentDirection = this.towerCtrl.Rotator.forward;
        Vector3 targetDirection = new Vector3(currentDirection.x, -1, currentDirection.z);

        Vector3 newDirection = Vector3.RotateTowards(
            currentDirection,
            targetDirection,
            this.rotationSpeed * Time.deltaTime, 
            0.0f
        );

        Quaternion targetRotation = Quaternion.LookRotation(newDirection);
        this.towerCtrl.Rotator.rotation = targetRotation;
    }



    public virtual bool isLooking()
    {
        if (this.targetLooking == null) return false;
        return true;
    }
    protected virtual bool isActive() => this.towerCtrl.TowerDurability.IsActive;



}
