using UnityEngine;
using VRTK;
using VRTK.SecondaryControllerGrabActions;

public class CustomToothpasteGrabAction : VRTK_SwapControllerGrabAction
{
    public InteractableToothpasteScript toothpasteScript;

    protected override void Awake()
    {
        base.Awake();
        isSwappable = false; // Because second hand grab means TOOTHPASTE
    }

    public override void ProcessUpdate()
    {
        Debug.Log("BEING PROCESS UPDATED");
        toothpasteScript.OnSecondaryGrab();
    }

    /*
    public override void Initialise(VRTK_InteractableObject currentGrabbdObject, VRTK_InteractGrab currentPrimaryGrabbingObject, VRTK_InteractGrab currentSecondaryGrabbingObject, Transform primaryGrabPoint, Transform secondaryGrabPoint)
    {
        // On secondary grab, PICK UP THE CAP

        // Also restore this to be swappable
    }
    */

}