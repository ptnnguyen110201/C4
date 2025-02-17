using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : LoadComPonentsManager 
{
    [SerializeField] protected Slider slider;
    public Slider Slider => slider; 
    protected override void Start()
    {
        this.slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    protected virtual void OnSliderValueChanged(float value)
    {
        //
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + ": Load Slider", gameObject);
    }  
}
