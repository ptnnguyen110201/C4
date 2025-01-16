using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : LoadComPonentsManager
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent enemyAgent;
    public NavMeshAgent EnemyAgent => enemyAgent;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadEnemyAgent();
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


    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0f, -0.1f, 0f);
        Debug.Log(transform.name + ": Load Model ", gameObject);
    }
}
