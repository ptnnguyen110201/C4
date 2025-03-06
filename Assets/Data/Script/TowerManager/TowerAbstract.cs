using UnityEngine;

public abstract class TowerAbstract : LoadComPonentsManager
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.GetComponentInParent<TowerCtrl>(true);
        Debug.Log(transform.name + ": Load TowerCtrl", gameObject);
    }

}
