using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullObjectPool : IObjectPool
{
    public void CreateObjectPool()
    {
        Debug.Log($"{GetType().Name} null implementation");
    }

}
