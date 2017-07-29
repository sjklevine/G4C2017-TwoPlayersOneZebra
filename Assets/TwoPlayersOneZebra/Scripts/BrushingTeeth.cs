using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushingTeeth : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Teeth")) {
			Debug.Log ("brush brush brush");
		}
	}
}
