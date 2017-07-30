using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToothpaste : MonoBehaviour {
	
	public GameObject toothpaste;
	public GameObject cap;
	private bool capOff;

	void Start (){
		toothpaste.SetActive (false);
	}

	void OnTriggerEnter(Collider other) {

		capOff = cap.GetComponent<InteractableToothpasteScript> ().isUsable;
		if (other.gameObject.tag.Equals ("Tube") && capOff == true) {
			toothpaste.SetActive(true);
		}
	}
}
