using UnityEngine;

public abstract class GenericMove<T> : LoadComPonentsManager where T : MonoBehaviour
{
    [SerializeField] protected T parent;
    [SerializeField] protected float speed;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }
    protected abstract void Moving();

    protected virtual void LoadCtrl()
    {
        if (this.parent != null) return;
        this.parent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + "Load Ctrl", gameObject);
    }
}
