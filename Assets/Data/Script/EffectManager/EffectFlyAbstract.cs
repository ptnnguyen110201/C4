using UnityEngine;

public abstract class EffectFlyAbstract : EffectCtrl
{
    [SerializeField] protected FlyToTarget flyToTarget;
    public FlyToTarget FlyToTarget => flyToTarget;  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlyToTarget();
    }

    protected virtual void LoadFlyToTarget()
    {
        if (this.flyToTarget != null) return;
        this.flyToTarget = transform.GetComponentInChildren<FlyToTarget>(true);
        Debug.Log(transform.name + ": Load FlyToTarget", gameObject);
    }
}
