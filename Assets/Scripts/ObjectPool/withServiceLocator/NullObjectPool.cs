using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullObjectPool : IObjectPool
{
    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void CreateObjectPool()
    {
        Debug.Log($"{GetType().Name} null implementation");
    }

    public void Deactivate()
    {
        throw new System.NotImplementedException();
    }
}
