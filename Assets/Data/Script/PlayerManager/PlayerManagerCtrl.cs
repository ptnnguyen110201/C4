using System.Collections;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
public class PlayerManagerCtrl : Singleton<PlayerManagerCtrl>
{
    [SerializeField] protected PlayerSpawner playerSpawner;
    public PlayerSpawner PlayerSpawner => playerSpawner;

    [SerializeField] protected PlayerPrefabs playerPrefabs;
    public PlayerPrefabs PlayerPrefabs => playerPrefabs;


    [SerializeField] protected PlayerEnum playerEnum;

    [SerializeField] protected PlayerCtrl currentPlayer;
    public PlayerCtrl CurrentPlayer => currentPlayer;   

    protected override void Awake()
    {
        base.Awake();
        this.PlayerSpawn();
    }
    protected virtual void PlayerSpawn() 
    {
        PlayerCtrl playerCtrl = this.playerPrefabs.GetPlayerByEnum(playerEnum);
        if (playerCtrl == null) return;
        PlayerCtrl newPlayer = this.playerSpawner.Spawn(playerCtrl);
        newPlayer.gameObject.SetActive(true);
        this.currentPlayer = newPlayer;
    }



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerSpawner();
        this.LoadPlayerPrefabs();
    }

    protected virtual void LoadPlayerSpawner()
    {
        if (this.playerSpawner != null) return;
        this.playerSpawner = transform.GetComponentInChildren<PlayerSpawner>();
        Debug.Log(transform.name + ": Load PlayerSpawner", gameObject);
    }
    protected virtual void LoadPlayerPrefabs()
    {
        if (this.playerPrefabs != null) return;
        this.playerPrefabs = transform.GetComponentInChildren<PlayerPrefabs>();
        Debug.Log(transform.name + ": Load PlayerPrefabs", gameObject);
    }

}

