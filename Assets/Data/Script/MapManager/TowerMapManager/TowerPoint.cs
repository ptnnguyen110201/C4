using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPoint : LoadComPonentsManager
{
    [SerializeField] protected float puttingDelayTimer = 3;
    [SerializeField] protected TextMeshProUGUI towerText;
    [SerializeField] protected Transform towerPoint;
    [SerializeField] protected Transform towerModel;
    [SerializeField] protected TowerSliderPuting towerSliderPuting;

    [SerializeField] protected TowerCtrl towerCtrl;
    public TowerCtrl TowerCtrl => towerCtrl;

    [SerializeField] protected TowerProfileSO towerProfileSO;
    public TowerProfileSO TowerProfileSO => towerProfileSO;
    [SerializeField] protected bool isPutted = false;
    public bool IsPutted => isPutted;
    [SerializeField] protected bool isFixed = false;
    public bool IsFixed => isFixed;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerModel();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetModel();
    }
    protected virtual void LoadTowerModel()
    {
        if (this.towerModel != null && this.towerModel != null && this.towerText != null && this.towerSliderPuting != null) return;
        this.towerPoint = transform.Find("PointEffect").GetComponent<Transform>();
        this.towerModel = transform.Find("PointModel").GetComponent<Transform>();
        this.towerText = transform.Find("PointStateUI/Canvas/Text").GetComponent<TextMeshProUGUI>();
        this.towerSliderPuting = transform.GetComponentInChildren<TowerSliderPuting>(true);
        Debug.Log(transform.name + ": Load TowerModel", gameObject);
    }


    public virtual void PuttingTower()
    {
        this.StartPuttingDelay(this.puttingDelayTimer);
        this.Invoke(nameof(this.SpawnTower), this.puttingDelayTimer);
        this.Invoke(nameof(this.ResetModel), this.puttingDelayTimer);
    }

    public virtual void StartPuttingDelay(float chargTime)
    {
        this.towerSliderPuting.gameObject.SetActive(true);
        this.towerSliderPuting.StartPuttingDelay(chargTime);
        this.towerText.transform.localPosition = new Vector3(0f, 440f, 0f);
        this.towerText.text = "Putting!";
    }
    public virtual void SpawnTower()
    {
        if (this.towerPoint == null) return;

        if (this.IsPutted) return;
        if (this.TowerProfileSO == null) return;

        TowerCtrl towerCtrl = TowerManagerCtrl.Instance.TowerPrefabs.GetTowerByEnum(this.towerProfileSO.towerEnum);
        if (towerCtrl == null) return;

        TowerCtrl newTower = TowerManagerCtrl.Instance.TowerSpawner.Spawn(towerCtrl, transform.position);
        this.towerCtrl = newTower;
        this.towerCtrl.SetProfile(this.towerProfileSO);  
        this.isPutted = true;

        newTower.gameObject.SetActive(true);
    


    }
    public virtual void SetText(string text, Vector3 Pos)
    {
        this.towerText.text = text;
        this.towerText.transform.localPosition = Pos;
    }
    public virtual void SetProfile(TowerProfileSO towerProfileSO) => this.towerProfileSO = towerProfileSO;
    protected virtual void SetModel()
    {
        if (this.isFixed)
        {
            this.towerModel.gameObject.SetActive(true);
            this.towerPoint.gameObject.SetActive(true);
            this.towerText.text = string.Empty;
            this.towerSliderPuting.gameObject.SetActive(false);
            return;
        }

        this.towerModel.gameObject.SetActive(false);
        this.towerPoint.gameObject.SetActive(true);
        this.towerText.text = string.Empty;
        this.towerSliderPuting.gameObject.SetActive(false);
    }

    protected virtual void ResetModel()
    {
        if (this.isPutted)
        {
            this.towerPoint.gameObject.SetActive(false);
            this.towerModel.gameObject.SetActive(false);
            this.SetText(string.Empty, new Vector3(0, 0, 0));
            this.towerSliderPuting.gameObject.SetActive(false);
            return;
        }
        this.SetModel();
    }

    public virtual void DespawnTower() 
    {
        if (this.towerCtrl == null) return;
        this.towerCtrl.DespawnBase.DespawnObj();
        this.towerCtrl = null;
        this.isPutted = false;
        this.ResetModel();
    }

}
