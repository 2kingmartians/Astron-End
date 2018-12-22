using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractSwitchScene : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			if (Input.GetButtonDown("Interact")) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("End");

			}
		}
	}
}
