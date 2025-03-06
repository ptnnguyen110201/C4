using UnityEngine;

public abstract class DespawnBase : LoadComPonentsManager
{
    [SerializeField] protected float timeLife = 7f;
    public float TimeLife => timeLife;
    [SerializeField] protected float currentTime = 7f;
    public float Current => currentTime;
    [SerializeField] protected bool isDespawnByTime = true;
    public virtual void SetEffectTimeLife(float timeLife) => this.timeLife = timeLife;
    public abstract void DespawnObj();
}
