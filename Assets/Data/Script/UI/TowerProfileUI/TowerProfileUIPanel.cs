using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerProfileUIPanel : LoadComPonentsManager
{
    [SerializeField] protected Image profileImage;
    [SerializeField] protected TextMeshProUGUI profileName;
    [SerializeField] protected TextMeshProUGUI profileLv;
    [SerializeField] protected TextMeshProUGUI profileATK;
    [SerializeField] protected TextMeshProUGUI profileROF; 
    [SerializeField] protected TextMeshProUGUI profileIntro;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadProfileText();
    }

  
    
    protected virtual void LateUpdate() 
    {
        this.ShowProfile();
    }

    protected virtual void ShowProfile() 
    {
        TowerCtrl towerCtrl = PlayerManagerCtrl.Instance.CurrentPlayer.PlayerTowerPutting.TowerPoint.TowerCtrl;
        if (towerCtrl == null) return;
        this.profileImage.sprite = towerCtrl.TowerProfileSO.towerSprite;
        this.profileName.text = towerCtrl.TowerProfileSO.towerEnum.ToString();
        this.profileLv.text = towerCtrl.TowerLevel.CurrentLevel.ToString();
        this.profileATK.text = towerCtrl.TowerAttribute.TowerAttributeSO.ATK.ToString();
        this.profileROF.text = towerCtrl.TowerAttribute.TowerAttributeSO.ROF.ToString();
        
    }
 
    protected virtual void LoadProfileText() 
    {
        if (this.profileImage != null && this.profileName != null && this.profileATK != null && this.profileROF != null && this.profileIntro != null && this.profileLv != null) return;
        this.profileImage = transform.Find("profileImage").GetComponent<Image>();
        this.profileName = transform.Find("profileName").GetComponent<TextMeshProUGUI>();
        this.profileLv = transform.Find("profileLv/Count").GetComponent<TextMeshProUGUI>();
        this.profileATK = transform.Find("profileATK/Count").GetComponent<TextMeshProUGUI>();
        this.profileROF = transform.Find("profileROF/Count").GetComponent<TextMeshProUGUI>();
        this.profileIntro = transform.Find("profileIntro").GetComponentInChildren<TextMeshProUGUI>();

    }
    
}
