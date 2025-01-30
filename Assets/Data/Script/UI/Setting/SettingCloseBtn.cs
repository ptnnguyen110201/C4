using UnityEngine;

public class SettingCloseBtn : ButtonAbstract
{
    public virtual void CloseInventoryUI()
    {
        SettingUI.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}