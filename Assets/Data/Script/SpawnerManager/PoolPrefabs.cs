using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPrefabs<T> : LoadComPonentsManager where T : MonoBehaviour
{
    [SerializeField] protected List<T> prefabs = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.HidePrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            T childPrefab = child.GetComponent<T>();
            if (childPrefab != null) this.prefabs.Add(childPrefab);

        }
        Debug.Log(transform.name + ": Load Prefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (T child in this.prefabs)
        {
            if (child is MonoBehaviour monoBehaviour) child.gameObject.SetActive(false);

        }
    }
    public virtual T GetRandom()
    {
        int index = Random.Range(0, this.prefabs.Count);
        return this.prefabs[index];
    }
    public virtual T GetPrefabByName(string prefabName)
    {
        foreach (T child in this.prefabs)
        {
            if (child.name == prefabName) return child;
        }
        return null;
    }
}
