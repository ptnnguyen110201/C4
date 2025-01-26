using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryItemBtn : ButtonAbstract
{
    [SerializeField] protected ItemInventory itemInventory;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI itemCount;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void FixedUpdate() 
    {
        this.ItemUpdating();
    }
    protected virtual void LoadText()
    {
        if (this.itemName != null && this.itemCount != null) return;
        this.itemName = transform.Find("itemName").GetComponent<TextMeshProUGUI>();
        this.itemCount = transform.Find("itemCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": Load Text", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;

    }

     
    protected virtual void ItemUpdating() 
    {
        if (this.itemInventory.itemCount == 0) 
        {
            Destroy(this.gameObject);
            return;
        }
        this.itemName.text = this.itemInventory.itemProfileSO.itemName.ToString();
        this.itemCount.text = this.itemInventory.itemCount.ToString();
    }
    protected override void OnClick()
    {

    }
}
