using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] protected List<MapCtrl> mapCtrls = new();
    [SerializeField] protected MapCtrl currentMap;
    public MapCtrl CurrentMap => currentMap;
    [SerializeField] protected MapEnum mapEnum;

    protected override void Awake()
    {
        base.Awake();
        this.SetMap();
    }
    protected virtual void SetMap() 
    {
        if (this.currentMap != null) return;
        MapCtrl mapCtrl = this.GetMapCtrl(this.mapEnum);
        this.currentMap = mapCtrl;
        mapCtrl.gameObject.SetActive(true);
    }
    public virtual MapCtrl GetMapCtrl(MapEnum mapEnum) 
    {
        if(this.mapCtrls.Count <= 0 ) return null;
        foreach(MapCtrl mapCtrl in this.mapCtrls) 
        {
            if(mapCtrl.name == mapEnum.ToString()) return mapCtrl;
        }
        return null;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMapCtrls();
    }
    protected virtual void LoadMapCtrls() 
    {
        if (this.mapCtrls.Count > 0) return;
        foreach(Transform obj in this.transform) 
        {
            MapCtrl mapCtrl = obj.GetComponent<MapCtrl>();  
            this.mapCtrls.Add(mapCtrl); 
        }
        this.HideObj();
        Debug.Log(transform.transform + "Load MapCtrls ", gameObject);
    }
    protected virtual void HideObj() 
    {
        if(this.mapCtrls.Count <= 0 ) return;
        foreach (MapCtrl mapCtrl in this.mapCtrls)
        {
            mapCtrl.gameObject.SetActive(false);
        }
    }
}
