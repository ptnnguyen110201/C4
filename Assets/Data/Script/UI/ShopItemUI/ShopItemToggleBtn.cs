using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUIToggleBtn : ButtonAbstract
{

    protected virtual void LateUpdate()
    {
        this.HotKeyToggleTowerShop();
    }

    protected override void OnClick()
    {
        ShopItemUI.Instance.Toogle();
    }

    protected virtual void HotKeyToggleTowerShop()
    {
        if (InputHotkeys.Instance.isToogleShop) ShopItemUI.Instance.Toogle();
    }
}
