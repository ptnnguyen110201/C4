using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCloseBtn : ButtonAbstract
{
    public virtual void CloseIventoryUI() 
    {
        InventoryUI.Instance.Hide();
    }
    protected override void OnClick()
    {
      this.CloseIventoryUI();
    }
}
