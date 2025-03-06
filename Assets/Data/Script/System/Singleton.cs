using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : LoadComPonentsManager where T : MonoBehaviour
{
    private static T _instance; 
    public static T Instance 
    {
        get 
        {
            if (_instance == null) Debug.Log("Singleton instance has not been created yet!");
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance() 
    {
        if(_instance == null) 
        {
            _instance = this as T;
            return;
        }
        if (_instance != this)
        {
            Debug.LogError("Another instance of Singleton already exist!");
        }
    }
}
