using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRegistry : MonoBehaviour
{
    [SerializeField] private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void Provide<T>(T service) where T : class
    {
        if (service != null)
            _services[typeof(T)] = service;
    }

    public static T GetScript<T>() where T : class
    {
        object service;
        if (_services.TryGetValue(typeof(T), out service))
            return service as T;

        return null;
    }
}
