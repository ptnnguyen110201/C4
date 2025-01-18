using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1.0f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();


    protected override void Start()
    {
        base.Start();
        this.Invoke(nameof(this.Spawning), this.spawnSpeed);
    }
    protected virtual void FixedUpdate() 
    {
        this.RemoveDead();
    }
    protected virtual void Spawning()
    {
        this.Invoke(nameof(this.Spawning), this.spawnSpeed);

        if (this.spawnedEnemies.Count > this.maxSpawn) return;

        EnemyCtrl prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
        EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);

        this.spawnedEnemies.Add(newEnemy);
    }

    protected virtual void RemoveDead()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }



}
