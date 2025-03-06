using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerProfileSO", menuName = "ScriptableObject/TowerProfileSO", order = 2)]
public class TowerProfileSO : ScriptableObject
{
    public TowerEnum towerEnum = TowerEnum.None;
    public BulletEnum bulletEnum;
    public Sprite towerSprite;
    public List<TowerAttributeSO> towerAttributeSO;
    public List<TowerUpgrade> towerUpgrade;



    public TowerAttributeSO GetTowerAttributeSO(int Lv)
    {
        foreach (TowerAttributeSO towerAttributeSO in this.towerAttributeSO)
        {

            if (towerAttributeSO.Lv != Lv) continue;
            return towerAttributeSO;
        }
        return null;
    }


    public int GetMaxLevel() => this.towerAttributeSO.Count;

    public List<TowerItemUpgrade> GetTowerItemUpgrades(int Lv)
    {
        foreach (TowerUpgrade towerUpgrade in this.towerUpgrade)
        {

            if (towerUpgrade.Lv != Lv + 1) continue;
            return towerUpgrade.itemUpgrades;
        }
        return null;
    }
}
