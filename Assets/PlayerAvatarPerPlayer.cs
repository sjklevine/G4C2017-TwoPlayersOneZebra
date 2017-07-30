using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarPerPlayer : MonoBehaviour {

	public GameObject leftHand;
	public GameObject rightHand;

	private int playerNumber;

	public void SetPlayerNumber(int playerNumber) {
		this.playerNumber = playerNumber;
		if (playerNumber == 0) {
			leftHand.SetActive (false);
		} else {
			rightHand.SetActive (false);
		}
	}
}
