﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetWaterScript : MonoBehaviour {
    public TaskListScript taskList;
	public ParticleSystem wetToothbrushParticles;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Toothbrush"))
        {
            Debug.Log("TOOTHBRUSH IN WATER");
			wetToothbrushParticles.Play ();
            taskList.CompleteTask(0);
        }
    }
}