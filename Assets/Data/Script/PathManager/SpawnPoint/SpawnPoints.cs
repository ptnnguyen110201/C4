using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : LoadComPonentsManager
{
    [SerializeField] protected SpawnPointEnum spawnPointEnum;
    public SpawnPointEnum SpawnPointEnum => spawnPointEnum;
    [SerializeField] protected PathEnum pathEnum;
    public PathEnum PathEnum => pathEnum;
    [SerializeField] protected Transform spawnPoint;
    public Transform SpawnPoint => spawnPoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }

    public virtual void LoadSpawnPoint() 
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = transform.Find("PortalOne").GetComponent<Transform>();
        Debug.Log(transform.name + ": Load SpawnPoint ", gameObject);
    }
}
