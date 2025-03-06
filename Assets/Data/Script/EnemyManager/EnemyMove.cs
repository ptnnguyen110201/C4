using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : GenericMove<EnemyCtrl>
{
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;

    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 1f;

    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected bool isMoving = false;

    public virtual void SetCanMove(bool canMove) => this.canMove = canMove;
    public virtual void SetPath(Path path) => this.enemyPath = path;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();

    }
    protected virtual void Update()
    {
        this.Moving();
        this.CheckMoving();
    }

    protected override void Moving()
    {
        if (!this.canMove)
        {
            this.parent.EnemyAgent.isStopped = true;
            return;
        }
        if (this.parent.EnemyDamageReceiver.IsDead())
        {
            this.parent.EnemyAgent.isStopped = true;
            return;
        }
        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish)
        {
            this.parent.EnemyAgent.isStopped = true;
            return;
        }
        this.parent.EnemyAgent.isStopped = false;
        this.parent.EnemyAgent.SetDestination(this.currentPoint.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if (this.currentPoint == null) this.currentPoint = this.enemyPath.GetPoint(0);

        this.pointDistance = Vector3.Distance(transform.parent.position, this.currentPoint.transform.position);
        if (this.pointDistance < this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
            if (this.currentPoint == null) this.isFinish = true;
        }
    }
  

    protected virtual void CheckMoving()
    {
        if (this.parent.EnemyAgent.velocity.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving = false;
        this.parent.EnemyAnimator.SetBool("isMoving", this.isMoving);
    }

    protected virtual void Reborn()
    {
        this.isFinish = false;
        this.currentPoint = null;
    }

  
}
