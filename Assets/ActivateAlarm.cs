using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAlarm : MonoBehaviour {



	void OnTriggerEnter(Collider other) {


		if (other.gameObject.tag.Equals ("Hand")) {
			Debug.Log ("STARTING GAME!");
		}
	}
}
