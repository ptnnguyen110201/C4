using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1.0f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();
    protected Coroutine EnemySpawnCoroutine;
    protected Coroutine EnemyRemoveDeadCoroutine;

    protected override void Start()
    {
        this.StartEnemySpawning();
        this.StartEnemyRemoving();
    }


    protected virtual void StartEnemySpawning() 
    {
        if (this.EnemySpawnCoroutine != null) this.StopCoroutine(this.SpawningCoroutine());
        this.EnemySpawnCoroutine = this.StartCoroutine(this.SpawningCoroutine());
    }

    protected virtual void StartEnemyRemoving() 
    {
        if (this.EnemyRemoveDeadCoroutine != null) this.StopCoroutine(this.RemoveDeadCoroutine());
        this.EnemyRemoveDeadCoroutine = this.StartCoroutine(this.RemoveDeadCoroutine());
    }


    protected virtual IEnumerator SpawningCoroutine()
    {
        while (true)
        {
            if (this.spawnedEnemies.Count < this.maxSpawn)
            {
                SpawnPoints spawnPoint = MapManager.Instance.CurrentMap.PathManager.GetSpawnPoint();
                EnemyCtrl prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();
                EnemyCtrl newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, spawnPoint.SpawnPoint.position);

                Path path = MapManager.Instance.CurrentMap.PathManager.GetPath(spawnPoint.PathEnum);
                newEnemy.EnemyMove.SetPath(path);
                newEnemy.gameObject.SetActive(true);
                this.spawnedEnemies.Add(newEnemy);
            }
            yield return new WaitForSeconds(this.spawnSpeed);
        }
    }
    protected virtual IEnumerator RemoveDeadCoroutine()
    {
        while (true)
        {
            if (this.spawnedEnemies.Count > 0) this.spawnedEnemies.RemoveAll(enemy => enemy.EnemyDamageReceiver.IsDead());
            yield return new WaitForSeconds(0.1f);
        }
    }
}
