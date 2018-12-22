using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Hider : MonoBehaviour {

	public GameObject[] hide;

	void Update()
	{
		foreach(GameObject go in hide) {

			if (Application.isPlaying)
				go.SetActive(true);
			else
				go.SetActive(false);
		}
	}
}