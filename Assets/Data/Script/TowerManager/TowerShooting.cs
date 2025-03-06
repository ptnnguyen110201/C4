using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected SoundEnum shootSound = SoundEnum.MaMachingGun;
    protected Coroutine ShootingCoroutine;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.StartShooting();
    }
    protected virtual void StartShooting() 
    {
        if (this.ShootingCoroutine != null) this.StopCoroutine(this.ShootingRoutine());
        this.ShootingCoroutine = this.StartCoroutine(this.ShootingRoutine());
    }
    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            if (this.CanShooting())
            {
                TowerFirePoint firePoint = GetFirePoint();
                Vector3 rotatorDirection = towerCtrl.Rotator.transform.forward;

                this.SpawnBullet(firePoint.transform.position, rotatorDirection);
                this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);
                this.SpawnSound(firePoint.transform.position);
            }
            float shootSpeed = this.towerCtrl.TowerAttribute.TowerAttributeSO.ROF;
            
            yield return new WaitForSeconds(shootSpeed);
        }
    }
    protected virtual void SpawnBullet(Vector3 Pos, Vector3 Rot)
    {
        BulletCtrl bulletCtrl = BulletManagerCtrl.Instance.BulletPrefabs.GetBulletByEnum(this.towerCtrl.TowerProfileSO.bulletEnum);

        BulletCtrl newBullet = BulletManagerCtrl.Instance.BulletSpawner.Spawn(bulletCtrl, Pos);
        newBullet.transform.forward = Rot;
        newBullet.SetShooter(this.towerCtrl.transform);

        int damage = this.towerCtrl.TowerAttribute.TowerAttributeSO.ATK;
        newBullet.BulletDamagerSender.SetDamage(damage);

        newBullet.gameObject.SetActive(true);
    }
    protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
    {
        EffectCtrl effect = EffectManagerCtrl.Instance.EffectPrefabs.GetPrefabByName(EffectEnum.MuzzleTurret.ToString());
        EffectCtrl newEffect = EffectManagerCtrl.Instance.EffectSpawner.Spawn(effect, spawnPoint);
        newEffect.transform.forward = rotatorDirection;
        newEffect.gameObject.SetActive(true);
    }
    protected virtual TowerFirePoint GetFirePoint()
    {
        TowerFirePoint firePoint = this.towerCtrl.TowerFirePoint[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.TowerFirePoint.Count) this.currentFirePoint = 0;
        return firePoint;
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl newSfx = SoundManager.Instance.CreateSfx(this.shootSound);
        if (newSfx == null) return;
        newSfx.transform.position = position;
        newSfx.gameObject.SetActive(true);
    }


    protected virtual bool CanShooting() => this.towerCtrl.TowerLooking.isLooking();
}
