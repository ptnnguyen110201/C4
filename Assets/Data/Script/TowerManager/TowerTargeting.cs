using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : TowerAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigiBody;
    [SerializeField] protected LayerMask obstacleLayerMask;
    [SerializeField] protected EnemyCtrl nearestEnemy;
    public EnemyCtrl NearestEnemy => nearestEnemy;
    [SerializeField] protected List<EnemyCtrl> enemyCtrls;



    protected virtual void FixedUpdate()
    {
        this.RemoveDeadEnemy();
        this.FindNearest();
    }
    protected virtual void FindNearest()
    {
        if (this.enemyCtrls.Count <= 0)
        {
            this.nearestEnemy = null;
            return;
        }
        if (!this.isActive())
        {
            this.nearestEnemy = null;
            return;
        }
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl enemyCtrl in this.enemyCtrls)
        {
            if (!this.CanSeeTarget(enemyCtrl)) continue;
            enemyDistance = Vector3.SqrMagnitude(transform.position - enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearestEnemy = enemyCtrl;
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddEnemy(collider);
    }
    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveEnemy(collider);
    }
    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyCtrl enemyCtrl = collider.transform.GetComponentInParent<EnemyCtrl>();

        if (enemyCtrl.EnemyDamageReceiver.IsDead()) return;
        this.enemyCtrls.Add(enemyCtrl);
    }
    protected virtual void RemoveEnemy(Collider collider)
    {
        if (this.enemyCtrls.Count <= 0) return;
        EnemyCtrl enemyCtrl = collider.transform.GetComponentInParent<EnemyCtrl>();
        if (!this.enemyCtrls.Contains(enemyCtrl)) return;
        if (this.nearestEnemy == enemyCtrl) this.nearestEnemy = null;
        this.enemyCtrls.Remove(enemyCtrl);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.radius = 20f;
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.transform.localPosition = new(0f, 1.5f, 0f);
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigiBody != null) return;
        this.rigiBody = transform.GetComponent<Rigidbody>();
        this.rigiBody.useGravity = false;
        Debug.Log(transform.name + ":Load Rigidbody", gameObject);
    }


    protected virtual void RemoveDeadEnemy()
    {
        if (this.enemyCtrls.Count <= 0) return;
        this.enemyCtrls.RemoveAll(enemyCtrl =>
        {
            if (!enemyCtrl.EnemyDamageReceiver.IsDead()) return false;
            if (this.nearestEnemy == enemyCtrl) this.nearestEnemy = null;
            return true;
        });
    }

    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, this.obstacleLayerMask))
        {
            Vector3 directionToCollider = hitInfo.point - transform.position;
            float distanceToCollider = directionToCollider.magnitude;

            Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollider, Color.red);
            return false;
        }

        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
        return true;
    }
    protected virtual bool isActive() => this.towerCtrl.TowerDurability.IsActive;
}
