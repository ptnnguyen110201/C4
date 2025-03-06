using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemInventory 
{
    public int itemID;
    public ItemProfileSO itemProfileSO;
    public int itemCount;
    public int itemStack = 99;
    public virtual bool Deduct(int Amount) 
    {
        if(this.itemCount < Amount) return false;
        this.itemCount -= Amount;
        return true;
    }
    public bool isFullStack()
    {
        if (this.itemProfileSO.isUnlimitedStack) return false; 
        return this.itemCount >= this.itemStack;
    }


}
