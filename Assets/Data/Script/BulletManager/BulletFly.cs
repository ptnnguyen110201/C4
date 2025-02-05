using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : GenericMove<BulletCtrl>
{

    protected override void Moving()
    {
        transform.parent.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }

    protected virtual void Update()
    {
        this.Moving();
    }
  
}
