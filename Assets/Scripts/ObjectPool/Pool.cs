using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool : MonoBehaviour
{
    [SerializeField] private List<ObjectPool> pooledObjects; //FAST POOL
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private int currentIndex = -1;

    public Pool(GameObject prefab, Transform parent, int initialSize)
    {
        this.prefab = prefab;
        this.parent = parent;
        pooledObjects = new List<ObjectPool>(initialSize);

        for (int i = 0; i < initialSize; i++)
        {
            pooledObjects.Add(new ObjectPool(prefab, parent));
        }
    }

    public ObjectPool GetObject()
    {
        currentIndex++;

        if (currentIndex >= pooledObjects.Count)
        {
            pooledObjects.Add(new ObjectPool(prefab, parent));
        }

        ObjectPool obj = pooledObjects[currentIndex];
        obj.Activate();
        return obj;
    }



    public void ResetPool()
    {
        for (int i = 0; i <= currentIndex; i++)
        {
            pooledObjects[i].Deactivate();
        }

        currentIndex = -1;
    }
}
