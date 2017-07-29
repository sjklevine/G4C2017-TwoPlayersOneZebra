using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToothpasteScript : VRTK_InteractableObject
{
    public VRTK_InteractableObject toothpasteCap;
    private bool hasFired;
    private bool hasBeenTouched;

    public void OnSecondaryGrab()
    {
        Debug.Log("TOOTHPASTE GOT TOUCHED");
        hasBeenTouched = true;
    }

    protected override void Update() 
    {
        if (!hasFired && hasBeenTouched) { 
            Debug.Log("I'M GETTING GRABBED BY HAND 2");
            Debug.Log("GRABBING OBJECT = " + GetGrabbingObject().name);
            Debug.Log("2nd GRABBING OBJECT = " + GetSecondaryGrabbingObject().name);
            hasFired = true;
        }
    }
}
