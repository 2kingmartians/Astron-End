using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFlickeringLights : MonoBehaviour {

    [HideInInspector]
    public static bool lightsEnabled = true;

    public GameObject lightsHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "Trigger Lights Off" && lightsEnabled == true)
        {
            lightsEnabled = false;
            GetComponent<AudioSource>().Play();
            ToggleLights();
            Debug.Log("Lights Off");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && gameObject.name == "Trigger Lights On" && lightsEnabled == false && Input.GetButtonDown("Interact"))
        {
            lightsEnabled = true;
            ToggleLights();
            Debug.Log("Lights On");
        }
    }

    void ToggleLights()
    {
        foreach(Transform child in lightsHolder.transform)
        {
            if (!lightsEnabled)
            {
                child.GetComponentInChildren<Light>().enabled = lightsEnabled;
                child.GetComponentInChildren<onOFFlight>().enabled = lightsEnabled;
            }
            else if (lightsEnabled)
            {
                child.GetComponentInChildren<Light>().enabled = lightsEnabled;
                child.GetComponentInChildren<Light>().intensity = 1f;
            }
        }
    }
}
