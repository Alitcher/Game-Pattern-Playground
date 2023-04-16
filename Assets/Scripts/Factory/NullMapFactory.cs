using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullMapFactory : IMapFactory
{
    public void CreateMap()
    {
        Debug.Log($"{GetType().Name} null implementation");
    }


}
