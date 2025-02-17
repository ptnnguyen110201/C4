using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVolumeMusic : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }

}
