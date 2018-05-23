using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	GameObject[] lamps;
	float distance;
	[SerializeField]
	float maxDistanceThatCanTurnOnALamp=20;
	[SerializeField]
	bool GeneratorOn=false;

	// Use this for initialization
	void Start () {
		GeneratorOn=false;
		lamps = GameObject.FindGameObjectsWithTag ("Lamp");
		for (int i=0; i < lamps.Length; i++) {
			lamps [i].transform.GetChild (0).gameObject.SetActive (GeneratorOn);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnMouseDown(){
		//generate lights
		GeneratorOn=!GeneratorOn;
			for (int i = 0; i < lamps.Length; i++) {
				distance = Vector3.Distance (transform.position, lamps [i].transform.position);
				if (distance <= maxDistanceThatCanTurnOnALamp) {
				lamps [i].transform.GetChild (0).gameObject.SetActive (GeneratorOn);
			}
		} 
	}
}
