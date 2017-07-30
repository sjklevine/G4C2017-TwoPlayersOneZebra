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
			ToothbrushZoneScript.toothPasteApplied = true;	//Added by Jackson
		}
	}

	void HideToothpasteGlob (){  //Added by Jackson to hide toothpaste glob after teeth are all clean

		toothpaste.SetActive (false); // Just repeat the collision to add more toothpaste on the brush!
	}
}
