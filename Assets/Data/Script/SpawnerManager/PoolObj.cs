using UnityEngine;

public abstract class PoolObj : LoadComPonentsManager
{
    [SerializeField] protected DespawnBase despawnBase;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawnBase();
    }

    protected virtual void LoadDespawnBase()
    {
        if (this.despawnBase != null) return;
        this.despawnBase = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + ": Load DespawnBase", gameObject);
    }
}
