using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : ButtonAbstract
{

    protected override void OnClick()
    {
        InventoryUI.Instance.Toggle();
    }
}
