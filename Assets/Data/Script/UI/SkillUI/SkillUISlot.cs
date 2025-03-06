using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUISlot : LoadComPonentsManager
{
    [SerializeField] protected SkillEnum skillEnum;
    public SkillEnum SkillEnum => skillEnum;

    [SerializeField] protected Image skillImage;
    [SerializeField] protected TextMeshProUGUI skillTimer;

    protected Coroutine coolDownCoroutine;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillUI();
    }

    protected virtual void LoadSkillUI()
    {
        if (this.skillImage != null) return;
        this.skillImage = transform.Find("SkillImage").GetComponent<Image>();
        this.skillTimer = transform.Find("SkillTimer").GetComponent<TextMeshProUGUI>();
        this.skillTimer.gameObject.SetActive(false);
        Debug.Log(transform.name + ": Load SkillUI", gameObject);
    }

    public void StartCoolDown(float cooldownTime)
    {
        if (this.coolDownCoroutine == null) this.coolDownCoroutine = StartCoroutine(StartChargingBar(cooldownTime));
        else
        {
            this.StopCooldown();
            this.coolDownCoroutine = StartCoroutine(StartChargingBar(cooldownTime));
        }

    }

    public void StopCooldown()
    {
        if (this.coolDownCoroutine == null) return;

        this.StopCoroutine(this.coolDownCoroutine);
        this.coolDownCoroutine = null;
    }

    protected IEnumerator StartChargingBar(float cooldownTime)
    {
        float timer = 0f;
        this.skillImage.fillAmount = 0f;
        this.skillTimer.gameObject.SetActive(true);
        while (timer < cooldownTime)
        {
            timer += Time.deltaTime;
            this.skillImage.fillAmount = timer / cooldownTime;
            this.skillTimer.text = Mathf.CeilToInt(cooldownTime - timer).ToString();
            yield return null;
        }

        this.skillImage.fillAmount = 1f;
        this.skillTimer.gameObject.SetActive(false);
        this.StopCooldown();
    }
}
