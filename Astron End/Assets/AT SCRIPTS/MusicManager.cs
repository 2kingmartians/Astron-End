using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	GameObject MusicBasic;
	[SerializeField]
	GameObject MusicMenu;

	// Use this for initialization
	void Start () {
		MusicBasic = GameObject.Find ("MusicBasic");
		MusicMenu = GameObject.Find ("menuMusic");

		
	}
	
	// Update is called once per frame
	void Update () {
		if (MusicMenu.activeInHierarchy==true) {
			MusicBasic.SetActive (false);
			print (MusicMenu);
		} else {
			MusicBasic.SetActive (true);
		}
	}
}
