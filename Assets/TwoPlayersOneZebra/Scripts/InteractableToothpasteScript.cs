using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToothpasteScript : VRTK_InteractableObject
{
    public Transform toothpasteCap;
    //private bool hasFired;
    //private bool hasBeenTouched;

    void Start()
    {
        //Debug.Log("REPARENTING THE CAP");
        //toothpasteCap.transform.SetParent(this.transform.parent,false); //Re-parent this puppy, it'll be fine
    }

    public void OnCapGrabbed()
    {
        this.isUsable = true;
    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        Debug.Log("START USING");
        base.StartUsing(usingObject);
        SqueezeToothpaste();
    }

    private void SqueezeToothpaste()
    {
        Debug.Log("SQUEEZED SOME GODDAMN TOOTHPASTE");
    }

    /*
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
    */
}
