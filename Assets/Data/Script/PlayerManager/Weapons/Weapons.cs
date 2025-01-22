using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : LoadComPonentsManager
{
    [SerializeField] protected List<WeaponAbstract> weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons() 
    {
        if(this.weapons.Count > 0 ) return;
        foreach(Transform child in this.transform) 
        {
            WeaponAbstract weaponAbstract = child.GetComponent<WeaponAbstract>();   
            if( weaponAbstract == null ) continue;
            this.weapons.Add( weaponAbstract );
        }

        Debug.Log(transform.name + ": Load Weapons ", gameObject);
    }
    public virtual WeaponAbstract GetCurrentWeapon() => this.weapons[0];
}
