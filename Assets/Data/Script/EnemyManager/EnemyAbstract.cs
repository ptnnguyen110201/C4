using UnityEngine;

public abstract class EnemyAbstract : LoadComPonentsManager
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>(true);
        Debug.Log(transform.name + ": Load EnemyCtrl", gameObject);
    }
}
