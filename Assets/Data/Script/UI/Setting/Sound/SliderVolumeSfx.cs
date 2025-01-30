using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSfx : SliderAbstract<MonoBehaviour>
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}