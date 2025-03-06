using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTextCount : TextGeneric<ItemDropCtrl>
{
    protected override void UpdateText()
    {
        this.text.text = $" + {this.parent.ItemCount}";


    }
}
