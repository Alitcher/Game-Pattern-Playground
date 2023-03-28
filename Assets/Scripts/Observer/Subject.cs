﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject {

    object sender;

    public Subject(object sender) {
        this.sender = sender;
    }
    
    /**
        Todo:
            Implement methods: 
                * AddObserver - Used by observers to register to this subject
                * RemoveObserver - Used by observers to deregister from this subject
                * Notify - Used by owner of this subject to notify observers, that something has happened.   
        */  
    
}