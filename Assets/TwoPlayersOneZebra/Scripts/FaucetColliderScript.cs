using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetColliderScript : MonoBehaviour {
    public GameObject actualWater;
	public GameObject faucetGO;
	public Animator faucetAnimator;

	void Start(){
		faucetAnimator = faucetGO.GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
			faucetAnimator.SetTrigger ("TurnOn");
			actualWater.SetActive(true);
        }
    }


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Equals("Hand"))
		{
			faucetAnimator.SetTrigger ("TurnOff");
			actualWater.SetActive(false);
		}
	}
}
