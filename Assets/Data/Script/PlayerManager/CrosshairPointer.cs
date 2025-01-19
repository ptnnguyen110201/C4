using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPointer : LoadComPonentsManager
{
    protected float maxDistance = 100;
    [SerializeField] protected LayerMask layerMask;

    protected virtual void Update() 
    {
        this.Pointing();
    }

    protected virtual void Pointing() 
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if(Physics.Raycast(ray, out RaycastHit hit , this.maxDistance , this.layerMask)) 
        {
            transform.position = hit.point; 
        }
    }
}
