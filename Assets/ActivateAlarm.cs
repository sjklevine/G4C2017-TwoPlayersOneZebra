using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAlarm : MonoBehaviour {
	public ZebraAnimationSequence zas;
	Vector3 downPosition;
	AudioSource cachedAudio;


	void Start() {
		cachedAudio = this.GetComponent<AudioSource> ();
		downPosition= this.transform.localPosition;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Hand")) {
			Debug.Log ("STARTING GAME!");
			this.transform.localPosition = downPosition;
			cachedAudio.Stop ();
			zas.StartTheIntro ();
		}
	}
}
