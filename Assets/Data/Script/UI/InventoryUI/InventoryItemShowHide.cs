using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemShowHide : LoadComPonentsManager
{
    [SerializeField] protected ItemInventory itemInventory;
    [SerializeField] protected Image itemImage;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI itemCount;
    [SerializeField] protected TextMeshProUGUI itemIntroduction;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemProfiles();
    }

    protected virtual void LoadItemProfiles()
    {
        if (this.itemImage != null && this.itemName != null && this.itemCount != null) return;
        this.itemImage = transform.Find("ItemProfileUI/ItemImage/BG/Image").GetComponent<Image>();
        this.itemName = transform.Find("ItemProfileUI/ItemName/Text").GetComponent<TextMeshProUGUI>();
        this.itemCount = transform.Find("ItemProfileUI/ItemCount/Text").GetComponent<TextMeshProUGUI>();
        this.itemIntroduction = transform.Find("ItemProfileUI/ItemIntroduction/BG/Text").GetComponent<TextMeshProUGUI>();
    }

    public virtual void SetItemInventory(ItemInventory itemInventory) 
    {
        this.itemInventory = itemInventory;
        this.SetProfileUI(itemInventory);
    }

    protected virtual void SetProfileUI(ItemInventory itemInventory) 
    {
        if (itemInventory == null || itemInventory.itemCount == 0) return;
        this.itemImage.sprite = itemInventory.itemProfileSO.itemSprite;
        this.itemName.text = itemInventory.itemProfileSO.itemName;
        this.itemCount.text = $"Count : {itemInventory.itemCount}"; 
        this.itemIntroduction.text = $"Will Update";
    }

}
