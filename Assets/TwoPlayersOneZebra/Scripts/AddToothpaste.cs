using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToothpaste : MonoBehaviour {
	
	public GameObject toothpaste;

	void Start (){
		//toothpaste.SetActive (false);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Tube")) {
			toothpaste.SetActive(true);
		}
	}
}
