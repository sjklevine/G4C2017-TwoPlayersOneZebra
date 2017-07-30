using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushingTeeth : MonoBehaviour {
	public ParticleSystem foam;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Teeth") && ToothbrushZoneScript.toothPasteApplied == true) {
			Debug.Log ("brush brush brush");
			if (foam != null) {
				foam.Play ();
			}
		}
	}
		void OnTriggerExit(Collider other){
			if (other.gameObject.tag.Equals ("Teeth")) {
			if (foam != null) {
				foam.Stop ();
			}
			}
		
	}
}
