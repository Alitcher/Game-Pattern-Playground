using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour,IObjectPool
{

    public void CreateObjectPool()
    {
        Debug.Log($"{GetType().Name} pool created");
    }
    private GameObject gameObject;

    public ObjectPool(GameObject prefab, Transform parent)
    {
        gameObject = GameObject.Instantiate(prefab, parent);
        Deactivate();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }


}
