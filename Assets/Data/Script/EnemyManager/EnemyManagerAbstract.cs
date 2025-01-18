using UnityEngine;

public abstract class EnemyManagerAbstract : LoadComPonentsManager
{
    [SerializeField] protected EnemyManagerCtrl enemyManagerCtrl;
 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManagerCtrl();
    }

    protected virtual void LoadEnemyManagerCtrl()
    {
        if (this.enemyManagerCtrl != null) return;
        this.enemyManagerCtrl = transform.GetComponentInParent<EnemyManagerCtrl>();
        Debug.Log(transform.name + ": Load EnemyManagerCtrl", gameObject);
    }

}
