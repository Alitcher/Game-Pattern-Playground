using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pools
{
    [SerializeField] private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    public Pools()
    {

        pools = new Dictionary<string, Pool>();
    }

    public void CreatePool(string key, GameObject prefab, Transform parent, int initialSize)
    {
        pools[key] = new Pool(prefab, parent, initialSize);
    }

    public ObjectPool GetObject(string key)
    {
        if (!pools.ContainsKey(key))
        {
            // Handle the situation, for instance by logging an error and returning null
            Debug.LogError("Pool with key " + key + " does not exist.");
            return null;
        }
        return pools[key].GetObject();
    }

    public void ResetPool(string key)
    {
        if (!pools.ContainsKey(key))
        {
            // Handle the situation, for instance by logging an error and doing nothing
            Debug.LogError("Pool with key " + key + " does not exist.");
            return;
        }
        pools[key].ResetPool();
    }
}
