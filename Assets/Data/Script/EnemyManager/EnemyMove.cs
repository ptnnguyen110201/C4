using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : EnemyAbstract
{
    [SerializeField] protected PathEnum pathEnum;
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 1f;
    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected bool isMoving = false;
    protected void Start()
    {
        this.LoadEnemyPath();
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();    
        this.CheckMoving();
    }
    protected virtual void Moving()
    {
        if (!this.canMove) 
        {
            this.enemyCtrl.EnemyAgent.isStopped = true;
            return;
        }
        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish) 
        {
            this.enemyCtrl.EnemyAgent.isStopped = true;
            return; 
        }
        this.enemyCtrl.EnemyAgent.isStopped = false;
        this.enemyCtrl.EnemyAgent.SetDestination(this.currentPoint.transform.position);
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
    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathManager.Instance.GetPath(this.pathEnum);
        Debug.Log(transform.name + ": Load EnemyPath ", gameObject);
    }

    protected virtual void CheckMoving() 
    {
        if (this.enemyCtrl.EnemyAgent.velocity.magnitude > 0.1f) this.isMoving = true;
        else this.isMoving = false;
        this.enemyCtrl.EnemyAnimator.SetBool("IsMoving", this.isMoving);
    }

 
}
