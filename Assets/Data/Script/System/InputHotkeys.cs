using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotkeys : Singleton<InputHotkeys>
{
    public bool isInPutKey1 = false;
    public bool isInPutKey2 = false;
    public bool isInPutKey3 = false;
    public bool isInPutKey4 = false;
    public bool isInPutKey5 = false;
    public bool isInPutKey6 = false;
    public bool isInPutKey7 = false;
    public bool isInputKeyQ = false;


    public bool isToogleInventoryUI = false;
    public bool isToogleMusic = false;
    public bool isToogleSetting = false;
    public bool isToogleShop = false;
  

    public bool isBack = false; 
    protected virtual void Update()
    {
        this.ToogleInventory();
        this.ToogleMusic();
        this.ToogleSetting();
        this.ToogleShop();
        this.ToogleBack();
        this.ToogleShopTower();
        this.InputKey();
 
    }

    protected virtual void ToogleInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }

    protected virtual void ToogleSetting()
    {
        this.isToogleSetting = Input.GetKeyUp(KeyCode.N);
    }
    protected virtual void ToogleShop()
    {
        this.isToogleShop = Input.GetKeyUp(KeyCode.P);
    }
    protected virtual void ToogleShopTower()
    {
        this.isInputKeyQ = Input.GetKeyUp(KeyCode.Q);
    }

    protected virtual void ToogleBack()
    {
        this.isBack = Input.GetKeyUp(KeyCode.Escape);
    }

    protected virtual void InputKey() 
    {
        this.isInPutKey1 = Input.GetKeyUp(KeyCode.Alpha1);
        this.isInPutKey2 = Input.GetKeyUp(KeyCode.Alpha2);
        this.isInPutKey3 = Input.GetKeyUp(KeyCode.Alpha3);
        this.isInPutKey4 = Input.GetKeyUp(KeyCode.Alpha4);
        this.isInPutKey5 = Input.GetKeyUp(KeyCode.Alpha5);
        this.isInPutKey6 = Input.GetKeyUp(KeyCode.Alpha6);
        this.isInPutKey7 = Input.GetKeyUp(KeyCode.Alpha7);

       // if (this.isInPutKey1) Debug.Log("Key1");
       // if (this.isInPutKey2) Debug.Log("Key2");
       // if (this.isInPutKey3) Debug.Log("Key3");
       // if (this.isInPutKey4) Debug.Log("Key4");
       // if (this.isInPutKey5) Debug.Log("Key5");
       // if (this.isInPutKey6) Debug.Log("Key6");
       // if (this.isInPutKey7) Debug.Log("Key7");
    }

}