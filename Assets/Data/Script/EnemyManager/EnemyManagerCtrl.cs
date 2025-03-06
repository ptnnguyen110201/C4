using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerCtrl : Singleton<EnemyManagerCtrl>
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;

    [SerializeField] protected EnemySpawning enemySpawning;
    public EnemySpawning EnemySpawning => enemySpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadEnemySpawning();
    }

    protected virtual void LoadEnemySpawner() 
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponentInChildren<EnemySpawner>();
        Debug.Log(transform.name + ": Load EnemySpawner", gameObject);
    }

    protected virtual void LoadEnemySpawning()
    {
        if (this.enemySpawning != null) return;
        this.enemySpawning = transform.GetComponentInChildren<EnemySpawning>();
        Debug.Log(transform.name + ": Load EnemySpawning", gameObject);
    }
}
