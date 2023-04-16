using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorClientExample : MonoBehaviour
{
    private IProfile profile;
    private IMapFactory mapFactory;
    private IObjectPool objectPool;
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Provide<IProfile>(FindObjectOfType<Profile>());
        ServiceLocator.Provide<IObjectPool>(FindObjectOfType<ObjectPool>());
        ServiceLocator.Provide<IMapFactory>(FindObjectOfType<MapFactory>());

        profile = ServiceLocator.Profile;
        mapFactory = ServiceLocator.MapFactory;
        objectPool = ServiceLocator.ObjectPool;
        RegisterClass<InputHandler>();
    }

    private void RegisterClass<T>() where T : MonoBehaviour
    {
        ScriptRegistry.Provide(FindObjectOfType<T>());

        T instance = ScriptRegistry.GetScript<T>();
        if (instance != null)
        {
            Debug.Log($"{instance.GetType().Name} registered.");
        }
        else
        {
            Debug.LogError("ref null");
        }
    }

}
