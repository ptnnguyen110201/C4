public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    public override void DespawnObj() 
    {
        ItemDropCtrl itemdropCtrl = (ItemDropCtrl)this.parent;
        ItemInventory item = new ItemInventory()
        {
            itemProfileSO = InventoryManager.Instance.GetItemProfileSO(itemdropCtrl.ItemEnum),
            itemCount = itemdropCtrl.ItemCount  
        };
        InventoryManager.Instance.GetInventoryCodeName(itemdropCtrl.InventoryEnum).AddItem(item);
        base.DespawnObj();
    }
}
