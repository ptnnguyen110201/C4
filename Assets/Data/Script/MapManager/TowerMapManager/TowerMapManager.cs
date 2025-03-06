using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMapManager : LoadComPonentsManager
{
    [SerializeField] protected List<TowerPoint> towerPoints = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerPoint();
    }
    protected virtual void LoadTowerPoint()
    {
        if (this.towerPoints.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            TowerPoint point = child.GetComponent<TowerPoint>();
            if (point == null) continue;
            this.towerPoints.Add(point);
        }
        Debug.Log(transform.name + ": Load TowerPoint", gameObject);
    }
}
