using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFactory : MonoBehaviour, IMapFactory
{
    public void CreateMap()
    {
        Debug.Log($"{GetType().Name} created");
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
