using UnityEngine;

public abstract class PlayerAbstract : LoadComPonentsManager
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>(true);
        Debug.Log(transform.name + ": Load PlayerCtrl", gameObject);
    }
}
