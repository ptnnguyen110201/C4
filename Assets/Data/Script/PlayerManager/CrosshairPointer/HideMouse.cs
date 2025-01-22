using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : LoadComPonentsManager
{
    protected override void Start()
    {
        base.Start();
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
