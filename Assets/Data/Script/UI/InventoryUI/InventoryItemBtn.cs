using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemBtn : ButtonAbstract
{
    [SerializeField] protected ItemInventory itemInventory;
    [SerializeField] protected Image ItemImage;
    [SerializeField] protected TextMeshProUGUI itemCount;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemText();
    }
    protected virtual void FixedUpdate() 
    {
        this.ItemUpdating();
    }
    protected virtual void LoadItemText()
    {
        if (this.ItemImage != null && this.itemCount != null) return;
        this.ItemImage = transform.Find("ItemImage").GetComponent<Image>();
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
        this.ItemImage.sprite = this.itemInventory.itemProfileSO.itemSprite;
        this.itemCount.text = this.itemInventory.itemCount.ToString();
    }
    protected override void OnClick()
    {

    }
}
