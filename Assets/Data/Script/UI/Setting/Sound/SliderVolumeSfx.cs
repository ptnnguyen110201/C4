using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSfx : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSfxUpdating(value);
    }
}