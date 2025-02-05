using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 0.2f;
    [SerializeField] protected SoundEnum shootSound = SoundEnum.MaMachingGun;
    protected Coroutine ShootingCoroutine;
    protected override void Start()
    {
        base.Start();
        this.StartShooting(); 
    }

    protected virtual void StartShooting() 
    {
        if (this.ShootingCoroutine != null) this.StopCoroutine(this.ShootingRoutine());
        this.ShootingCoroutine = this.StartCoroutine(this.ShootingRoutine());
    }
    private IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(1f); 

        while (true)
        {
            if (this.CanShooting())
            {
                FirePoint firePoint = GetFirePoint();
                Vector3 rotatorDirection = towerCtrl.Rotator.transform.forward;

                this.SpawnBullet(firePoint.transform.position, rotatorDirection);
                this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);
                this.SpawnSound(firePoint.transform.position);
            }
            yield return new WaitForSeconds(this.shootSpeed);
        }
    }
    protected virtual void SpawnBullet(Vector3 Pos, Vector3 Rot)
    {
        BulletCtrl bulletCtrl = this.towerCtrl.BulletPrefabs.GetBulletByEnum(this.towerCtrl.BulletEnum);

        BulletCtrl newBullet = this.towerCtrl.BulletSpawner.Spawn(bulletCtrl, Pos);
        newBullet.transform.forward = Rot;
        newBullet.SetShooter(this.towerCtrl.transform);
        newBullet.gameObject.SetActive(true);
    }
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = EffectSpawnerCtrl.Instance.EffectSpawner.PoolPrefabs.GetPrefabByName(EffectEnum.MuzzleTurret.ToString());
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

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl newSfx = SoundManager.Instance.CreateSfx(this.shootSound);
        newSfx.transform.position = position;
        newSfx.gameObject.SetActive(true);
    }

    protected virtual bool CanShooting() => this.towerCtrl.TowerLooking.isLooking();
}
