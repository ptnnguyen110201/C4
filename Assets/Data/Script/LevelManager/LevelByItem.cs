using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByItem : LevelAbstract
{
    [SerializeField] protected ItemInventory playerExp;
  
    public override int GetCurrentExp()
    {
        if (this.GetPlayerExp() == null) return 0;
        return this.GetPlayerExp().itemCount;
    }

    protected override bool DeductExp(int exp) => this.GetPlayerExp().Deduct(exp);

    protected virtual ItemInventory GetPlayerExp() 
    {
        if (this.playerExp == null || this.playerExp.itemID == 0) 
            this.playerExp = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Exp);
        return this.playerExp;
    }


}
