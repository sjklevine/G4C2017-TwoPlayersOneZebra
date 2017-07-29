using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToothpasteScript : VRTK_InteractableObject
{
    public VRTK_InteractableObject toothpasteCap;

    public override bool PerformSecondaryAction()
    {
        if (base.PerformSecondaryAction())
        {
            Debug.Log("I'M GETTING GRABBED BY HAND 2");
            Debug.Log("GRABBING OBJECT = " + GetGrabbingObject().name);
            Debug.Log("2nd GRABBING OBJECT = " + GetSecondaryGrabbingObject().name);
            return true;
        }
        else
        {
            return false;
        }
    }

}
