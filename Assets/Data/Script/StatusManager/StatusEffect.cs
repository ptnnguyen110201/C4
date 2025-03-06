using UnityEngine;
using System.Collections;

public abstract class StatusEffect<T> : LoadComPonentsManager where T : MonoBehaviour

{
    [SerializeField] protected T parent;
    [SerializeField] protected StatusType statusType;
    public StatusType StatusType => statusType;

    [SerializeField] protected float currentTime;
    public float CurrentTime => currentTime;

    [SerializeField] protected float timeLife;
    public float TimeLife => timeLife;
    [SerializeField] protected double effectValue;
    public double EffectValue => effectValue;

    protected Coroutine effectCoroutine;
    public Coroutine EffectCoroutine => effectCoroutine;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    public virtual void ApplyEffect(StatusType statusType, float duration, double effectValue)
    {
        if (this.effectCoroutine != null && this.statusType == statusType)
        {
            this.effectValue += effectValue;
            this.effectValue = Mathf.Clamp((float)this.effectValue, 0f, 75f); 

            this.currentTime += duration;
            this.currentTime = Mathf.Min(this.currentTime, this.timeLife * 2); 

            this.ResetEffect();
            return;
        }

        this.timeLife = duration;
        this.effectValue = effectValue;
        this.currentTime = duration;
        this.effectCoroutine = this.StartCoroutine(this.PlayeEffectCoroutine());
    }


    protected virtual void ResetEffect()
    {
        this.StopEffectCoroutine();
        this.effectCoroutine = this.StartCoroutine(this.PlayeEffectCoroutine());
    }

    protected virtual void StopEffectCoroutine()
    {
        if (this.effectCoroutine != null)
        {
            this.StopCoroutine(this.effectCoroutine);
            this.effectCoroutine = null;
        }
    }

    protected override void OnDisable()
    {

        base.OnDisable();
        this.OnEffectEnd();

    }
    protected virtual void OnEffectStart() { }
    protected virtual void OnEffectEnd() { }
    protected abstract IEnumerator PlayeEffectCoroutine();
    protected virtual void LoadCtrl()
    {
        if (this.parent != null) return;
        this.parent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + " Load Ctrl", gameObject);
    }

}
