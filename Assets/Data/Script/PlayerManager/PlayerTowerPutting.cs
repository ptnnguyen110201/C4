using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class PlayerTowerPutting : PlayerAbstract
{
    [SerializeField] protected float puttingDelayTimer = 3;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected TowerPoint towerPoint;
    public TowerPoint TowerPoint => towerPoint;
    protected Coroutine towerPuttingCoroutine;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LateUpdate()
    {
        this.OpenShop();
    }

    protected virtual void OpenShop()
    {
        if (!InputHotkeys.Instance.isInputKeyQ) return;
        if (this.towerPoint == null) return;
        if (this.towerPoint.IsPutted)
        {
            TowerProfileUI.Instance.OpenShop(this.towerPoint);
            return;
        }
        if (this.towerPoint.IsFixed)
        {
            this.towerPoint.PuttingTower();
            return;
        }
        
        ShopTowerUI.Instance.OpenShop(this.towerPoint);
    }

    

  
 

  

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent == null) return;
        TowerPoint towerPoint = collider.transform.GetComponentInParent<TowerPoint>();
        if (towerPoint == null) return;
        this.towerPoint = towerPoint;
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.transform.parent == null) return;
        TowerPoint towerPoint = collider.transform.GetComponentInParent<TowerPoint>();
        if (towerPoint == null) return;
        this.towerPoint = null;
    }




}
