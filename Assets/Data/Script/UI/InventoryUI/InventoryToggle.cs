using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : ButtonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }

    protected override void OnClick()
    {
        InventoryUI.Instance.Toogle();
    }

    protected virtual void HotkeyToogleInventory()
    {
        if (InputHotkeys.Instance.isToogleInventoryUI) InventoryUI.Instance.Toogle();
    }
}
