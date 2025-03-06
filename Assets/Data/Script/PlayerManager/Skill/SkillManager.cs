using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : PlayerAbstract
{
    [SerializeField] protected List<SkillAbstract> skills;
    public List<SkillAbstract> Skills => skills;
    [SerializeField] protected SkillAbstract currentSkill;
    public SkillAbstract CurrentSkill => currentSkill;

    protected override void Start()
    {
        base.Start();
        this.currentSkill = this.skills[0];
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkills();
    }
    protected virtual void Update()
    {
        this.HandleSkillUsage();
        this.AttackSkill();
    }
    protected virtual void HandleSkillUsage()
    {
        if (UIManager.Instance.UiIsActive()) return; 
        if (InputHotkeys.Instance.isInPutKey1) this.currentSkill = this.skills[0];
        if (InputHotkeys.Instance.isInPutKey2) this.currentSkill = this.skills[1];
        if (InputHotkeys.Instance.isInPutKey3) this.currentSkill = this.skills[2];
        if (InputHotkeys.Instance.isInPutKey4) this.currentSkill = this.skills[3];
        if (InputHotkeys.Instance.isInPutKey5) this.currentSkill = this.skills[4];
        if (InputHotkeys.Instance.isInPutKey6) this.currentSkill = this.skills[5];
        if (InputHotkeys.Instance.isInPutKey7) this.currentSkill = this.skills[6];
      
    }

    protected virtual void AttackSkill()
    {
        if (this.currentSkill == null) return;
        if (UIManager.Instance.UiIsActive()) return;

        if (!PlayerManagerCtrl.Instance.CurrentPlayer.PlayerAiming.IsAiming)
        {
            this.currentSkill.StopCharging();
            return;
        }

        if (InputManager.Instance.IsAttacking()) this.currentSkill.StartCharging();
        else this.currentSkill.StopCharging();
    }
    protected virtual void LoadSkills()
    {
        if (this.skills.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            if (obj == null) continue;
            SkillAbstract skill = obj.GetComponent<SkillAbstract>();
            if (skill == null) continue;
            this.skills.Add(skill);
        }

        Debug.Log(transform.name + ": Load Skills", gameObject);
    }



}
