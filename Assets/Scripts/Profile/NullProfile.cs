using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullProfile : IProfile
{
    public void LoadProfile()
    {
        Debug.Log($"{GetType().Name} null implementation");
    }


}
