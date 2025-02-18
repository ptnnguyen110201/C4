using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObject/ItemProfileSO", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public ItemEnum itemEnum;
    public string itemName;
    public Sprite itemSprite;
    public bool isStackable = false;
}
