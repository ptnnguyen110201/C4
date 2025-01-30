using UnityEngine;

public class BtnSettingToogle : ButtonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    protected override void OnClick()
    {
        SettingUI.Instance.Toggle();
    }

    protected virtual void HotkeyToogleMusic()
    {
        if (InputHotkeys.Instance.isToogleSetting) SettingUI.Instance.Toggle();
    }
}