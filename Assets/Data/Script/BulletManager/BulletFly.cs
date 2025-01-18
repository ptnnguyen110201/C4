using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : BulletAbstract
{
    [SerializeField] protected float speed = 10f;
    protected virtual void Update()
    {
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
}
