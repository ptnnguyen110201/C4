using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : LoadComPonentsManager where T : MonoBehaviour
{
   
    [SerializeField] protected int spawnedCount = 0; 
    [SerializeField] protected Transform poolHolder;
    [SerializeField] protected List<T> inPoolObjs;
    [SerializeField] protected PoolPrefabs<T> poolPrefabs;
    public PoolPrefabs<T> PoolPrefabs => poolPrefabs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoolHolder();
        this.LoadPoolPrefabs();
    }

    protected virtual void LoadPoolHolder()
    {
        if (this.poolHolder != null) return;
        this.poolHolder = transform.Find("PoolHolder");
        if(this.poolHolder == null) 
        {
            this.poolHolder = new GameObject("PoolHolder").transform;
            this.poolHolder.parent = transform;
        }
        Debug.Log(transform.name + ": Load PoolHolder", gameObject);
    }
    protected virtual void LoadPoolPrefabs()
    {
        if (this.poolPrefabs != null) return;
        this.poolPrefabs = GetComponentInChildren<PoolPrefabs<T>>();
        Debug.Log(transform.name + ": LoadPoolPrefabs", gameObject);
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
