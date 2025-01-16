using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadComPonentsManager : MonoBehaviour
{
    protected virtual void LoadComponents()
    {
        // For Override 
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void ResetValue()
    {
        // For Override 
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }


}
