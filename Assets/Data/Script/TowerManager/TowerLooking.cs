using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLooking : TowerAbstract
{
    [SerializeField] protected float targetLoadSpeed = 0.01f;
    [SerializeField] protected float rotationSpeed = 4f;
    [SerializeField] protected EnemyCtrl targetShooting;
    protected Coroutine LookingCoroutine;


    protected override void Start()
    {
        base.Start();
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
            this.targetShooting = towerCtrl.TowerTargeting.NearestEnemy;
        }
    }
    protected virtual void Update()
    {
        if (this.targetShooting != null) this.Looking();
    }
    protected virtual void Looking()
    {
        if (this.targetShooting == null) return;
        Vector3 directionToTarget = this.targetShooting.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            this.rotationSpeed * Time.deltaTime,
            0.0f
        );

        Quaternion targetRotation = Quaternion.LookRotation(newDirection);
        Vector3 eulerAngles = targetRotation.eulerAngles;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, 15f, 30f);
        this.towerCtrl.Rotator.rotation = Quaternion.Euler(eulerAngles);
    }

    public virtual bool isLooking() => this.targetShooting != null;
}
