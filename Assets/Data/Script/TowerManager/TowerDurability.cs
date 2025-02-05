using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDurability : LoadComPonentsManager
{
    [SerializeField] protected int maxDurability = 100;
    public int MaxDurability => maxDurability;
    [SerializeField] protected int currentDurability = 100;
    public int CurrentDurability => currentDurability;

    [SerializeField] protected int decayRate = 1;
    [SerializeField] protected bool isActive;
    public bool IsActive => isActive;

    protected Coroutine ReduceDurability;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.StartReduce();


    }
    protected virtual void StartReduce() 
    {
        if (this.ReduceDurability != null) this.StopCoroutine(this.ReduceDurability);
        this.ReduceDurability = this.StartCoroutine(this.ReduceDurabilityCoroutine());
    }
    protected virtual IEnumerator ReduceDurabilityCoroutine()
    {
        while (this.currentDurability > 0)
        {
            yield return new WaitForSeconds(this.decayRate); 
            this.currentDurability -= this.decayRate;
            this.currentDurability = Mathf.Clamp(this.currentDurability, 0, this.currentDurability);
            this.SetActive();
        }
    }

    protected virtual void SetActive() => this.isActive = this.currentDurability > 0;
  
}
