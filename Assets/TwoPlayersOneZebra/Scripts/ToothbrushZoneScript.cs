using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushZoneScript : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Toothbrush")) {
			Debug.Log ("YEAHHHHHH");
		}
	}
}