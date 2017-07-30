using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetColliderScript : MonoBehaviour {
    public GameObject actualWater;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Hand"))
        {
            actualWater.SetActive(true);
        }
    }
}
