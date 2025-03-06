using System.Collections;
using UnityEngine;

public class EnemySlowEffect : EnemyStatusEffect
{
    [SerializeField] protected float originalSpeed;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.originalSpeed = this.parent.EnemyAgent.speed;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.statusType = StatusType.Slow;
    }

    protected override IEnumerator PlayeEffectCoroutine()
    {
        if (this.parent == null || this.parent.EnemyDamageReceiver.IsDead()) yield break;

        this.OnEffectStart();

        while (this.currentTime > 0)
        {
            this.currentTime -= Time.deltaTime;
            yield return null;
        }
        
        this.OnEffectEnd();
        yield break;
    }

    protected override void OnEffectStart()
    {
        Color slowColor = new Color(0f, 0f, 1f, 0.5f);
        foreach (Material material in this.parent.SkinnedMeshRenderer.materials)
        {
            material.color = slowColor;
        }


        float slowPercentage = Mathf.Clamp((float)this.effectValue / 100f, 0f, 1f);
        float newSpeed = this.originalSpeed * (1f - slowPercentage);

        this.parent.EnemyAgent.speed = Mathf.Max(newSpeed, 0.5f);
    }

    protected override void OnEffectEnd()
    {
        Color originalColor = Color.white;
        foreach (Material material in this.parent.SkinnedMeshRenderer.materials)
        {
            material.color = originalColor;
        }
        this.parent.EnemyAgent.speed = this.originalSpeed; 

        base.OnEffectEnd();
    }
}
