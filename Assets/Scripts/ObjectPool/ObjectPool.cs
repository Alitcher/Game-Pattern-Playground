using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPool
{
    public void CreateObjectPool()
    {
        Debug.Log($"{GetType().Name} pool created");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
