using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static IProfile profile = new NullProfile();
    private static IMapFactory mapFactory = new NullMapFactory();
    private static IObjectPool objectPool = new NullObjectPool();

    public static IProfile Profile => profile;
    public static IMapFactory MapFactory => mapFactory;
    public static IObjectPool ObjectPool => objectPool;

    public static void Provide<T>(T service) where T : class
    {
        if (service == null) return;

        switch (service)
        {
            case IProfile _profile:
                profile = _profile;
                break;
            case IMapFactory _mapFactory:
                mapFactory = _mapFactory;
                break;
            case IObjectPool _objectPool:
                objectPool = _objectPool;
                break;
            default:
                Debug.LogError($"Unsupported service type: {typeof(T)}");
                break;
        }
    }
}
