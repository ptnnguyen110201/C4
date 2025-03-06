using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSliderPuting : SliderAbstract
{
    [SerializeField] protected Coroutine chargingCoroutine;
    public void StartPuttingDelay(float chargeTime)
    {

        if (this.chargingCoroutine != null) this.StopCoroutine(chargingCoroutine);
        this.chargingCoroutine = this.StartCoroutine(this.StartChargingBar(chargeTime));
    }
    public void StopPuttingDelay()
    {
        if (this.chargingCoroutine == null) return; 
        this.slider.value = 0;
        this.StopCoroutine(this.chargingCoroutine);
        this.chargingCoroutine = null;
        this.slider.gameObject.SetActive(false);
    

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
        this.StopPuttingDelay();
    }
}
