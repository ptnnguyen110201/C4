using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : LoadComPonentsManager
{
    [SerializeField] protected List<Point> ponts = new();
    [SerializeField] protected PathEnum pathEnum;
    public PathEnum PathEnum => pathEnum;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.ponts.Count > 0) return;
        foreach (Transform child in this.transform)
        {
            Point point = child.GetComponent<Point>();
            point.LoadNextPoint();
            this.ponts.Add(point);
        }
        Debug.Log(transform.name + ": Load Points", gameObject);
    }

    public virtual Point GetPoint(int index) => this.ponts[index];
}
