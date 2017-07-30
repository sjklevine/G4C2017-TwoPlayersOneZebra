using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothbrushZoneScript : MonoBehaviour {

	public bool toothPasteApplied = false;
	public GameObject teethDirty;
	public GameObject teethLessDirty;
	public GameObject teethClean;
	public bool brushingNow;
	private bool teethArePartlyClean;
	private bool teethAreSparklingClean;
	private float elapsedTime;
	public float brushingTimeLeft = 5f;

	void Start(){
		teethDirty.SetActive (true);
		teethLessDirty.SetActive (false);
		teethClean.SetActive (false);
		teethArePartlyClean = false;
		teethAreSparklingClean = false;
		brushingNow = false;
	}

	void Update(){
	
		if (brushingNow) {
			
			brushingTimeLeft -= Time.deltaTime;

			if (brushingTimeLeft <= 2.5f) {
				PartlyClean ();
			}


			if (brushingTimeLeft <= 0f) {
				FullyClean ();
			}
		}
	
	}

	void OnTriggerEnter(Collider other) {
		//if (other.gameObject.tag == "Toothbrush" && toothPasteApplied == true) {
		if (other.gameObject.tag == "Toothbrush") {
				
				if(!teethAreSparklingClean){
					Debug.Log ("begin to clean teeth");
				}
				else {
						//Teeth are already completely clean
					}
		}
	}

	void OnTriggerStay(Collider other){
		//if (other.gameObject.tag == "Toothbrush" && toothPasteApplied == true) {		
		if (other.gameObject.tag == "Toothbrush") {
				
			
			if (!teethAreSparklingClean) {
				Debug.Log ("keep cleaning");
				brushingNow = true;
			} 
			else {
				//Teeth are already completely clean
			}
		}
	}

	void OnTriggerExit(Collider other){
			brushingNow = false;

			if(teethArePartlyClean){
				brushingTimeLeft = 2.5f;
			}
			if(teethAreSparklingClean){
				brushingTimeLeft = 5f;
			}
		
		}

		void PartlyClean(){
			teethDirty.SetActive (false);
			teethLessDirty.SetActive (true);
			teethClean.SetActive (false);
			teethArePartlyClean = true;
		}

		void FullyClean(){
			teethDirty.SetActive (false);
			teethLessDirty.SetActive (false);
			teethClean.SetActive (true);
			teethAreSparklingClean = true;

		//Need to hide the toothpaste on the toothbrush nad then set toothPasteApplied to false

		}
	}
