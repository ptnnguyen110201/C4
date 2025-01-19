using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected bool isLeftClick = false;
    [SerializeField] protected bool isRightClick = false;


    protected virtual void Update()
    {
        this.CheckMouseClick();
    }

    protected virtual void CheckMouseClick()
    {
        this.isLeftClick = Input.GetMouseButton(0);
        this.isRightClick = Input.GetMouseButton(1);
    }

    public virtual bool IsRigtClick()  => this.isRightClick;
 
}
