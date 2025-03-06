using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : Singleton<SkillUIManager>
{
    [SerializeField] protected List<SkillUISlot> skillSlots;
    [SerializeField] protected Transform selectingSkill;
    [SerializeField] protected SkillUIChargingSlider chargingSlider;
    public SkillUIChargingSlider SkillUIChargingSlider => chargingSlider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillSlots();
        this.LoadSelectingSkill();
    }

    protected virtual void LoadSelectingSkill()
    {
        if (this.selectingSkill != null) return;
        this.selectingSkill = transform.Find("SelectingSkill");
        this.chargingSlider = transform.GetComponentInChildren<SkillUIChargingSlider>(true);
        this.chargingSlider.gameObject.SetActive(false);
        Debug.Log(transform.name + ": Load SelectingSkill", gameObject);

    }
    public virtual void StartCharging(float chargTime) 
    {
        this.SkillUIChargingSlider.gameObject.SetActive(true);
        this.SkillUIChargingSlider.StartChargingUI(chargTime);
    }
    protected virtual void LateUpdate()
    {
        this.SetSelectSkill();
    }
    protected virtual void SetSelectSkill()
    {
        SkillEnum skillEnum = PlayerManagerCtrl.Instance.CurrentPlayer.SkillManager.CurrentSkill.SkillEnum;
        foreach (SkillUISlot slot in this.skillSlots)
        {
            if (slot == null) continue;
            if (slot.SkillEnum != skillEnum) continue;
            this.selectingSkill.SetParent(slot.transform);
            this.selectingSkill.localPosition = Vector3.zero;
        }
    }
    protected virtual void LoadSkillSlots()
    {
        if (this.skillSlots.Count > 0) return;
        foreach (Transform obj in this.transform.Find("SkillBar"))
        {
            if (obj == null) continue;
            SkillUISlot skillUISlot = obj.GetComponent<SkillUISlot>();
            this.skillSlots.Add(skillUISlot);
        }

        Debug.Log(transform.name + ": Load SkillSlots", gameObject);
    }

    public virtual SkillUISlot FindSkillByEnenum(SkillEnum skillEnum)
    {
        if (skillEnum == SkillEnum.None) return null;
        foreach (SkillUISlot skill in this.skillSlots)
        {
            if (skill.SkillEnum != skillEnum) continue;
            return skill;
        }
        return null;
    }
}
