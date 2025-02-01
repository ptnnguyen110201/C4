using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class MapCtrl : LoadComPonentsManager
{
    [SerializeField] protected NavMeshSurface navMeshSurface;
    public NavMeshSurface NavMeshSurface => navMeshSurface;

    [SerializeField] protected PathManager pathManager;
    public PathManager PathManager => pathManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshSurface();
        this.LoadPathManager();

    }
    protected virtual void LoadNavMeshSurface()
    {
        if (this.navMeshSurface != null) return;
        this.navMeshSurface = transform.GetComponentInChildren<NavMeshSurface>();
        Debug.Log(transform.name + ": Load NavMeshSurface", gameObject);
    }
    protected virtual void LoadPathManager()
    {
        if (this.pathManager != null) return;
        this.pathManager = transform.GetComponentInChildren<PathManager>();
        Debug.Log(transform.name + ": Load PathManager", gameObject);
    }

}
