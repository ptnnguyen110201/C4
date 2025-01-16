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
    protected void Start()
    {
        this.LoadEnemyPath();
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish) 
        {
            this.enemyCtrl.EnemyAgent.isStopped = true;
            return; 
        }

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
}
