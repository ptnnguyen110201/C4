using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : LoadComPonentsManager where T : MonoBehaviour
{
    [SerializeField] protected PoolHolder poolHolder;
    [SerializeField] protected int spawnedCount = 0;
    [SerializeField] protected List<T> inPoolObjs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoolHolder();
    }

    protected virtual void LoadPoolHolder()
    {
        if (this.poolHolder != null) return;
        this.poolHolder = transform.GetComponentInChildren<PoolHolder>();
        Debug.Log(transform.name + ": Load PoolHolder", gameObject);
    }

    public virtual Transform Spawn(Transform prefabs)
    {
        Transform newObj = Instantiate(prefabs);
        return newObj;
    }
    public virtual T Spawn(T obj)
    {
        T newObj = this.GetObjFromPool(obj);
        if (newObj == null)
        {
            newObj = Instantiate(obj);
            newObj.name = obj.name;
            this.spawnedCount++;
        }
        if (this.poolHolder != null) newObj.transform.parent = this.poolHolder.transform;

        return newObj;

    }
    public virtual T Spawn(T obj, Vector3 Pos)
    {
        T newObj = this.Spawn(obj);
        newObj.transform.position = Pos;
        return newObj;
    }

    public virtual void Despawn(T obj)
    {
        if (obj == null) return;

        if (obj is MonoBehaviour monoBehaviour)
        {
            this.spawnedCount--;
            this.AddObjectToPool(obj);
            monoBehaviour.gameObject.SetActive(false);
        }
    }
    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }
    protected virtual void RemoveObjFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual T GetObjFromPool(T obj)
    {
        foreach (T objPool in this.inPoolObjs)
        {
            if (obj.name == objPool.name)
            {
                this.RemoveObjFromPool(objPool);
                return objPool;
            }
        }
        return null;
    }


}
