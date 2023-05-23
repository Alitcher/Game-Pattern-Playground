using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour, IProfile
{
    public void LoadProfile()
    {
        Debug.Log($"{GetType().Name} Profile load");
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadProfile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
