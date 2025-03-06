using UnityEngine;

public abstract class EffectAbstract : LoadComPonentsManager
{
    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => effectCtrl;  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectCtrl();
    }

    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.GetComponentInParent<EffectCtrl>(true);
        Debug.Log(transform.name + ": Load EffectCtrl", gameObject);
    }
}
