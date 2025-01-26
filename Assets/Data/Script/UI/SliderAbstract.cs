using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract<T> : LoadComPonentsManager where T : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected T parent;

  
    protected virtual void FixedUpdate()
    {
        this.UpdateSlider();
    }
    protected virtual void UpdateSlider() 
    {
        this.slider.value = this.GetValue();
    }
    protected abstract float GetValue();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        this.LoadCtrl();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + ": Load Slider", gameObject);
    }  
    protected virtual void LoadCtrl()
    {
        if (this.parent != null) return;
        this.parent = transform.GetComponentInParent<T>();
        Debug.Log(transform.name + "Load Ctrl", gameObject);
    }
}
