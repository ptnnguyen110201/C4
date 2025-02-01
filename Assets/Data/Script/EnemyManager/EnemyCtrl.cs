using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : PoolObj
{
    [SerializeField] protected EnemyEnum enemyEnum;
    [SerializeField] protected Transform model;
    [SerializeField] protected Animator enemyAnimator;
    public Animator EnemyAnimator => enemyAnimator;

    [SerializeField] protected NavMeshAgent enemyAgent;
    public NavMeshAgent EnemyAgent => enemyAgent;

    [SerializeField] protected TowerTargetable towerTargetable;
    public TowerTargetable TowerTargetable => towerTargetable;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;
    [SerializeField] protected EnemyMove enemyMove;
    public EnemyMove EnemyMove => enemyMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadEnemyAgent();
        this.LoadTowerTargetable();
        this.LoadEnemyDamageReceiver();
        this.LoadEnemyDespawn();
        this.LoadEnemyMove();
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

    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": Load EnemyDamageReceiver", gameObject);
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": Load EnemyDespawn", gameObject);
    }
    protected virtual void LoadEnemyMove()
    {
        if (this.enemyMove != null) return;
        this.enemyMove = transform.GetComponentInChildren<EnemyMove>();
        Debug.Log(transform.name + ": Load EnemyMove", gameObject);
    }

    public override string GetName() => this.enemyEnum.ToString();

}
