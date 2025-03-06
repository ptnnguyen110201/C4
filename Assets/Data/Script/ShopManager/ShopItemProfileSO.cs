
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemProfileSO", menuName = "ScriptableObject/ShopItemProfileSO", order = 2)]
public class ShopItemProfileSO : ScriptableObject
{
    public ItemProfileSO ItemProfileSO;
    public int Count;
    public ShopItemBuyProfileSO shopItemBuyProfileSO;

}

