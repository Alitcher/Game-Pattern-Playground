using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{

    public static Vector3 Floored(this Vector3 vector)
    {
        return new Vector3(
            Mathf.Floor(vector.x),
            Mathf.Floor(vector.y),
            Mathf.Floor(vector.z));
    }

}
