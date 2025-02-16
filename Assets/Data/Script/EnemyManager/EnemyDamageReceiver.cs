using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected SoundEnum DeathSound = SoundEnum.EnemyDeath;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadCapsuleCollider();
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
        this.enemyCtrl.EnemyHPSlider.gameObject.SetActive(true);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": Load EnemyCtrl", gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = transform.GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0f, 1f, 0f);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 1.5f;
        this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load CapsuleCollider", gameObject);
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.RewardOnDead();
        this.enemyCtrl.EnemyAnimator.SetBool("isDead", this.isDead);
        this.capsuleCollider.enabled = false;
        this.enemyCtrl.EnemyHPSlider.gameObject.SetActive(false);
        this.SpawnSound(transform.position);
        this.Invoke(nameof(this.Disappear), 3f);
    }
    protected override void OnHurt()
    {
        this.enemyCtrl.EnemyAnimator.SetTrigger("isHurt");
    }
    protected virtual void Disappear()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObj();
    }

    protected virtual void RewardOnDead()
    {
        float Height = this.enemyCtrl.EnemyAgent.height;
        Vector3 goldPos = new Vector3(transform.position.x, transform.position.y + Height, transform.position.z);
        Vector3 expPos = new Vector3(transform.position.x, transform.position.y + Height + 0.3f, transform.position.z);
        ItemsDropManager.Instance.DropItems(InventoryEnum.Currencies, ItemEnum.Gold, 5, goldPos);
        ItemsDropManager.Instance.DropItems(InventoryEnum.Currencies, ItemEnum.Exp, 10, expPos);


        if (this.shooter == null) return;
        TowerCtrl towerCtrl = this.shooter.GetComponent<TowerCtrl>();
        if (towerCtrl == null) return;
        towerCtrl.Add();


    }

    public override int Deduct(int Hp)
    {
        Vector3 Pos = transform.parent.position;
        this.SpawnMuzzle(Pos);
        return base.Deduct(Hp);

    }
    protected virtual void SpawnMuzzle(Vector3 spawnPoint)
    {
        EffectCtrl effect = EffectSpawnerCtrl.Instance.EffectSpawner.PoolPrefabs.GetPrefabByName(EffectEnum.MuzzleHit.ToString());
        EffectCtrl newEffect = EffectSpawnerCtrl.Instance.EffectSpawner.Spawn(effect, spawnPoint);
        newEffect.gameObject.SetActive(true);
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl newSfx = SoundManager.Instance.CreateSfx(this.DeathSound);
        newSfx.transform.position = position;
        newSfx.gameObject.SetActive(true);
    }
}

