using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotkeys : Singleton<InputHotkeys>
{
    [SerializeField] protected bool isToogleInventoryUI = false;
    public bool IsToogleInventoryUI => isToogleInventoryUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    protected virtual void OpenInventory() 
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.P);
    }
}
