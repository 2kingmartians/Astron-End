using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitCredits : MonoBehaviour {  

    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            loadScene.LoadScene("Facility");
        }
	}
}
