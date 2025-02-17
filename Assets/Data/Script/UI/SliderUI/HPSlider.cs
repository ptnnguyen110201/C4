using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class HPSlider<T> : SliderAbstract where T : MonoBehaviour
{
    [SerializeField] protected T parent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (this.parent != null) return;
        this.parent = transform.GetComponentInParent<T>();
        Debug.Log(transform.name + "Load Ctrl", gameObject);
    }
    protected void LateUpdate()
    {
        this.OnSliderValueChanged(this.GetValue());
    }

    protected override void OnSliderValueChanged(float value)
    {
        this.slider.value = value;
    }

    protected abstract float GetValue();
}