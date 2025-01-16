using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : Singleton<PathManager>
{
    [SerializeField] protected List<Path> paths = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPaths();
    }

    protected virtual void LoadPaths()
    {
        if (this.paths.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            Path path = child.GetComponent<Path>();
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
}
