using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class CustomToothpasteCapGrabAttach : VRTK_FixedJointGrabAttach {
    public InteractableToothpasteScript toothpasteScript;

    public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
    {
        // Tell the toothpaste script that the cap is off and its free to be used!
        toothpasteScript.OnCapGrabbed();

        // Also make our rigidbody non-kinematic...
        this.GetComponent<Rigidbody>().isKinematic = false;

        // And nuke our follow script.
        Destroy(this.GetComponent<VRTK_TransformFollow>());

        // Now also do all the normal stuff.
        return base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint);
    }
}
