using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj
{
    [SerializeField] protected float speed = 10f;
    private void Update()
    {
        transform.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }
}
