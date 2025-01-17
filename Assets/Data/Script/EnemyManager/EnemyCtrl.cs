using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : LoadComPonentsManager
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Animator enemyAnimator;
    public Animator EnemyAnimator => enemyAnimator;

    [SerializeField] protected NavMeshAgent enemyAgent;
    public NavMeshAgent EnemyAgent => enemyAgent;

    [SerializeField] protected TowerTargetable towerTargetable;
    public TowerTargetable TowerTargetable => towerTargetable;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadEnemyAgent();
        this.LoadTowerTargetable();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0f, -0.1f, 0f);
        Debug.Log(transform.name + ": Load Model ", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.enemyAnimator != null) return;
        this.enemyAnimator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": Load Animator ", gameObject);
    }
    protected virtual void LoadEnemyAgent()
    {
        if (this.enemyAgent != null) return;
        this.enemyAgent = transform.GetComponent<NavMeshAgent>();
        this.enemyAgent.speed = 2f;
        this.enemyAgent.angularSpeed = 200f;
        this.enemyAgent.acceleration = 150f;
        Debug.Log(transform.name + ": Load EnemyAgent ", gameObject);
    }
    protected virtual void LoadTowerTargetable()
    {
        if (this.towerTargetable != null) return;
        this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();
        this.towerTargetable.transform.localPosition = new Vector3(0f, 0.6f, 0f);
        Debug.Log(transform.name + ": Load TowerTargetable", gameObject);
    }




}
