using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIChargingSlider : SliderAbstract
{
    [SerializeField] protected Coroutine chargingCoroutine;
    public void StartChargingUI(float chargeTime)
    {
        if (this.chargingCoroutine == null)
        this.chargingCoroutine = this.StartCoroutine(this.StartChargingBar(chargeTime));
    }
    public void StopChargingUI()
    {
        if (this.chargingCoroutine == null) return;
        this.StopCoroutine(this.chargingCoroutine);
        this.chargingCoroutine = null;
        this.slider.gameObject.SetActive(false);
        this.slider.value = 0;

    }
    protected IEnumerator StartChargingBar(float chargeTime)
    {
        float timer = 0;
        while (timer < chargeTime)
        {
            timer += Time.deltaTime;
            this.slider.value = timer / chargeTime;
            yield return null;
        }

        this.slider.value = 1;
        this.StopChargingUI();
    }
}
