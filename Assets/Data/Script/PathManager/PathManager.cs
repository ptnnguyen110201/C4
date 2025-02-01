using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : LoadComPonentsManager
{
    [SerializeField] protected List<Path> paths = new();
    [SerializeField] protected List<SpawnPoints> spawnPoints = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPaths();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoints.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            SpawnPoints point = child.GetComponent<SpawnPoints>();
            if (point == null) continue;
            point.LoadSpawnPoint();
            this.spawnPoints.Add(point);
        }
        Debug.Log(transform.name + ": Load SpawnPoint", gameObject);
    }
    protected virtual void LoadPaths()
    {
        if (this.paths.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            Path path = child.GetComponent<Path>();
            if (path == null) continue;
            path.LoadPoints();
            this.paths.Add(path);
        }
        Debug.Log(transform.name + ": Load Paths", gameObject);
    }
    public virtual Path GetPath(int index) => this.paths[index];
    public virtual Path GetPath(string pathName) 
    {
        if(pathName == string.Empty) 
        {
            Debug.LogWarning("pathName is not Exist!");
            return null;
        }
        foreach(Path path in this.paths) 
        {
            if(path.name == pathName) return path;
        }
        return null;
    }
    public virtual Path GetPath(PathEnum pathEnum)
    {
        if (pathEnum == PathEnum.None)
        {
            Debug.LogWarning("PathEnum is not Exist!");
            return null;
        }
        foreach (Path path in this.paths)
        {
            if (path.PathEnum == pathEnum) return path;
        }
        return null;
    }

    public virtual SpawnPoints GetSpawnPoint(SpawnPointEnum spawnPointEnum) 
    {
        if (spawnPointEnum == SpawnPointEnum.None)
        {
            Debug.LogWarning("SpawnPointEnum is not Exist!");
            return null;
        }
        foreach (SpawnPoints point in this.spawnPoints)
        {
            if (point.SpawnPointEnum == spawnPointEnum) return point;
        }
        return null;
    }

    public virtual SpawnPoints GetSpawnPoint() 
    {
        int index = Random.Range(0, this.spawnPoints.Count);
        return this.spawnPoints[index];
    }
}
