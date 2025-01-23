using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : LoadComPonentsManager
{
    [SerializeField] protected float speed = 27;
    [SerializeField] protected Transform target;

    protected virtual void Update()
    {
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
        transform.parent.LookAt(target);
    }
    protected virtual void Flying()
    {
        if (this.target == null) return;
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
}
