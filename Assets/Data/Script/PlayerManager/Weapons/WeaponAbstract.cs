using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbstract : LoadComPonentsManager
{
    [SerializeField] protected SkillAttackPoint skillAttackPoint;
    public SkillAttackPoint SkillAttackPoint => skillAttackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillAttackPoint();
    }

    protected virtual void LoadSkillAttackPoint()
    {
        if (this.skillAttackPoint != null) return;
        this.skillAttackPoint = transform.GetComponentInChildren<SkillAttackPoint>();
        this.skillAttackPoint.transform.localPosition = new Vector3(0.05f, 0.5f, 0f); 
        Debug.Log(transform.name + ": Load SkillAttackPoint", gameObject);
    }
}
