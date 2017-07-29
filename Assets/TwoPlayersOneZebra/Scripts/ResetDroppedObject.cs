using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDroppedObject : MonoBehaviour {
	private Vector3 startPosition;
	private Quaternion startRotation;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= (startPosition.y - 1)) {
			transform.position = startPosition;
			transform.rotation = startRotation;
		}
	}
}
