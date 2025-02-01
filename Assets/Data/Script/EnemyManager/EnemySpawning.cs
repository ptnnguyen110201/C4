using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1.0f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void OnDisable()
    {
        base.OnDisable();
        this.StopCoroutine(this.SpawningCoroutine());
        this.StopCoroutine(this.RemoveDeadCoroutine());

    }
    protected override void OnEnable()
    {
        base.OnDisable();
        this.StartCoroutine(this.SpawningCoroutine());
        this.StartCoroutine(this.RemoveDeadCoroutine());

    }
    protected override void Start()
    {
      //  base.Start();
       // this.Invoke(nameof(this.Spawning), this.spawnSpeed);
    }
    protected virtual void FixedUpdate()
    {
       // this.RemoveDead();
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
        if (this.spawnedEnemies.Count <= 0) return;
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }

    protected virtual IEnumerator SpawningCoroutine()
    {
        while (true)
        {
            if (this.spawnedEnemies.Count < this.maxSpawn)
            {
                //SpawnPoints spawnPoint = MapManager.Instance.CurrentMap.PathManager.GetSpawnPoint(SpawnPointEnum.SpawnPoint1);
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
            if (this.spawnedEnemies.Count <= 0) yield return null;
            for (int i = this.spawnedEnemies.Count - 1; i >= 0; i--)
            {
                if (!this.spawnedEnemies[i].EnemyDamageReceiver.IsDead()) continue;
                this.spawnedEnemies.RemoveAt(i);
            }
            yield return new WaitForSeconds(this.spawnSpeed);
        }
    }
}
