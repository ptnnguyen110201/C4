using UnityEngine;

public class SettingToggleBtn : ButtonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleSetting();
    }

    protected override void OnClick()
    {
        SettingUI.Instance.Toogle();
    }

    protected virtual void HotkeyToogleSetting()
    {
        if (InputHotkeys.Instance.isToogleSetting) SettingUI.Instance.Toogle();
    }
}