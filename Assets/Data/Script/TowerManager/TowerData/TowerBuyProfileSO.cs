
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerBuyProfileSO", menuName = "ScriptableObject/TowerBuyProfileSO", order = 2)]
public class TowerBuyProfileSO : ScriptableObject
{
    public TowerProfileSO towerProfileSO;
    public ItemProfileSO itemProfileSO;
    public int itemPrice;
}

