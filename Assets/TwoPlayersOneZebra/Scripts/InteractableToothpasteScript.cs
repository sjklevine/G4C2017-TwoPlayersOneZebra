using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableToothpasteScript : VRTK_InteractableObject
{
    public VRTK_InteractableObject toothpasteCap;
    public ParticleSystem toothpasteParticles;
    private PhotonView photonView;

    void Start()
    {
        // Mixing some VRTK methods here but this seems cleaner than writing a brand new GrabAttach script for the toothpaste.
        this.InteractableObjectGrabbed += HandleGrabToothpaste;
        this.InteractableObjectUngrabbed += HandleUngrabToothpaste;
        toothpasteCap.InteractableObjectGrabbed += HandleGrabCap;

        this.photonView = this.GetComponent<PhotonView>();
    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        this.photonView.RPC("NetworkedSqueezeTube", PhotonTargets.AllViaServer, true);
    }
    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        base.StopUsing(usingObject);
        this.photonView.RPC("NetworkedSqueezeTube", PhotonTargets.AllViaServer, false);
    }

    // ----- Privates ! ----- //

    // "Grab/ungrab" callbacks for tube and cap
    private void HandleGrabToothpaste(object sender, InteractableObjectEventArgs e)
    {
        // ONLY allow the cap to be grabbable when this is grabbed!
        this.toothpasteCap.isGrabbable = true;
        this.photonView.RPC("UpdateCapGrabbable", PhotonTargets.AllViaServer, true);
    }
    private void HandleUngrabToothpaste(object sender, InteractableObjectEventArgs e)
    {
        this.toothpasteCap.isGrabbable = false;
        this.photonView.RPC("UpdateCapGrabbable", PhotonTargets.AllViaServer, false);
    }

    private void HandleGrabCap(object sender, InteractableObjectEventArgs e)
    {
        this.photonView.RPC("NetworkedCapGrabbed", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    void UpdateCapGrabbable(bool newState)
    {
        this.toothpasteCap.isGrabbable = newState;
    }

    [PunRPC]
    void NetworkedCapGrabbed()
    {
        // This is a victory checkpoint!
        TaskListScript.instance.CompleteTask(0);

        // Tell the toothpaste script that the cap is off and its free to be used!
        this.isUsable = true;

        // And nuke our follow script.
        Destroy(toothpasteCap.GetComponent<VRTK_TransformFollow>());

        // Also make the cap rigidbody non-kinematic...
        toothpasteCap.gameObject.AddComponent<Rigidbody>();
    }

    [PunRPC]
    void NetworkedSqueezeTube(bool newState)
    {
        if (newState)
        {
            toothpasteParticles.Play();
        }
        else
        {
            toothpasteParticles.Stop();
        }
    }
}