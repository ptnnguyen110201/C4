using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyCtrl enemyCtrl;

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
        Invoke(nameof(this.Disappear), 3f);
    }
    protected override void OnHurt()
    {
        base.OnDead();
        this.enemyCtrl.EnemyAnimator.SetTrigger("isHurt");
    }
    protected virtual void Disappear() 
    {
        this.enemyCtrl.EnemyDespawn.DespawnObj();
    }

    protected virtual void RewardOnDead() 
    {
        for (int i = 0; i < 3; i++)
        {
            ItemsDropManager.Instance.DropItems(InventoryEnum.Currencies, ItemEnum.Gold, 1, transform.position);
            ItemsDropManager.Instance.DropItems(InventoryEnum.Items, ItemEnum.Wand, 1, transform.position);
            ItemsDropManager.Instance.DropItems(InventoryEnum.Currencies, ItemEnum.Exp, 5, transform.position);
        }

        if (this.isShooter == null) return;
        TowerCtrl towerCtrl = this.isShooter.GetComponent<TowerCtrl>();  
        if (towerCtrl != null) 
        {
            towerCtrl.Add();
        }

    }

}
