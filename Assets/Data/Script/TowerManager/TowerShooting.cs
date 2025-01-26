using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 0.2f;
    [SerializeField] protected float targetLoadSpeed = 0.1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl tartgetShooting;


    protected override void Start() 
    { 
        base.Start();
        this.Invoke(nameof(this.TargetLoading), 1f);
        this.Invoke(nameof(this.Shooting), 1f);
    }

    protected virtual void TargetLoading()
    {
        this.Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        this.tartgetShooting = this.towerCtrl.TowerTargeting.NearestEnemy;
    }

    protected virtual void FixedUpdate() 
    {
        this.Looking();
    }
    protected virtual void Looking()
    {
        if (this.tartgetShooting == null) return;
        Vector3 directionToTarget = this.tartgetShooting.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            this.rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
    }
    protected virtual void Shooting() 
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.tartgetShooting == null) return;

        FirePoint firePoint = this.GetFirePoint();
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;
        this.SpawnBullet(firePoint.transform.position, rotatorDirection);
        this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);

    }
    protected virtual void SpawnBullet(Vector3 Pos, Vector3 Rot) 
    {
        BulletCtrl bulletCtrl = this.towerCtrl.BulletPrefabs.GetBulletByEnum(this.towerCtrl.BulletEnum);  
 
        BulletCtrl newBullet = this.towerCtrl.BulletSpawner.Spawn(bulletCtrl, Pos);
        newBullet.transform.forward = Rot;   
        bulletCtrl.SetShooter(this.towerCtrl.transform);
        newBullet.gameObject.SetActive(true);
    }
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = EffectSpawnerCtrl.Instance.EffectSpawner.PoolPrefabs.GetPrefabByName(EffectEnum.TurretMuzzle.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.EffectSpawner.Spawn(effect, spawnPoint);
        newEffect.transform.forward = rotatorDirection;
        newEffect.gameObject.SetActive(true);
    }
    protected virtual FirePoint GetFirePoint() 
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }
}
