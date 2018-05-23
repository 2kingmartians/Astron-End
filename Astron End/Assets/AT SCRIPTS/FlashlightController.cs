using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{

    public GameObject flashlight;
    private bool isTurnedOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) == true)
        {
            if (isTurnedOn)
            {

                isTurnedOn = false;
                flashlight.SetActive(false);
                return;

            }
            else
            {
                isTurnedOn = true;
                flashlight.SetActive(true);
                return;
            }
        }
    }

}
